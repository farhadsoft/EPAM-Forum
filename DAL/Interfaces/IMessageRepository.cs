using DAL.Models;
using System;
using System.Linq;

namespace DAL.Interfaces
{
    public interface IMessageRepository : IRepository<Message>
    {
        IQueryable<Message> FindAllByUserId(Guid userId);
    }
}