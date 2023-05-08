using BusinessLayer.Data;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
   public class RightsDistributionRepository : IRightsDistributionRepository , IDisposable
    {
        private DataContext _context;

        public RightsDistributionRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<RightsDistribution> GetRightsDistributionForMenuAsync(int menuId, int roleId)
        {
            return await _context.RightsDistributions.SingleOrDefaultAsync(x => x.ChildMenuId == menuId && x.RoleId == roleId);
        }

        public async Task<bool> Add(RightsDistributionForCreateDto rightsDistibutionForCreateDto, int userId)
        {
            RightsDistribution[] rightsDistributions = new RightsDistribution[rightsDistibutionForCreateDto.Permission.Count];

            for (int i = 0; i < rightsDistributions.Length; i++)
            {
               
                RightsDistribution rightsDistribution = new RightsDistribution();

                rightsDistribution.Id = 0;
                rightsDistribution.RoleId = rightsDistibutionForCreateDto.RoleId;
                rightsDistribution.ChildMenuId = rightsDistibutionForCreateDto.Permission[i].ChildMenuId;
                rightsDistribution.AllowView = rightsDistibutionForCreateDto.Permission[i].AllowView;
                rightsDistribution.AllowAdd = rightsDistibutionForCreateDto.Permission[i].AllowAdd;
                rightsDistribution.AllowUpdate = rightsDistibutionForCreateDto.Permission[i].AllowUpdate;
                rightsDistribution.AllowDelete = rightsDistibutionForCreateDto.Permission[i].AllowDelete;
                rightsDistribution.AllowPrint = rightsDistibutionForCreateDto.Permission[i].AllowPrint;
                
                rightsDistributions[i] = rightsDistribution;
            }

            var rightsDistributionDeletes = _context.RightsDistributions
                     .Where(x => x.RoleId == rightsDistibutionForCreateDto.RoleId).ToList();

            foreach (var rightsDistributionDelete in rightsDistributionDeletes)
            {
                _context.RightsDistributions.Remove(rightsDistributionDelete);
            }
            await _context.SaveChangesAsync();

            foreach (RightsDistribution rightsDistributionList in rightsDistributions)
            {
                await _context.RightsDistributions.AddAsync(rightsDistributionList);
                await _context.SaveChangesAsync();
            }

            return true;
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
