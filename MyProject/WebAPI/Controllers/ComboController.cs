using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ComboController : BaseApiController
    {
        private readonly IComboRepository _comboRepository;
        private readonly IMapper _mapper;

        public ComboController(IComboRepository comboRepository, IMapper mapper)
        {
            _comboRepository = comboRepository;
            _mapper = mapper;
        }

        [HttpGet("GetZoneByCityId")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> GetZoneByCity(int cityId)
        {
            var zonefromRepo = await _comboRepository.GetZoneByCity(cityId);
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(zonefromRepo));
        }

        [HttpGet("Test")]
        public async Task<ActionResult<IEnumerable<StateCity>>> GetStateCity()
        {
            var zonefromRepo = await _comboRepository.GetStateCity();

            List<StateForCreateDto> parentMenu = new List<StateForCreateDto>();

            List<CityForCreateDto> childMenu = new List<CityForCreateDto>();

            List<StateDto> obj = new List<StateDto>();

            StateDto stateDto = new StateDto();

            for (var i=0; i< zonefromRepo.Count;i++)
            {
                CityDto cityDto = new CityDto();

                cityDto.Name = zonefromRepo[i].StateName;

                if (i==0)
                {
                    stateDto.State = zonefromRepo[i].StateName;
                }
                else
                {
                    //if ()
                }

            }

            foreach (var menu in zonefromRepo)
            {


                 parentMenu.Add(_mapper.Map<StateForCreateDto>(menu));

                childMenu.Add(_mapper.Map<CityForCreateDto>(menu));

            }


            return Ok(zonefromRepo);
        }
    }
}
