using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class MenusController : BaseApiController
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenusController(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        [HttpGet("GetMenuForList/{applicationId}")]
        public async Task<ActionResult<IEnumerable<MenuForListDto>>> GetMenuForList(int applicationId)
        {
            var roleId = Convert.ToByte(User.FindFirst(ClaimTypes.Role)?.Value);

            var menusFromRepo = await _menuRepository.GetMenuForListAsync(roleId, applicationId);

            List<ParentMenuDto> parentMenu = new List<ParentMenuDto>();

            List<MenuDto> childMenu = new List<MenuDto>();

            foreach (var menu in menusFromRepo)
            {
                parentMenu.Add(_mapper.Map<ParentMenuDto>(menu.ParentMenu));

                childMenu.Add(_mapper.Map<MenuDto>(menu));
            }

            var menuForList = new MenuForListDto()
            {
                ParentMenu = parentMenu.GroupBy(x => x.Id).Select(c => c.FirstOrDefault()).ToList(),
                ChildMenu = childMenu
            };

            return Ok(menuForList);


        }


        [HttpGet("GetForRightsDistribution/{roleId}")]
        public async Task<ActionResult<IEnumerable<MenuForRightsDistributionDto>>> GetForRights(int roleId)
        {
            var menuFromRepo = await _menuRepository.GetForRightsAsync(roleId);

            return Ok(_mapper.Map<IEnumerable<MenuForRightsDistributionDto>>(menuFromRepo));
        }
    }
}
