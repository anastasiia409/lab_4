using System.ComponentModel.DataAnnotations;

namespace lab_4.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfStart { get; set; } = null;
        public DateTime? DateOfEnd { get; set; } = null;
        public string Description { get; set; } = null!;
    }
}
