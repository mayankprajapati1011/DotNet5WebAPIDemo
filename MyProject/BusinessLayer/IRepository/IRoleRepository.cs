using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IRoleRepository
    {
        Task<Role> AddAsync(Role role, int userId);
        Task<Role> GetByIdAsync(int roleId);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<bool> DeleteAsync(Role role);
        Task<bool> RoleExistsAsync(int roleId,string roleName);
        Task<IEnumerable<Role>> ComboAsync();
    }
}
