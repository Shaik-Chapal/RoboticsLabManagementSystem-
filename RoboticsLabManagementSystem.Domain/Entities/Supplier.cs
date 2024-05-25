﻿namespace RoboticsLabManagementSystem.Domain.Entities
{
    using System;

    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public string Name { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; }
       

       
        
    }

}
