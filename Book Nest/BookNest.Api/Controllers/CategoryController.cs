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
    public class CategoryController : ControllerBase
    {
        private readonly IBaseRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CategoryController(IBaseRepository<Category> repository,
                                  IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet("{pageNumber}/{pageSize}")]
        public async Task<ActionResult<IEnumerable<Category>>> Get(int pageNumber, int pageSize)
        {
            var response = await _repository.GetAsync(pageNumber, pageSize);

            if (response == null)
                return NotFound();

            return Ok(response);
        }


        [HttpGet("{id}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoryById(int id)
        {
            var category = await _repository.GetByIdAsync(id);

            var response = _mapper.Map<CategoryResponseDTO>(category);

            if (response == null)
                return NotFound();

            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CategoryRequestDTO categoryEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Info");

            var category = _mapper.Map<Category>(categoryEntity);

            var result = await _repository.AddAsync(category);

            return CreatedAtRoute(nameof(GetCategoryById), new { Id = result.Id }, result);
        }



        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] CategoryRequestDTO categoryEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existingCategory = await _repository.GetByIdAsync(id);

            _mapper.Map(categoryEntity, existingCategory);

            await _repository.UpdateAsync(existingCategory!);

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
