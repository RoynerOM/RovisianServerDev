using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Domain.Services
{
    public class BancoService : IBancoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BancoService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.BancoRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
            }

            BancoEntity model = await _unitOfWork.BancoRepository.GetById(id);
            model.Borrado = true;

            _unitOfWork.BancoRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<BancoEntity>> GetAll() => await _unitOfWork.BancoRepository.GetAll();

        public async Task<BancoEntity> GetById(Guid id)
        {
            if (!await _unitOfWork.BancoRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
            }

            return await _unitOfWork.BancoRepository.GetById(id);
        }

        public async Task Save(BancoEntity e)
        {
            if (await _unitOfWork.BancoRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"Ya existe un Banco con el ID proporcionado");
            }

            await _unitOfWork.BancoRepository.Add(e);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(BancoEntity e)
        {
            if (!await _unitOfWork.BancoRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
            }

            BancoEntity model = await _unitOfWork.BancoRepository.GetById(e.Id);

            model.Nombre = e.Nombre;

            _unitOfWork.BancoRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
