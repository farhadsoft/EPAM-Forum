using DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        IQueryable<Message> FindAllWithDetails();

        Task<Message> GetByIdWithDetailsAsync(int id);
    }
}
