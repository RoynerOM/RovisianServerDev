using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Repositories
{
    public interface IInstitutionRepository: IBaseRepository<InstitucionEntity>
    {
        Task<InstitucionEntity?> GetByCode(int code);
        Task<IEnumerable<InstitucionEntity>> GetByName(string name);
    }
}
