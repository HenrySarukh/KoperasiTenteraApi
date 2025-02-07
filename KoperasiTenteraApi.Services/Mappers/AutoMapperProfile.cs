using AutoMapper;
using KoperasiTenteraApi.Application.Dtos;
using KoperasiTenteraApi.Domain.Entities;

namespace KoperasiTenteraApi.Application.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
