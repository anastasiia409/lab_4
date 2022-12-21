using System.ComponentModel.DataAnnotations;

namespace lab_4.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Salary { get; set; }
    }
}
