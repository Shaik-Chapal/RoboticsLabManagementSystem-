﻿using RoboticsLabManagementSystem.Domain.Entities;
using RoboticsLabManagementSystem.Domain.Entities.Company;
using RoboticsLabManagementSystem.Infrastructure.DataSeeder;
using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoboticsLabManagementSystem.Insfastructure.DataSeeder;
using ChatAppServer.WebAPI.Models;
using RoboticsLabManagementSystem.Insfastructure.Extensions;

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

            modelBuilder.SetDefaultSchema("skygreen");



            modelBuilder.Entity<ApplicationUser>().HasData(UserSeed.Users());
            modelBuilder.Entity<User>().HasData(UserDataSeed.Users());
            modelBuilder.Entity<ApplicationUserClaim>().HasData(UserClaimSeed.Claims());
            modelBuilder.Entity<Company>().HasData(CompanySeed.Claims());
            modelBuilder.Entity<Supplier>().HasData(SupplierSeed.GetSeedData());
            modelBuilder.Entity<Holiday>().HasData(HolidaySeed.GetSeedData());
            modelBuilder.Entity<Branch>().HasData(BranchSeed.GetSeedData());
            modelBuilder.Entity<Group>().HasData(GroupModelSeed.GetSeedData());

            modelBuilder.Entity<Research>().HasData(
                ResearchSeed.GetSeedData()
            );

            // Seed Blog
            modelBuilder.Entity<Blog>().HasData(
                BlogSeed.GetSeedData()
            );

            // Seed FeaturedContent
            modelBuilder.Entity<FeaturedContent>().HasData(
                FeaturedContentSeed.GetSeedData()
            );
            modelBuilder.Entity<PurchaseOrder>()
               .Property(p => p.Price)
               .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<FeaturedContent>()
          .HasKey(f => f.ContentId);
            //Add-Migration InitialCreate123
            modelBuilder.Entity<Company>()
                .HasMany(x => x.Branches)
                .WithOne(y => y.Company)
                .HasForeignKey(y => y.CompanyId);

            modelBuilder.Entity<PurchaseOrder>()
                .HasOne(p => p.Equipment)
                .WithMany(e => e.PurchaseOrders)
                .HasForeignKey(p => p.EquipmentId);


            modelBuilder.Entity<EquipmentLog>()
                .HasMany(e => e.Items)
                .WithOne(i => i.EquipmentLog)
                .HasForeignKey(i => i.EquipmentLogId);

            modelBuilder.Entity<EquipmentLogItem>()
                .HasKey(e => e.Id);

          
            modelBuilder.Entity<ResearchResult>()
               .HasOne(rr => rr.User)
               .WithMany(u => u.ResearchResults)
               .HasForeignKey(rr => rr.UserId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ResearchResult>()
              .HasKey(e => e.Id);

            modelBuilder.Entity<Message>()
          .HasOne(m => m.Sender)
          .WithMany(u => u.SentMessages)
          .HasForeignKey(m => m.SenderId)
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<EquipmentLog> EquipmentLogs { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<EquipmentLogItem> EquipmentLogItems { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Research> Researches { get; set; }
        public DbSet<FeaturedContent> FeaturedContents { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Threshold> Thresholds { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<ResearchResult> ResearchResults { get; set; }
        public DbSet<Group> Groups { get; set; }
      
        public DbSet<Chat> Chats { get; set; }

    }
}