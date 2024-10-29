using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthonticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IBaseRepository<User> _repository;
        private readonly IRoleRepository _roleRepository;

        public AuthonticationController(IMapper mapper,
                                        IConfiguration configuration,
                                        IBaseRepository<User> repository,
                                        IRoleRepository roleRepository
            )
        {
            _mapper = mapper;
            _configuration = configuration;
            _repository = repository;
            _roleRepository = roleRepository;
        }

        // POST api/<AuthonticationController>
        [HttpPost("SignUp")]
        public async Task<ActionResult<string>> SignUp([FromBody] SignUpRequestDTO requestDTO)
        {
            if(!ModelState.IsValid) 
                return Unauthorized("UnCurrect Information");
            // Map UserDTO to User
            var user = _mapper.Map<User>(requestDTO);

            //Get the role then assign it for user:
            user.Role = await _roleRepository.GetByIdAsync(user.RoleId) ?? new Role();

            //If the requestDTO.Email is request already exists, we must handle the exception that will occur
            try
            {
                await _repository.AddAsync(user);
            }
            catch (Exception)
            {
                return Unauthorized("Email is already exist");
            }

            var token = Token(user);
            return token;
        }

        [HttpPost("LogIn")]
        public async Task<ActionResult<string>> LogIn(LogInRequestDTO logInRequest)
        {
            if(!ModelState.IsValid)
                return Unauthorized("Invalid Info");
            var user = await _repository.GetByPropertyAsync(u => u.Email.Equals(logInRequest.Email));

            if (user == null)
                return Unauthorized("Invalid Email");

            if (!user.Passowred.Equals(logInRequest.Passowred))
                return Unauthorized("Invalid Passwored");

            var token = Token(user);
            return Ok(token);
        }

        //Generet token by user info:
        private string Token(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.Type)
            };

            string secretKey = _configuration["Authentication:SecretKey"]!;

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

            var signingCred = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var secureToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(5),
                signingCred
                );

            var endToken = new JwtSecurityTokenHandler().WriteToken(secureToken);

            return endToken;
        }
    }
}
