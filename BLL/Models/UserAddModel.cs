using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public class UserAddModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
