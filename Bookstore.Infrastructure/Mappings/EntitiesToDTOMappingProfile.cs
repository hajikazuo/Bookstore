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
        }
    }
}
