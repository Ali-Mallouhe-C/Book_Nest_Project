using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookNest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IBaseRepository<Rating> _repository;
        private readonly IMapper _mapper;

        public RatingController(IBaseRepository<Rating> repository,
                                IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RatingRequestDTO ratingEntity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var rate = _mapper.Map<Rating>(ratingEntity);

            await _repository.AddAsync(rate);

            return Created();
        } 
        

    }
}
