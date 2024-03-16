using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Domain.Services
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.RolRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Rol con el ID proporcionado");
            }

            RolEntity model = await _unitOfWork.RolRepository.GetById(id);
            model.Borrado = true;

            _unitOfWork.RolRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);

        }

        public async Task<IEnumerable<RolEntity>> GetAll() => await _unitOfWork.RolRepository.GetAll();

        public async Task<RolEntity> GetById(Guid id)
        {
            if (!await _unitOfWork.RolRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Rol con el ID proporcionado");
            }

            RolEntity response = await _unitOfWork.RolRepository.GetById(id);

            return await Task.FromResult(response);
        }

        public async Task Save(RolEntity e)
        {
            if (await _unitOfWork.RolRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"Ya existe un Rol con el ID proporcionado");
            }

            await _unitOfWork.RolRepository.Add(e);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(RolEntity e)
        {
            if (!await _unitOfWork.RolRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
            }

            RolEntity model = await _unitOfWork.RolRepository.GetById(e.Id);

            model.Nombre = e.Nombre;

            _unitOfWork.RolRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
