using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<TopicModel> GetAll();

        Task<TopicModel> GetByIdAsync(int id);

        Task AddAsync(TopicModel topicModel);

        Task UpdateAsync(TopicModel topicModel);

        Task DeleteByIdAsync(int id);
    }
}
