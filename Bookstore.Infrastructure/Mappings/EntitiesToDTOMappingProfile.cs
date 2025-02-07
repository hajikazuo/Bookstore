using AutoMapper;
using Bookstore.Domain.DTOs;
using Bookstore.Domain.Entities;

namespace Bookstore.Infrastructure.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Loan, LoanResponseDTO>()
                .ForMember(dest => dest.BookDTO, opt => opt.MapFrom(src => src.Book))
                .ForMember(dest => dest.ClientDTO, opt => opt.MapFrom(src => src.Client))
                .ReverseMap();
            CreateMap<Loan, LoanPostRequestDTO>().ReverseMap();
        }
    }
}
