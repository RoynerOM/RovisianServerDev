using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Application.DTOs;
using AutoMapper;
using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IUpdateRolUseCase : IUseCase<bool, RolDTO> { }

    public class UpdateRolCase : IUpdateRolUseCase
    {
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;
        public UpdateRolCase(IRolService rolService, IMapper mapper)
        {
            this._rolService = rolService;
            this._mapper = mapper;
        }

        public async Task<bool> Call(RolDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("RolDTO no puede ser nulo.");
            }

            return await _rolService.Update(_mapper.Map<RolEntity>(dto));
        }
    }
}
