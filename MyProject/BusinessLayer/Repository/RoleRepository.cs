using BusinessLayer.Data;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Role> AddAsync(Role role, int userId)
        {
            if (role.Id == 0)
            {
                role.CreatedBy = userId;
                role.CreatedDate = DateTime.Now;
                await _context.Roles.AddAsync(role);
            }
            else
            {
               // var roleFromRepo = _context.Roles.SingleOrDefault(x => x.Id == role.Id);

               // if (roleFromRepo != null)
                {
                    role.CreatedBy = userId;
                    role.CreatedDate = DateTime.Now;
                }

                role.ModifiedBy = userId;
                role.ModifiedDate = DateTime.Now;
                _context.Roles.Update(role);
            }

            await _context.SaveChangesAsync();
            return role;
        }
        public async Task<IEnumerable<Role>> ComboAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<bool> DeleteAsync(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetByIdAsync(int roleId)
        {
            return await _context.Roles.SingleOrDefaultAsync(r => r.Id == roleId);
        }
        public async Task<bool> RoleExistsAsync(int roleId, string roleName)
        {
            return await _context.Roles.AnyAsync(x => x.Name == roleName && x.Id != roleId);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;
            _context.Dispose();
            _context = null;

        }
    }
}
