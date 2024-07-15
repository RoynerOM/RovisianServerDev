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
            CreateMap<BankDTO, BancoEntity>().ReverseMap();
            //Institucion
            CreateMap<InstitutionDTO, InstitucionEntity>().ReverseMap();
            CreateMap<InstitutionGetDTO, InstitucionEntity>().ReverseMap();
            // User Mapper
            CreateMap<UsuarioEntity,UserDTO>();
            CreateMap<UserDTO, UsuarioEntity>();
            //State|
            CreateMap<EstadoEntity, StateDTO>();
            CreateMap<StateDTO, EstadoEntity>();
            //Rol
            CreateMap<RolDTO, RolEntity>().ReverseMap();
        }
    }
}
