using AutoMapper;
using BookNest.Api.DTOs.RequestDTO;
using BookNest.Api.DTOs.ResponseDTO;
using BookNest.Domain.Entities;
using BookNest.Infrastructure.Repositories;

namespace BookNest.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpRequestDTO, User>().ReverseMap();
            
            CreateMap<BranchRequestDTO, Branch>().ReverseMap();
            CreateMap<BranchResponseDTO, Branch>().ReverseMap();

            CreateMap<AuthorRequestDTO, Author>().ReverseMap();
            CreateMap<AuthorResponseDTO, Author>().ReverseMap();

            CreateMap<CategoryRequestDTO, Category>().ReverseMap();
            CreateMap<CategoryResponseDTO, Category>().ReverseMap();

            CreateMap<EmployeeRequestDTO, Employee>().ReverseMap();
            CreateMap<EmployeeResponseDTO, Employee>().ReverseMap();

            CreateMap<BookRequestDTO, Book>().ReverseMap();
            CreateMap<BookResponseDTO, Book>().ReverseMap();

            CreateMap<RatingRequestDTO, Rating>().ReverseMap(); 

            CreateMap<ReservationRequestDTO, Reservation>().ReverseMap();
            CreateMap<ReservationResponseDTO, Reservation>().ReverseMap();
        }
    }
}
