using AutoMapper;
using RovisianServerDev.Application.DTOs;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface ISaveInstitutionUseCase : IUseCase<Task, InstitutionDTO> { }

    public class SaveInstitutionCase : ISaveInstitutionUseCase
    {
        private readonly IInstitutionService _institutionService;
        private readonly IMapper _mapper;

        public SaveInstitutionCase(IInstitutionService institutionService, IMapper mapper)
        {
            this._institutionService = institutionService;
            this._mapper = mapper;
        }

        public async Task<Task> Call(InstitutionDTO? dto)
        {
            dto!.Id = dto.Id == Guid.Empty ? Guid.NewGuid() : dto.Id;

            if (dto == null)
            {
                throw new ParamNullException("Institucion no puede ser nulo.");
            }

            await _institutionService.Save(_mapper.Map<InstitucionEntity>(dto));

            return Task.CompletedTask;
        }
    }
}
