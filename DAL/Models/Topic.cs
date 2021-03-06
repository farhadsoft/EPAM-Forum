using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string TopicText { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
