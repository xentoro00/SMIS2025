﻿using System.ComponentModel.DataAnnotations;

namespace SMIS2025.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double ETCs { get; set; }

        public int? DepartmentId { get; set; }

        [Required]
        public string Category { get; set; }

        // Navigation property to connect to the Department
        public Department? Department { get; set; }
    }

}
