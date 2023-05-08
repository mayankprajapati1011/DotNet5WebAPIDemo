using BusinessLayer.Data;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class ComboRepository : IComboRepository, IDisposable
    {
        private DataContext _context;
        public ComboRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zone>> GetZoneByCity(int cityId)
        {
            return await _context.Zones.Where(x => x.CityId == cityId).ToListAsync();
        }

        public async Task<List<StateCity>> GetStateCity()
        {
            // return await _context.Cities.Include(c => c.State).ToListAsync();

            //return await (from mn in _context.ChildMenus
            //              join pmn in _context.ParentMenus on mn.ParentMenuId equals pmn.Id
            //              join rd in _context.RightsDistributions on new { Id = mn.Id, a = roleId } equals new { Id = rd.ChildMenuId, a = rd.RoleId } into r
            //              from rdt in r.DefaultIfEmpty()
            //              orderby pmn.Id
            //              where mn.IsActive == true

            //              select new MenuForRightsDistributionDto()
            //              {
            //                  Id = mn.Id,
            //                  Name = mn.Name,
            //                  ParentMenuName = pmn.Name,
            //                  ParentMenuId = mn.ParentMenuId,
            //                  AllowView = rdt.AllowView ? true : false,
            //                  AllowAdd = rdt.AllowAdd ? true : false,
            //                  AllowUpdate = rdt.AllowUpdate ? true : false,
            //                  AllowDelete = rdt.AllowDelete ? true : false,
            //                  AllowPrint = rdt.AllowPrint ? true : false,
            //              }).ToListAsync();

            return await (from c in _context.Cities
                          join s in _context.States on c.StateId equals s.Id
                          orderby s.Name , c.Name
                          select new StateCity()
                          {
                              StateName = s.Name,
                              CityName = c.Name
                          }).ToListAsync();

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
