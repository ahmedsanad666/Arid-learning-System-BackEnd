using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SoloLearning.Models
{
    public class ApiUser : IdentityUser
    {
    
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public string Role { get; set; }

        public string Image { get; set; }


    }
}
