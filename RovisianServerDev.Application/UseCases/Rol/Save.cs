using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Application.DTOs;
using AutoMapper;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface ISaveRolUseCase : IUseCase<Task, RolDTO> { }

    public class SaveRolCase : ISaveRolUseCase
    {
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;
        public SaveRolCase(IRolService rolService, IMapper mapper)
        {
            this._rolService = rolService;
            this._mapper = mapper;
        }

        public async Task<Task> Call(RolDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("RolDTO no puede ser nulo.");
            }

            await _rolService.Save(_mapper.Map<RolEntity>(dto));

            return Task.CompletedTask;
        }
    }
}
