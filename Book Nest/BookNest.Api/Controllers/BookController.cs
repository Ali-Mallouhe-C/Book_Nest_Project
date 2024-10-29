using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Api.DTOs.ResponseDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookController(IBaseRepository<Book> repository,
                                IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Book>>> Get(int pageNumber = 1, int pageSize = 10)
        {
            var response = await _repository.GetAsync(pageNumber, pageSize);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<ActionResult<BookResponseDTO>> GetBookById(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            var response = _mapper.Map<BookResponseDTO>(book);

            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] BookRequestDTO bookEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Info");

            var book = _mapper.Map<Book>(bookEntity);

            var result = await _repository.AddAsync(book);

            return CreatedAtRoute(nameof(GetBookById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BookRequestDTO bookEntity)
        {
            var existingBook =await _repository.GetByIdAsync(id);

            if (existingBook is null)
                return NotFound("There is no book with this id");

            _mapper.Map(bookEntity, existingBook);

            await _repository.UpdateAsync(existingBook);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _repository.DeleteAsync(id);

            if(response is null)
                return NotFound();
            return NoContent();
        }
    }
}
