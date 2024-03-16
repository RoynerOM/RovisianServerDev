using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IGetByIdRolUseCase : IUseCase<RolDTO, Guid> {}

    public class GetByIdRolCase : IGetByIdRolUseCase
    {
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;

        public GetByIdRolCase(IRolService rolService, IMapper mapper)
        {
            this._rolService = rolService;
            this._mapper = mapper;
        }

        public async Task<RolDTO> Call(Guid values)=> _mapper.Map<RolDTO>(await _rolService.GetById(values));
    }
}
