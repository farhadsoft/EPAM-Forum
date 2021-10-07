using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class TopicsGroup
    {
        /// <summary>
        /// Topic Group Id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Title of Topic Group
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Topic Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Moderators of Topic
        /// </summary>
        public int Moderators { get; set; }

    }
}
