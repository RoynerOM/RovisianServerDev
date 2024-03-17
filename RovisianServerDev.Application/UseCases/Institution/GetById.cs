using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IGetByIdInstitutionUseCase : IUseCase<InstitutionDTO, Guid> { }

    public class GetByIdInstitutionCase : IGetByIdInstitutionUseCase
    {
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GetByIdInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<InstitutionDTO> Call(Guid id) => _mapper.Map<InstitutionDTO>(await _institutionService.GetById(id));
    }
}
