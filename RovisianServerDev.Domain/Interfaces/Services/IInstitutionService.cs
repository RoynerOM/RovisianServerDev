using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IInstitutionService
    {
        Task<IEnumerable<InstitucionEntity>> GetAll();
        Task<IEnumerable<InstitucionEntity>> GetByName(string name);
        Task<InstitucionEntity> GetById(Guid id);
        Task<InstitucionEntity> GetByCode(int code);
        Task Save(InstitucionEntity e);
        Task<bool> Update(InstitucionEntity e);
        Task<bool> Delete(Guid id);
    }
}
