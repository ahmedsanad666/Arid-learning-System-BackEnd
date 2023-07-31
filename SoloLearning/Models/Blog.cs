using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloLearning.Models;

    public class Blog
    {
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [NotMapped]
    public IFormFile Files { get; set; }
    [NotMapped]
    public byte[] ImgByte { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;

    // fk
    public string ApiUserId { get; set; }
    public ApiUser ApiUser { get; set; }


}

    