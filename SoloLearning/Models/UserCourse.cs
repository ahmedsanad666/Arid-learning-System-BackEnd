using Microsoft.EntityFrameworkCore.Query;

namespace SoloLearning.Models
{
    public class UserCourse
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CoursePoints { get; set; }
        public int UserPoints { get; set; }
        public DateTime StartedDate { get; set; } = DateTime.Now;
        public int LastLesson { get; set; } = 1;
        // FK
        public int CourseId { get; set; }
        public Course Course { get; set;}
    }
}
