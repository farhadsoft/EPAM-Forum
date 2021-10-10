using DAL.Interfaces;
using DAL.Repositories;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForumDbContext context;
        private MessageRepository messageRepository;
        private TopicRepository topicRepository;

        public UnitOfWork(ForumDbContext context)
        {
            this.context = context;
        }
        public IMessageRepository MessageRepository => messageRepository ??= new MessageRepository(context);

        public ITopicRepository TopicRepository => topicRepository ??= new TopicRepository(context);

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
