using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;
using AutoMapper;
using RovisianServerDev.Application.DTOs;

namespace RovisianServerDev.Application.UseCases.Rol
{
    public interface IGetAllRolUseCase : IUseCase<IEnumerable<RolDTO>, object> { }

    public class GetAllRolCase : IGetAllRolUseCase
    {
        private readonly IRolService _rolService;
        private readonly IMapper _mapper;
        public GetAllRolCase(IRolService rolService, IMapper mapper)
        {
            this._rolService = rolService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<RolDTO>> Call(object? values) => _mapper.Map<IEnumerable<RolDTO>>(await _rolService.GetAll());
    }
}
