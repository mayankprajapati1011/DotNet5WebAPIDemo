using BusinessLayer.Data;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class CityRepository : ICityRepository, IDisposable
    {
        private DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<City> AddAsync(City city, int userId)
        {

         var ff =   _context.GetType().GetProperties();



                if (city.Id == 0)
                {
                    city.CreatedBy = userId;
                    city.CreatedDate = DateTime.Now;
                    await _context.Cities.AddAsync(city);
                }
                else
                {
                    var cityFromRepo = _context.Cities.AsNoTracking().SingleOrDefault(x => x.Id == city.Id);

                    if (cityFromRepo != null)
                    {
                        city.CreatedBy = cityFromRepo.CreatedBy;
                        city.CreatedDate = cityFromRepo.CreatedDate;
                    }

                    city.ModifiedBy = userId;
                    city.ModifiedDate = DateTime.Now;
                    _context.Cities.Update(city);
                }

            await _context.SaveChangesAsync();
            return city;
        }
        public async Task<IEnumerable<City>> ComboAsync()
        {
            return await _context.Cities.ToListAsync();
        }
        public async Task<bool> DeleteAsync(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<City>> GetAllAsync()
        {
            return await _context.Cities.Include(c => c.State).ToListAsync();

        }
        public async Task<City> GetByIdAsync(int cityId, CancellationToken cancellationToken)
        {
            return await _context.Cities.Include(c => c.State).SingleOrDefaultAsync(r => r.Id == cityId,cancellationToken);
        }
        public async Task<bool> CityExistsAsync(int cityId, string cityName)
        {
            using (var f = new City())
            {
               
            };
            
            return await _context.Cities.AnyAsync(x => x.Name == cityName && x.Id != cityId);
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
