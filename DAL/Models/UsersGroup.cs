using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class UsersGroup
    {
        [Key]
        public int GroupId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
