namespace RoboticsLabManagementSystem.Domain.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

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
        public ICollection<ResearchResult> ResearchResults { get; set; }

    }

    public class ResearchResult
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Introduction { get; set; }
        public string Abstract { get; set; }
        public string Methodology { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string Conclusion { get; set; }
       

        // Foreign key
        public Guid UserId { get; set; }


        [JsonIgnore]
        public User User { get; set; }
    }
    public class ResearchResultModel
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Introduction { get; set; }
        public string Abstract { get; set; }
        public string Methodology { get; set; }
        public string Description { get; set; }
        public string Result { get; set; }
        public string Conclusion { get; set; }

        // Foreign key
        public Guid UserId { get; set; }

    }


}
