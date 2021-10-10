using AutoMapper;
using BLL.Models;
using DAL.Models;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<MessageModel, Message>();
            CreateMap<Message, MessageModel>();
            CreateMap<TopicModel, Topic>();
            CreateMap<Topic, TopicModel>();
        }
    }
}
