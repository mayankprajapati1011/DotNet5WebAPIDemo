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
    public class StateRepository : IStateRepository, IDisposable
    {
        private DataContext _context;
        public StateRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<State> AddAsync(State state, int userId)
        {
            if (state.Id == 0)
            {
                state.CreatedBy = userId;
                state.CreatedDate = DateTime.Now;
                await _context.States.AddAsync(state);
            }
            else
            {
                var stateFromRepo = _context.States.AsNoTracking().SingleOrDefault(x => x.Id == state.Id);

                if (stateFromRepo != null)
                {
                    state.CreatedBy = stateFromRepo.CreatedBy;
                    state.CreatedDate = stateFromRepo.CreatedDate;
                }

                state.ModifiedBy = userId;
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);
            }

            await _context.SaveChangesAsync();
            return state;
        }
        public async Task<IEnumerable<State>> ComboAsync()
        {
            return await _context.States.ToListAsync();
        }
        public async Task<bool> DeleteAsync(State state)
        {
            _context.States.Remove(state);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _context.States.Include(s => s.Country).ToListAsync();
        }
        public async Task<State> GetByIdAsync(int stateId)
        {
            return await _context.States.SingleOrDefaultAsync(r => r.Id == stateId);
        }
        public async Task<bool> StateExistsAsync(int stateId, string stateName)
        {
            return await _context.States.AnyAsync(x => x.Name == stateName && x.Id != stateId);
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
