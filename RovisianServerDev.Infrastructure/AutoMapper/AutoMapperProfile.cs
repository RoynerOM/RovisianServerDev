using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Banco
            //Rol
            CreateMap<BankDTO, BancoEntity>().ReverseMap();
            // User Mapper
            CreateMap<UsuarioEntity,UserDTO>();
            CreateMap<UserDTO, UsuarioEntity>();
            //State
            CreateMap<EstadoEntity, StateDTO>();
            CreateMap<StateDTO, EstadoEntity>();
            //Rol
            CreateMap<RolDTO, RolEntity>().ReverseMap();
        }
    }
}
