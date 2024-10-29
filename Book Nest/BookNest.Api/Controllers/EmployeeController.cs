using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Api.DTOs.ResponseDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Interfaces;
using BookNest.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseRepository<Employee> _employeeRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IBaseRepository<Employee> employeeRepository,
                                  IMapper mapper,
                                  IBaseRepository<User> userRepository
            )
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get(int pageNumber, int pageSize)
        {
            var response = await _employeeRepository.GetAsync(pageNumber, pageSize);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<EmployeeResponseDTO>> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            var response = _mapper.Map<EmployeeResponseDTO>(employee);

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeRequestDTO employeeEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepository.GetByPropertyAsync(u => u.Email == employeeEntity.Email);

            if (user is null)
                return BadRequest("There is no user with this email");

            var employee = _mapper.Map<Employee>(employeeEntity);

            employee.UserId = user.Id;
            employee.User = user;

            user.RoleId = 2;

            await _userRepository.UpdateAsync(user);

            var response = await _employeeRepository.AddAsync(employee);

            return CreatedAtRoute(nameof(GetEmployeeById), new { response.Id}, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmployeeRequestDTO employeeEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingEmployee = await _employeeRepository.GetByIdAsync(id);

            if (existingEmployee is null)
                return NotFound();

            _mapper.Map(employeeEntity, existingEmployee);

            existingEmployee.BranchId = employeeEntity.BranchId;

            await _employeeRepository.UpdateAsync(existingEmployee!);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var response = await _employeeRepository.DeleteAsync(id);

            if(response is null)
                return NotFound();

            return NoContent();
        }
    }
}
