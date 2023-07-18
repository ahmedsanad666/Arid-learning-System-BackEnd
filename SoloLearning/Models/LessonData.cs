using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace SoloLearning.Models;

public class Lesson
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public bool Active { get; set; }
    [Required]
    public int Index { get; set; }
    [NotMapped]
    public List<Slide> Slides { get; set; }

    //FK
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public int ChapterId { get; set; }
    public CourseChapter CourseChapter { get; set; }
    

}

public class Slide
{
    [Key]
    public int Id { get; set; }
    public string customId { get; set; }
    [Required]
    public string Content { get; set; }
    [NotMapped]
    public List<Question> Questions { get; set; }

    //fk
    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}
public class Question
{
    [Key]
    public int Id { get; set; }
    public string QuestionText { get; set; }
    [NotMapped]
    public ICollection<string> Choices { get; set; }
    public string ChoicesString
    {
        get { return string.Join(",", Choices); }
        set { Choices = value.Split(',').ToList(); }
    }
    public int Answer { get; set; }
    public int Point { get; set; }
    //fk
    public string SlideId { get; set; }
    //public Slide Slide { get; set; }
}