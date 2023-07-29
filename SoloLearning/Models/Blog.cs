using System.ComponentModel.DataAnnotations;

namespace SoloLearning.Models;

    public class Blog
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;

    // fk
    public string ApiUserId { get; set; }
    public ApiUser ApiUser { get; set; }


}

    