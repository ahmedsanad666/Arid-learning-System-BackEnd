using System.ComponentModel.DataAnnotations;

namespace SoloLearning.Models
{
    public class CourseChapter
    {
        [Key]
      public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Index { get; set; }

        public bool IsHidden { get; set; }
        
       public int CourseId { get; set; }
        public Course Course { get; set; }
        
    }
}
