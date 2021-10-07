using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        ITopicRepository TopicRepository { get; }

        Task<int> SaveAsync();
    }
}
