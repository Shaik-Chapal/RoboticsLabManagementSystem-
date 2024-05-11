using Serilog;
using Serilog.Events;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using RoboticsLabManagementSystem.Api;
using RoboticsLabManagementSystem.Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RoboticsLabManagementSystem.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Infrastructure.Securities.Permissions;
using RoboticsLabManagementSystem.Api.Extensions;
using Swashbuckle.AspNetCore.SwaggerUI;
using RoboticsLabManagementSystem.Application;
using RoboticsLabManagementSystem.Domain.Utilities;
using FluentValidation.AspNetCore;




var builder = WebApplication.CreateBuilder(args);
//Serilog configuration
builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

try
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var migrationAssembly = Assembly.GetExecutingAssembly().FullName;
    string recaptchaSecretKey = builder.Configuration.GetSection("CaptchaSettings:SecretKey").Value;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    {
        containerBuilder.RegisterModule(new ApiModule());
        containerBuilder.RegisterModule(new ApplicationModule());
        containerBuilder.RegisterModule(new InfrastructureModule(connectionString, migrationAssembly, recaptchaSecretKey));
    });

    builder.Services.AddDbContext<ApplicationDbContext>(options =>
      options.UseSqlServer(connectionString,
      (x) => x.MigrationsAssembly(migrationAssembly)));
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    builder.Services.AddIdentity();
    builder.Services.AddAuthentication()
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
            };
        });
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("Administrator", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("Administrator", "Administrator");
        });
        options.AddPolicy("Manager", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("Manager", "Manager");
        });
        options.AddPolicy("AdminManager", policy =>
        {
            policy.AuthenticationSchemes.Clear();
            policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireAuthenticatedUser();
            policy.Requirements.Add(new AdminManagerRequirement());
        });
        options.AddPolicy("User", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("User", "User");
        });
    });


    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSites",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200", "https://localhost:7307", "https://localhost:7070")
                .AllowAnyMethod()
                   .AllowAnyHeader();
            });
    });

    builder.Services.AddSingleton<IAuthorizationHandler, AdminManagerRequirementHandler>();

    builder.Services.AddControllers()
       .AddFluentValidation(x =>
        x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

    builder.AddSwagger();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.Configure<Smtp>(builder.Configuration.GetSection("Smtp"));

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Robotics Lab Management System API Server V1");
            c.DocumentTitle = "Robotics Lab Management System Api";
            c.DocExpansion(DocExpansion.None);
        });
    }

    app.UseCors("AllowSites");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    Log.Information("API Project Starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}