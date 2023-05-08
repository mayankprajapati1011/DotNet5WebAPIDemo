using BusinessLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IRepository
{
    public interface IStateRepository
    {
        Task<State> AddAsync(State state, int userId);
        Task<State> GetByIdAsync(int Id);
        Task<IEnumerable<State>> GetAllAsync();
        Task<bool> DeleteAsync(State state);
        Task<bool> StateExistsAsync(int stateId,string stateName);
        Task<IEnumerable<State>> ComboAsync();
    }
}
