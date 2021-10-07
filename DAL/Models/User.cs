using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        [Required]
        [ForeignKey(nameof(UsersGroup))]
        public int GroupId { get; set; }

        public UsersGroup UsersGroup { get; set; }

    }
}
