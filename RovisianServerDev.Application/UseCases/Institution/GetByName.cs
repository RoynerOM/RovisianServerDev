using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IGetByNameInstitutionUseCase : IUseCase<IEnumerable<InstitutionGetDTO>, string> { }

    public class GetByNameInstitutionCase : IGetByNameInstitutionUseCase
    {

        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GetByNameInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<InstitutionGetDTO>> Call(string? values) => _mapper.Map<IEnumerable<InstitutionGetDTO>>(await _institutionService.GetByName(values!));
    }
}
