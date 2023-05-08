using AutoMapper;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class RightsDistributionController : BaseApiController
    {
        private readonly IRightsDistributionRepository _rightsDistributionRepository;
        private readonly IMapper _mapper;

        public RightsDistributionController(IRightsDistributionRepository rightsDistributionRepository, IMapper mapper)
        {
            _rightsDistributionRepository = rightsDistributionRepository;
            _mapper = mapper;
        }

        [HttpGet("GetRightsDistributionForMenu/{menuId}")]
        public async Task<IActionResult> GetRightsDistributionForMenu(int menuId)
        {
            var roleId = byte.Parse(User.FindFirst(ClaimTypes.Role)?.Value ?? "0");

            var resultFromRepo = await _rightsDistributionRepository.GetRightsDistributionForMenuAsync(menuId, roleId);

            return Ok(_mapper.Map<RightDistributionPermissionDto>(resultFromRepo));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRightsDistributionForMenu(RightsDistributionForCreateDto rightsDistibutionForCreateDto)
        {

            int userId = short.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            await _rightsDistributionRepository.Add(rightsDistibutionForCreateDto, userId);

            return Ok("Rights Distribution Saved Successfully");


        }
    }
}
