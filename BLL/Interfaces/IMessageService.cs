using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<MessageModel> GetAll();

        Task<MessageModel> GetByIdAsync(int id);

        Task AddAsync(MessageModel messageModel);

        Task UpdateAsync(MessageModel messageModel);

        Task DeleteByIdAsync(int id);
    }
}
