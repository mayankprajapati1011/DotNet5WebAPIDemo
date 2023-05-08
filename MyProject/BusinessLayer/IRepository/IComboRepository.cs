using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
   public interface IComboRepository
    {
        Task<IEnumerable<Zone>> GetZoneByCity(int cityId);

        Task<List<StateCity>> GetStateCity();
    }
}
