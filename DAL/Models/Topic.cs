using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(User))]
        public int GreaterId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(TopicsGroup))]
        public int GroupId { get; set; }

        public TopicsGroup TopicsGroup { get; set; }

    }
}
