using System;

namespace BLL.Models
{
    public class TopicModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string TopicText { get; set; }

        public DateTime CreateDate { get; set; }

        public int GreaterId { get; set; }

        public int GroupId { get; set; }
    }
}
