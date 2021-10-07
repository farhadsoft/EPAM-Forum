using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using DAL;

namespace Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> dbSet;

        public BaseRepository(ForumDbContext context)
        {
            dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.RemoveRange(entity);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                await Task.Run(() => Delete(entity));
            }
        }

        public IQueryable<TEntity> FindAll()
        {
            return dbSet;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }
    }
}
