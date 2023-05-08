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
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Country> AddAsync(Country state, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Country>> ComboAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public Task<bool> CountryExistsAsync(int countryId, string countryName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Country country)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Country>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Country> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
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
