using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet("Combo")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> Combo()
        {
            var countriesFromRepo = await _countryRepository.ComboAsync();
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(countriesFromRepo));
        }
    }
}
