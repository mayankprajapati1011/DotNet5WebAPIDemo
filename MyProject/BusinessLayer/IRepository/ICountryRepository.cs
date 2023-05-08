using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface ICountryRepository
    {
        Task<Country> AddAsync(Country country, int userId);
        Task<Country> GetByIdAsync(int Id);
        Task<IEnumerable<Country>> GetAllAsync();
        Task<bool> DeleteAsync(Country country);
        Task<bool> CountryExistsAsync(int countryId,string countryName);
        Task<IEnumerable<Country>> ComboAsync();
    }
}
