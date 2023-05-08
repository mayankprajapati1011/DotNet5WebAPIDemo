using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ComboAsync();
        Task<User> LoginAsync(string userName, string password);
        Task<User> AddAsync(User user, string password, int userId);
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<bool> Delete(User user, int userId);
        Task<IEnumerable<User>> GetUserByRoleIdAsync(int roleId);
        Task<bool> UserExistsAsync(string userName, int userId);
        Task<bool> ChangePasswordAsync(User user, string newPassword, int userId);
       
    }
}
