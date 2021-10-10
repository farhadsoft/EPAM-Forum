using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string MessageText { get; set; }
        public DateTime CreateTime { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }
}
