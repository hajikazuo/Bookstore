using AutoMapper;
using Bookstore.Api.DTOs;
using Bookstore.Api.Models;

namespace Bookstore.Api.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Client, ClientDTO>().ReverseMap();
        }
    }
}
