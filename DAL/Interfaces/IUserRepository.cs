using DAL.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> FindAllWithDetails();

        Task<User> GetByIdWithDetailsAsync(int id);
    }
}