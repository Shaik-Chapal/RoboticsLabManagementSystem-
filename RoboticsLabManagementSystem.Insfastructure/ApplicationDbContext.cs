using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using RoboticsLabManagementSystem.Infrastructure.DataSeeder;
using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RoboticsLabManagementSystem.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,
        ApplicationRole, Guid,
        ApplicationUserClaim, ApplicationUserRole,
        ApplicationUserLogin, ApplicationRoleClaim,
        ApplicationUserToken>,
        IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssembly;

        public ApplicationDbContext(string connectionString, string migrationAssembly)
        {
            _connectionString = connectionString;
            _migrationAssembly = migrationAssembly;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    x => x.MigrationsAssembly(_migrationAssembly));
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasData(UserSeed.Users());
            modelBuilder.Entity<ApplicationUserClaim>().HasData(UserClaimSeed.Claims());
            modelBuilder.Entity<Company>().HasData(CompanySeed.Claims());

            modelBuilder.Entity<Company>()
                .HasMany(x => x.Branches)
                .WithOne(y => y.Company)
                .HasForeignKey(y => y.CompanyId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }



    }
}