using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Api.DTOs.ResponseDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBaseRepository<Branch> _repository;
        private readonly IMapper _mapper;

        public BranchController(IBaseRepository<Branch> repository,
                                IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Branch>>> Get()
        {
            var response = await _repository.GetAsync(1, 20);

            if (response is null)
                return NotFound();
            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetBranchById")]
        public async Task<ActionResult<BranchResponseDTO>> GetBranchById(int id)
        {
            var response = await _repository.GetByIdAsync(id);

            if (response is null)
                return NotFound("there is no branch with this id");

            var finalResponse = _mapper.Map<BranchResponseDTO>(response);

            return Ok(finalResponse);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BranchRequestDTO branchEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Info");

            var branch = _mapper.Map<Branch>(branchEntity);

            var result = await _repository.AddAsync(branch);

            return CreatedAtRoute(nameof(GetBranchById), new { result.Id }, result);
        }
    
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BranchRequestDTO branchEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var existingBranch = await _repository.GetByIdAsync(id);

            _mapper.Map(branchEntity, existingBranch);

            await _repository.UpdateAsync(existingBranch!);
        
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _repository.DeleteAsync(id);

            if (response is null) 
                return NotFound();
            return NoContent();
        }
    }
}
