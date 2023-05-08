using BusinessLayer.Data;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user, string password, int userId)
        {
            if (user.Id==0)
            {
                user.CreatedBy = userId;
                user.CreatedDate = DateTime.Now;
                CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _context.Users.AddAsync(user);
            }
            else
            {
                var userFromRepo = _context.Users.AsNoTracking().SingleOrDefault(x => x.Id == user.Id);

                if (userFromRepo != null)
                {
                    CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

                    user.PasswordHash = userFromRepo.PasswordHash;
                    user.PasswordSalt = userFromRepo.PasswordSalt;

                    //user.RoleId = 

                    user.CreatedBy = userFromRepo.CreatedBy;
                    user.CreatedDate = userFromRepo.CreatedDate;
                }

                user.ModifiedBy = userId;
                user.ModifiedDate = DateTime.Now;
                _context.Users.Update(user);
            }
            await _context.SaveChangesAsync();

            return await _context.Users.Include(r => r.Role).AsNoTracking().SingleOrDefaultAsync(u => u.Id == user.Id);
            //return user;
        }

        public async Task<bool> ChangePasswordAsync(User user, string newPassword, int userId)
        {
            CreatePasswordHash(newPassword, out var passwordHash, out var passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ModifiedBy = userId;
            user.ModifiedDate = DateTime.Now;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> ComboAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Delete(User user, int userId)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(r => r.Role).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
           return  await _context.Users.FirstAsync(a=> a.Id == id);
        }

        public async Task<IEnumerable<User>> GetUserByRoleIdAsync(int roleId)
        {
            return await _context.Users.Where(r=> r.RoleId == roleId).ToListAsync();
        }

        public  async Task<User> LoginAsync(string userName, string password)
        {
            var userFromRepo = await _context.Users.SingleOrDefaultAsync(x => x.MobileNo == userName);

            if (userFromRepo == null)
            {
                return null;
            }

            return !VerifyPasswordHash(password, userFromRepo.PasswordHash, userFromRepo.PasswordSalt) ? null : userFromRepo;
        }

        public async Task<bool> UserExistsAsync(string userName, int userId)
        {
            return await _context.Users.AnyAsync(x => x.MobileNo == userName && x.Id != userId);
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

        #region Function
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (passwordHash[i] != computedHash[i]) return false;
            }
            return true;
        }
        #endregion
    }
}
