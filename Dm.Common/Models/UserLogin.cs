using System.ComponentModel.DataAnnotations;

namespace Dm.Common.Models
{
    public class UserLogin
    {
       
        public int UserID { get; set; }

        public int roleId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
       
        public string UserName { get; set; }
    }
}
