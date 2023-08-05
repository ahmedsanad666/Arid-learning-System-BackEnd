using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoloLearning.Models
{
    public class ApiUser : IdentityUser
    {
    
        public string ArName { get; set; }
        public string EnName { get; set; }

        [NotMapped]
        public string Password { get; set; }
      
        //public string Role { get; set; }



    }
}
