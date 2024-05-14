namespace RoboticsLabManagementSystem.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string CurrentAddress { get; set; }

        public string Department { get; set; }
        public string Designation { get; set; }

        public string Session { get; set; }

        public string IdNumber { get; set; }
        public string JoinDate { get; set; }
        
    }

}
