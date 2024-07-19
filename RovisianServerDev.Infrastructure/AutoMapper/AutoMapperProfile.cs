using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;
using static RovisianServerDev.Application.DTOs.InstitutionGetDTO;

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
            CreateMap<InstitutionGetDTO, InstitucionEntity>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.Codigo))
           .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
           .ForMember(dest => dest.Circuito, opt => opt.MapFrom(src => src.Circuito))
           .ForMember(dest => dest.CedulaJuridica, opt => opt.MapFrom(src => src.CedulaJuridica))
           .ForMember(dest => dest.CuentaDanea, opt => opt.MapFrom(src => src.CuentaDanea))
           .ForMember(dest => dest.Cuenta6746, opt => opt.MapFrom(src => src.Cuenta6746))
           .ForMember(dest => dest.Responsable, opt => opt.MapFrom(src => src.Responsable))
           .ForMember(dest => dest.BancoId, opt => opt.MapFrom(src => src.BancoId))
           .ForMember(dest => dest.RutaId, opt => opt.MapFrom(src => src.RutaId))
           .ForMember(dest => dest.TipoId, opt => opt.MapFrom(src => src.TipoId))
           .ForMember(dest => dest.ContadorId, opt => opt.MapFrom(src => src.ContadorId))
           .ForMember(dest => dest.Banco, opt => opt.MapFrom(src => src.Banco))
           .ForMember(dest => dest.Contador, opt => opt.MapFrom(src => src.Contador)).ReverseMap()
           ;
            // User Mapper
            CreateMap<UserDTO, UsuarioEntity>().ReverseMap();
            //Details
            CreateMap<UsuarioEntity, UserDetailsDTO>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
           .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
           .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
           .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(src => src.Apellidos))
           .ForMember(dest => dest.Carnet, opt => opt.MapFrom(src => src.Carnet))
           .ForMember(dest => dest.Correo, opt => opt.MapFrom(src => src.Correo)).ReverseMap();
            //State|
            CreateMap<StateDTO, EstadoEntity>().ReverseMap();
            //Rol
            CreateMap<RolDTO, RolEntity>().ReverseMap();

            
        }
    }
}
