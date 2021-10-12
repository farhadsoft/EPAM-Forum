using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> RegisterAsync(UserAddModel user);
        Task<UserModel> LoginAsync(UserLoginModel user);
        Task<UserModel> RoleChangeAsync(RoleModel roleModel);
    }
}