using DAL.Interfaces;
using DAL.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        private readonly DbSet<Topic> dbSet;
        public TopicRepository(ForumDbContext context) : base(context)
        {
            dbSet = context.Set<Topic>();
        }
        public IQueryable<Topic> FindAllWithDetails()
        {
            return dbSet.Include(x => x.TopicsGroup).AsNoTracking();
        }

        public Task<Topic> GetByIdWithDetailsAsync(int id)
        {
            return FindAllWithDetails().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
