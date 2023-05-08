using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class StatesController : BaseApiController
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public StatesController(IStateRepository stateRepository, IMapper mapper)
        {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        [HttpGet("Combo")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> Combo()
        {
            var statesFromRepo = await _stateRepository.ComboAsync();
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(statesFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult<State>> Create(StateForCreateDto stateForCreate)
        {
            if (await _stateRepository.StateExistsAsync(stateForCreate.Id, stateForCreate.Name))
            {
                return BadRequest("State Name Already Exists");
            }
            int userId =int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            var statefromRepo = await _stateRepository.AddAsync(_mapper.Map<State>(stateForCreate), userId);
            return Ok(_mapper.Map<StateForCreateDto>(statefromRepo));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<StateForListDto>>> GetAll()
        {
            var statesFromRepo = await _stateRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<StateForListDto>>(statesFromRepo));
        }

        [HttpGet("{stateId}")]
        public async Task<ActionResult<StateForCreateDto>> GetById(int stateId)
        {
            var statesFromRepo = await _stateRepository.GetByIdAsync(stateId);
            return Ok(_mapper.Map<StateForCreateDto>(statesFromRepo));
        }

        [HttpDelete("{stateId}")]
        public async Task<ActionResult> Delete(int stateId)
        {
            var statefromRepo = await _stateRepository.GetByIdAsync(stateId);

            if (statefromRepo == null)
            {
                return NotFound();
            }

            await _stateRepository.DeleteAsync(statefromRepo);
            return NoContent();
        }


    }
}
