using System.ComponentModel.DataAnnotations;

namespace lab_4.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string Description { get; set; } = null!;
    }
}
