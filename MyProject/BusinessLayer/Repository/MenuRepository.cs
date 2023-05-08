using BusinessLayer.Data;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private DataContext _context;

        public MenuRepository(DataContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<MenuForRightsDistributionDto>> GetForRightsAsync(int roleId)
        {
            return await(from mn in _context.ChildMenus
                         join pmn in _context.ParentMenus on mn.ParentMenuId equals pmn.Id
                         join rd in _context.RightsDistributions on new { Id = mn.Id, a = roleId } equals new { Id = rd.ChildMenuId, a = rd.RoleId } into r
                         from rdt in r.DefaultIfEmpty()
                         orderby pmn.Id
                         where mn.IsActive == true

                         select new MenuForRightsDistributionDto()
                         {
                             Id = mn.Id,
                             Name = mn.Name,
                             ParentMenuName = pmn.Name,
                             ParentMenuId = mn.ParentMenuId,
                             AllowView = rdt.AllowView ? true : false,
                             AllowAdd = rdt.AllowAdd ? true : false,
                             AllowUpdate = rdt.AllowUpdate ? true : false,
                             AllowDelete = rdt.AllowDelete ? true : false,
                             AllowPrint = rdt.AllowPrint ? true : false,
                         }).ToListAsync();
        }

        public async Task<IEnumerable<ChildMenu>> GetMenuForListAsync(int roleId, int applicationId)
        {
            //var menu = await _context.ChildMenus
            //    .Include(x => x.ParentMenu).OrderBy(x => x.ParentMenu.OrderCode).ThenBy(x => x.OrderCode)
            //    .Where(x => x.ApplicationId == applicationId
            //                    && x.RightsDistribution.Any(x => x.RoleId == roleId)
            //                && x.RightsDistribution.Any(x => x.AllowView == true)
            //                )
            //    .ToListAsync();

            var menu = await _context.ChildMenus
                .Include(x => x.ParentMenu).Where(x => x.ApplicationId == applicationId).OrderBy(x => x.ParentMenu.OrderCode).ThenBy(x => x.OrderCode)
                .Include(x => x.RightsDistribution.Where(x=> x.AllowView == true &&  x.RoleId == roleId)).ToListAsync();

            return menu;
        }
    }
}
