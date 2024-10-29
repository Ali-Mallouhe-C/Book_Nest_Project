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
    public class AuthorController : ControllerBase
    {
        private readonly IBaseRepository<Author> _repository;
        private readonly IMapper _mapper;

        public AuthorController(IBaseRepository<Author> repository,
                                IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Author>>> Get(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _repository.GetAsync(pageNumber, pageSize);

            if ( response == null )
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetAuthorById")]
        public async Task<ActionResult<AuthorResponseDTO>> GetAuthorById(int id)
        {
            var author = await _repository.GetByIdAsync(id);

            var response = _mapper.Map<AuthorResponseDTO>(author);

            if ( response == null )
                return NotFound();
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult>  Create([FromBody] AuthorRequestDTO authorEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Info");

            var author = _mapper.Map<Author>(authorEntity);

            var result = await _repository.AddAsync(author);

            return CreatedAtRoute(nameof(GetAuthorById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] AuthorRequestDTO authorEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingAuthor = await _repository.GetByIdAsync(id);

            _mapper.Map(authorEntity, existingAuthor);

            await _repository.UpdateAsync(existingAuthor!);

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