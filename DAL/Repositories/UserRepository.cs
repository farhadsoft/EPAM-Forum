using DAL.Interfaces;
using DAL.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DbSet<User> dbSet;

        public UserRepository(ForumDbContext context) : base(context)
        {
            dbSet = context.Set<User>();
        }
        public IQueryable<User> FindAllWithDetails()
        {
            return dbSet.Include(x => x.UsersGroup);
        }

        public Task<User> GetByIdWithDetailsAsync(int id)
        {
            return FindAllWithDetails().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
