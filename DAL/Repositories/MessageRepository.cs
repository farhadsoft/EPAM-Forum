using DAL.Interfaces;
using DAL.Models;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL.Repositories
{
    public class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        private readonly DbSet<Message> dbSet;
        public MessageRepository(ForumDbContext context) : base(context)
        {
            dbSet = context.Set<Message>();
        }
        public IQueryable<Message> FindAllByUserId(Guid userId)
        {
            return dbSet.AsNoTracking();
        }
    }
}
