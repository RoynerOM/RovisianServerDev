using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IGetAllInstitutionUseCase : IUseCase<IEnumerable<InstitutionGetDTO>, object> { }

    public class GetAllInstitutionCase : IGetAllInstitutionUseCase
    {
       
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;
        public GetAllInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<InstitutionGetDTO>> Call(object? values) => _mapper.Map<IEnumerable<InstitutionGetDTO>>(await _institutionService.GetAll());
    }
}
