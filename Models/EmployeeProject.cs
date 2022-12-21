using System.ComponentModel.DataAnnotations;

namespace lab_4.Models
{
    public class EmployeeProject
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public int ProjectId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public Employee Employee { get; set; } = null!;
        public Project Project { get; set; } = null!;
        public Position Position { get; set; } = null!;
    }
}
