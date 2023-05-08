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
    public class RolesController : BaseApiController
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RolesController(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        [HttpGet("Combo")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> Combo()
        {
            var rolesFromRepo = await _roleRepository.ComboAsync();
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(rolesFromRepo));
        }

        [HttpPost]
        public async Task<ActionResult<Role>> Create(RoleForCreateDto roleForCreate)
        {
            if (await _roleRepository.RoleExistsAsync(roleForCreate.Id, roleForCreate.Name))
            {
                return BadRequest("Role Name Already Exists");
            }
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            var rolefromRepo = await _roleRepository.AddAsync(_mapper.Map<Role>(roleForCreate), userId);
            return Ok(_mapper.Map<RoleForCreateDto>(rolefromRepo));
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<RoleForListDto>>> GetAll()
        {
            var rolesFromRepo = await _roleRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RoleForListDto>>(rolesFromRepo));
        }

        [HttpGet("{roleId}")]
        public async Task<ActionResult<RoleForCreateDto>> GetById(int roleId)
        {
            var rolesFromRepo = await _roleRepository.GetByIdAsync(roleId);
            return Ok(_mapper.Map<RoleForCreateDto>(rolesFromRepo));
        }

        [HttpDelete("{roleId}")]
        public async Task<ActionResult> Delete(int roleId)
        {
            var rolefromRepo = await _roleRepository.GetByIdAsync(roleId);

            if (rolefromRepo == null)
            {
                return NotFound();
            }

            await _roleRepository.DeleteAsync(rolefromRepo);
            return NoContent();
        }


    }
}
