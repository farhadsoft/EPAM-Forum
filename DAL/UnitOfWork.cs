using DAL.Interfaces;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForumDbContext context;

        public UnitOfWork(ForumDbContext context)
        {
            this.context = context;
        }
        public IUserRepository UserRepository => throw new NotImplementedException();

        public ITopicRepository TopicRepository => throw new NotImplementedException();

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
