using AutoMapper;
using BusinessLayer.Common;
using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsersController(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpGet("Combo")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> ComboFill()
        {
            var usersFromRepo = await _userRepository.ComboAsync();
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(usersFromRepo));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> Create(UserForCreateDto userCreateDto)
        {


            var nameIdentifier = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

            int userId = !string.IsNullOrEmpty(nameIdentifier) ? Convert.ToInt32(nameIdentifier) : 0;

            if (await _userRepository.UserExistsAsync(userCreateDto.MobileNo, userCreateDto.Id))
            {
                return BadRequest("Mobile Number already exists");
            }

            var userFromRepo = await _userRepository.AddAsync(_mapper.Map<User>(userCreateDto), userCreateDto.Password, userId);

            return Created("", _mapper.Map<UserDto>(userFromRepo));
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginDto loginDto)
        {
            loginDto.UserName = loginDto.UserName.ToLower();

            var userFromRepo = await _userRepository.LoginAsync(loginDto.UserName, loginDto.Password);


            if (userFromRepo == null)
            {
                return Unauthorized();
            }

           

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(userFromRepo.Id)),
                new Claim(ClaimTypes.Name,userFromRepo.FullName),
                new Claim(ClaimTypes.MobilePhone,userFromRepo.MobileNo),
                new Claim(ClaimTypes.Role,Convert.ToString(userFromRepo.RoleId))

            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
                User = _mapper.Map<UserDto>(userFromRepo)
            });

        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetAll()
        {
            var userFromRepo = await _userRepository.GetAllAsync();

            if (userFromRepo == null)
            {
                NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UserDto>>(userFromRepo));
        }

        [HttpGet("{userid}")]
        public async Task<ActionResult<UserDto>> GetById(int userId)
        {
            var userFromRepo = await _userRepository.GetByIdAsync(userId);

            if (userFromRepo == null)
            {
                NotFound();
            }

            return Ok(_mapper.Map<UserDto>(userFromRepo));
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> Delete(int userId)
        {
            int v_userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            var userfromRepo = await _userRepository.GetByIdAsync(userId);

            if (userfromRepo == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(userfromRepo, v_userId);
            return NoContent();
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult<LoginResponseDto>> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty);
            string mobileNumber = User.FindFirst(ClaimTypes.MobilePhone)?.Value ?? string.Empty;

            var userFromRepo = await _userRepository.LoginAsync(mobileNumber, changePasswordDto.OldPassword);

            if (userFromRepo == null)
            {
                return Unauthorized("Your old Password is Incorrect");
            }

            await _userRepository.ChangePasswordAsync(userFromRepo, changePasswordDto.NewPassword, userId);

            return Ok("Password Change Successfully");

        }

        [HttpGet("GetAllByRoleId")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> GetAllUsersByRole(byte roleId)
        {
            var usersFromRepo = await _userRepository.GetUserByRoleIdAsync(roleId);
            return Ok(_mapper.Map<IEnumerable<ComboDto>>(usersFromRepo));
        }
    }
}
