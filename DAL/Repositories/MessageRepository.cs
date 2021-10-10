using DAL.Interfaces;
using DAL.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly DbSet<Message> dbSet;
        public MessageRepository(ForumDbContext context) : base(context)
        {
            dbSet = context.Set<Message>();
        }
        public IQueryable<Message> FindAllWithDetails()
        {
            return dbSet.AsNoTracking();
        }

        public Task<Message> GetByIdWithDetailsAsync(int id)
        {
            return FindAllWithDetails().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
