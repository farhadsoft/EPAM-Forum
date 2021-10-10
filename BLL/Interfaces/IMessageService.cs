using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<MessageModel> GetAll(string userEmail);

        Task<MessageModel> GetByIdAsync(int id);

        Task AddAsync(MessageSendModel message, string userEmail);

        Task DeleteByIdAsync(int id);
    }
}
