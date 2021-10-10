namespace BLL.Models
{
    public class MessageModel
    {
        public string Title { get; set; }

        public string MessageText { get; set; }

        public string Sender { get; set; }
    }

    public class MessageSendModel
    {
        public string Title { get; set; }

        public string MessageText { get; set; }

        public string Receiver { get; set; }

    }
}
