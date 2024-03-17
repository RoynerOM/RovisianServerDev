using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Interfaces;

namespace RovisianServerDev.Application.UseCases.Institution
{
    public interface IDeleteInstitutionUseCase : IUseCase<bool, Guid> { }

    public class DeleteInstitutionCase : IDeleteInstitutionUseCase
    {
        private readonly IInstitutionService _institutionService;
        public DeleteInstitutionCase(IInstitutionService institutionService)
        {
            this._institutionService = institutionService;
        }

        public async Task<bool> Call(Guid values) => await _institutionService.Delete(values);
    }
}
