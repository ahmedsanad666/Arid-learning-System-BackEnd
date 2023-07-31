using System.ComponentModel.DataAnnotations.Schema;

namespace SoloLearning.Models
{
    public class AppUser
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string userName { get; set; }
        [NotMapped]
        public IFormFile Files { get; set; }
        [NotMapped]
        public byte[] ImgByte { get; set; }
        public string Role { get; set; }

    }
}
