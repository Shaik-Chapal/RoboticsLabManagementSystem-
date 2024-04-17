using Autofac;
using RoboticsLabManagementSystem.Application.ExternalServices;
using RoboticsLabManagementSystem.Application.UnitOfWork;
using RoboticsLabManagementSystem.Domain.Repositories;
using RoboticsLabManagementSystem.Infrastructure.ExternalServices;
using RoboticsLabManagementSystem.Infrastructure.Repositories;
using RoboticsLabManagementSystem.Infrastructure.Securities;

namespace RoboticsLabManagementSystem.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _recaptchaSecretKey;

        public InfrastructureModule(string connectionString, string migrationAssemblyName, string recaptchaSecretKey)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _recaptchaSecretKey = recaptchaSecretKey;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TokenService>().As<ITokenService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssembly", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<GoogleCaptchaVerificationService>()
                .As<ICaptchaVerificationService>()
                .WithParameter("secretKey", _recaptchaSecretKey)
                .InstancePerLifetimeScope();

            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BranchRepository>().As<IBranchRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HtmlEmailService>().As<IEmailService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<EmailMessageService>().As<IEmailMessageService>()
                .InstancePerLifetimeScope();

            //builder.RegisterType<FileService>().As<IFileService>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}