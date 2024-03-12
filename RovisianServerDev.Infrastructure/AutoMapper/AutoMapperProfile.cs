using AutoMapper;
using RovisianServerDev.Core.DTOs;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            // User Mapper
            CreateMap<UsuarioEntity,UserDTO>();
            CreateMap<UserDTO, UsuarioEntity>();
        }
    }
}
