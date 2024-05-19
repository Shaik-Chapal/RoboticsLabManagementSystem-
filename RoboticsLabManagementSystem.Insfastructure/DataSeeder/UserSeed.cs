using RoboticsLabManagementSystem.Infrastructure.Features.Membership;
using Microsoft.AspNetCore.Identity;
using RoboticsLabManagementSystem.Domain.Entities;

namespace RoboticsLabManagementSystem.Infrastructure.DataSeeder
{
    public static class UserSeed
    {
        public static IList<ApplicationUser> Users()
        {
            var passHasher = new PasswordHasher<ApplicationUser>();
            var admin = new ApplicationUser()
            {
                Id = new Guid("17FA016F-AE8B-4044-80E3-ABD54DFE392F"),
                UserName = "admin",
                PhoneNumber = "1234567890",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = "BFCC7B453A8B4B6C8A4C93EE28A3B4A8"
            };

            admin.PasswordHash = passHasher.HashPassword(admin, "#s1234");
            var teacher = new ApplicationUser()
            {
                Id = new Guid("8FD9FC20-5382-4F44-88FD-C78993A1D8E5"),
                UserName = "Teacher",
                PhoneNumber = "1234567890",
                NormalizedUserName = "Teacher",
                Email = "Teacher@gmail.com",
                NormalizedEmail = "Teacher@GMAIL.COM",
                EmailConfirmed = true,
                LockoutEnabled = true,
                SecurityStamp = "FC37C84E276C4D978DF9054129D0CB23",
            };
            teacher.PasswordHash = passHasher.HashPassword(teacher, "#s12345");
            var users = new List<ApplicationUser>() { admin, teacher };
            return users;
        }
    }
    public static class UserDataSeed
    {
        public static IList<User> Users()
        {
            var admin = new User()
            {
                Id = new Guid("17FA016F-AE8B-4044-80E3-ABD54DFE392F"),
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@gmail.com",
                Password = "admin123",
                PhoneNumber = "1234567890",
                CurrentAddress = "Admin Address",
                Department = "Admin Department",
                Designation = "Admin",
                Session = "Admin Session",
                IdNumber = "Admin ID",
                JoinDate = DateTime.UtcNow.ToString()
            };

            var manager = new User()
            {
                Id = new Guid("8FD9FC20-5382-4F44-88FD-C78993A1D8E5"),
                FirstName = "Manager",
                LastName = "Manager",
                Email = "manager@gmail.com",
                Password = "manager123",
                PhoneNumber = "1234567890",
                CurrentAddress = "Manager Address",
                Department = "Manager Department",
                Designation = "Manager",
                Session = "Manager Session",
                IdNumber = "Manager ID",
                JoinDate = DateTime.UtcNow.ToString() 
            };

            var users = new List<User>() { admin, manager };
            return users;
        }
    }

}