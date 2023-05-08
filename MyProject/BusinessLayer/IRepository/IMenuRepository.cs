using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IMenuRepository
    {
        public Task<IEnumerable<ChildMenu>> GetMenuForListAsync(int roleId, int applicationId);
        Task<IEnumerable<MenuForRightsDistributionDto>> GetForRightsAsync(int roleId);
    }
}
