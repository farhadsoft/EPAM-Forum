using BLL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserModel> GetAll();

        Task<UserModel> GetByIdAsync(int id);

        Task AddAsync(UserModel userModel);

        Task UpdateAsync(UserModel userModel);

        Task DeleteByIdAsync(int id);
    }
}