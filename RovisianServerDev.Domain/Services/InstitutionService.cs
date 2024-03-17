using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Domain.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public InstitutionService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.InstitutionRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Institución con el ID proporcionado");
            }

            InstitucionEntity model = await _unitOfWork.InstitutionRepository.GetById(id);
            model.Borrado = true;

            _unitOfWork.InstitutionRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<InstitucionEntity>> GetAll()
        {
            return await _unitOfWork.InstitutionRepository.GetAll();
        }

        public async Task<InstitucionEntity> GetByCode(int code)
        {
            InstitucionEntity? model = await _unitOfWork.InstitutionRepository.GetByCode(code);
            return model ?? throw new DataNotFoundException("La institucion con el codigo proporcionado no existe"); ;
        }

        public async Task<InstitucionEntity> GetById(Guid id)
        {
            if (!await _unitOfWork.InstitutionRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar la institucion con el ID proporcionado");
            }

            return await _unitOfWork.InstitutionRepository.GetById(id);
        }

        public async Task<IEnumerable<InstitucionEntity>> GetByName(string name)
        {
            return await _unitOfWork.InstitutionRepository.GetByName(name);
        }

        public async Task Save(InstitucionEntity e)
        {
            if (await _unitOfWork.InstitutionRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"Ya existe una Institucion con el ID proporcionado");
            }

            await _unitOfWork.InstitutionRepository.Add(e);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(InstitucionEntity e)
        {
            if (!await _unitOfWork.InstitutionRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar la Institucion con el ID proporcionado");
            }

            InstitucionEntity model = await _unitOfWork.InstitutionRepository.GetById(e.Id);
            model.Nombre = e.Nombre;
            model.Circuito = e.Circuito;
            model.CedulaJuridica = e.CedulaJuridica;
            model.CuentaDanea = e.CuentaDanea;
            model.Cuenta6746 = e.Cuenta6746;
            model.Responsable = e.Responsable;
            model.BancoId = e.BancoId;
            model.RutaId = e.RutaId;
            model.TipoId = e.TipoId;
            model.ContadorId = e.ContadorId;

            _unitOfWork.InstitutionRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
