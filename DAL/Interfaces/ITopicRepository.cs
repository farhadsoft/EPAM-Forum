using DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>
    {
        IQueryable<Topic> FindAllWithDetails();

        Task<Topic> GetByIdWithDetailsAsync(int id);
    }
}