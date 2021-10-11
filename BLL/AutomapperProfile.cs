using AutoMapper;
using BLL.Models;
using DAL.Models;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<MessageSendModel, Message>();
            CreateMap<Message, MessageModel>();
            CreateMap<TopicModel, Topic>();
            CreateMap<TopicAddModel, Topic>();
            CreateMap<Topic, TopicModel>();
        }
    }
}
