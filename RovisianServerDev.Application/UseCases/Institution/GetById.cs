using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IGetByIdInstitutionUseCase : IUseCase<InstitutionGetDTO, Guid> { }

    public class GetByIdInstitutionCase : IGetByIdInstitutionUseCase
    {
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GetByIdInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<InstitutionGetDTO> Call(Guid id) => _mapper.Map<InstitutionGetDTO>(await _institutionService.GetById(id));
    }
}
