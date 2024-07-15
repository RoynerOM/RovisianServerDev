using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IGetByCodeInstitutionUseCase : IUseCase<InstitutionGetDTO, int> { }

    public class GetByCodeInstitutionCase : IGetByCodeInstitutionUseCase
    {
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GetByCodeInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<InstitutionGetDTO> Call(int code) => _mapper.Map<InstitutionGetDTO>(await _institutionService.GetByCode(code));
    }
}
