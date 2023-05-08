using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IRightsDistributionRepository
    {
        Task<RightsDistribution> GetRightsDistributionForMenuAsync(int menuId, int roleId);
        Task<bool> Add(RightsDistributionForCreateDto rightsDistributionForCreateDto, int userId);
    }
}
