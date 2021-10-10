using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TopicService : ITopicService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TopicService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddAsync(TopicModel topicModel)
        {
            var topic = mapper.Map<Topic>(topicModel);
            await unitOfWork.TopicRepository.AddAsync(topic);
            var result = await unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var isExist = await unitOfWork.TopicRepository.GetByIdAsync(id);

            if (isExist is not null)
            {
                await unitOfWork.TopicRepository.DeleteByIdAsync(id);
            }
            
        }

        public IEnumerable<TopicModel> GetAll()
        {
            var result = unitOfWork.TopicRepository.FindAll();
            return mapper.Map<IEnumerable<TopicModel>>(result);
        }

        public async Task<TopicModel> GetByIdAsync(int id)
        {
            var result = await unitOfWork.TopicRepository.GetByIdAsync(id);
            return mapper.Map<TopicModel>(result);
        }

        public async Task UpdateAsync(TopicModel topicModel)
        {
            var topic = mapper.Map<Topic>(topicModel);
            await Task.Run(() => unitOfWork.TopicRepository.Update(topic));
        }
    }
}
