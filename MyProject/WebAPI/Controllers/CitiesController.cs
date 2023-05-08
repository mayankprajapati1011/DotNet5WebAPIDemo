using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CitiesController : BaseApiController
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
       
        [HttpGet("Combo")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> Combo()
        {
            var cityFromRepo = await _cityRepository.ComboAsync();
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(cityFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult<City>> Create(CityForCreateDto cityForCreate)
        {
            //if (await _cityRepository.CityExistsAsync(cityForCreate.Id, cityForCreate.Name))
            //{
              //  return BadRequest("City Name Already Exists");
            //}
            //int userId =int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            var cityfromRepo = await _cityRepository.AddAsync(_mapper.Map<City>(cityForCreate), 1);
            return Ok(_mapper.Map<CityForCreateDto>(cityfromRepo));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CityForListDto>>> GetAll()
        {
            var cityFromRepo = await _cityRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CityForListDto>>(cityFromRepo));
        }

        [HttpGet("{cityId}")]
        public async Task<ActionResult<CityForCreateDto>> GetById(int cityId, CancellationToken cancellationToken)
        {
            await Task.Delay(10000, cancellationToken);

            var cityFromRepo = await _cityRepository.GetByIdAsync(cityId,cancellationToken);
            return Ok(_mapper.Map<CityForCreateDto>(cityFromRepo));
        }

        [HttpDelete("{cityId}")]
        public async Task<ActionResult> Delete(int cityId, CancellationToken cancellationToken)
        {
            var cityfromRepo = await _cityRepository.GetByIdAsync(cityId,cancellationToken);

            if (cityfromRepo == null)
            {
                return NotFound();
            }

            await _cityRepository.DeleteAsync(cityfromRepo);
            return NoContent();
        }

    }
}
