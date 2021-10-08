using AutoMapper;
using BLL.Models;
using DAL.Models;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UserModel, User>();
                //.ForMember(um => um.Id, u => u.MapFrom(r => r.Id))
                //.ForMember(um => um.FullName, u => u.MapFrom(r => r.FullName))
                //.ForMember(um => um.Email, u => u.MapFrom(r => r.Email))
                //.ForMember(um => um.GroupId, u => u.MapFrom(r => r.GroupId))
                //.ReverseMap();
            CreateMap<User, UserModel>();
            CreateMap<TopicModel, Topic>();
            CreateMap<Topic, TopicModel>();
        }
    }
}
