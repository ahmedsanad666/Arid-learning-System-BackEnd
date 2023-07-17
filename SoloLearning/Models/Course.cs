using System.ComponentModel.DataAnnotations;

namespace SoloLearning.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set;}
        public bool   IsActive { get; set; }
        public bool IsFeatured { get; set; }
    }
}
