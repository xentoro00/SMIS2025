using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SMIS2025.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
