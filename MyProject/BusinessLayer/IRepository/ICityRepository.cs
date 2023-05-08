using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface ICityRepository
    {
        Task<City> AddAsync(City city, int userId);
        Task<City> GetByIdAsync(int Id,CancellationToken cancellationToken);
        Task<IEnumerable<City>> GetAllAsync();
        Task<bool> DeleteAsync(City city);
        Task<bool> CityExistsAsync(int cityId,string cityName);
        Task<IEnumerable<City>> ComboAsync();
    }
}
