using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IUpdateInstitutionUseCase : IUseCase<bool, InstitutionDTO> { }

    public class UpdateInstitutionCase : IUpdateInstitutionUseCase
    {
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;

        public UpdateInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }


        public async Task<bool> Call(InstitutionDTO? dto)
        {
            if (dto == null)
            {
                throw new ParamNullException("Institution no puede ser nulo.");
            }

            return await _institutionService.Update(_mapper.Map<InstitucionEntity>(dto));
        }
    }
}
