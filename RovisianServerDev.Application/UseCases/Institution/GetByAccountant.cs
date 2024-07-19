using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IGetByUserInstitutionUseCase : IUseCase<IEnumerable<InstitutionGetDTO>, Guid> { }

    public class GetByUserInstitutions : IGetByUserInstitutionUseCase
    {

        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GetByUserInstitutions(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<InstitutionGetDTO>> Call(Guid values) => _mapper.Map<IEnumerable<InstitutionGetDTO>>(await _institutionService.GetByUser(values));
    }
}
