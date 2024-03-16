using RovisianServerDev.Domain.Resources;
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

        public async Task<DataState<bool>> Delete(Guid id)
        {
            try
            {
                if (!await _unitOfWork.BancoRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
                }

                BancoEntity model = await _unitOfWork.BancoRepository.GetById(id);
                model.Borrado = true;

                _unitOfWork.BancoRepository.Update(model);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<bool>(true));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<bool>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<IEnumerable<BancoEntity>>> GetAll()
        {
            try
            {
                IEnumerable<BancoEntity> response = await _unitOfWork.BancoRepository.GetAll();
                return await Task.FromResult(new DataSuccess<IEnumerable<BancoEntity>>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<IEnumerable<BancoEntity>>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<BancoEntity>> GetById(Guid id)
        {
            try
            {
                if (!await _unitOfWork.BancoRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
                }

                BancoEntity response = await _unitOfWork.BancoRepository.GetById(id);

                return await Task.FromResult(new DataSuccess<BancoEntity>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<BancoEntity>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<Task>> Save(BancoEntity e)
        {
            try
            {
                if (await _unitOfWork.BancoRepository.IfExists(e.Id))
                {
                    throw new DataNotFoundException($"Ya existe un Banco con el ID proporcionado");
                }

                await _unitOfWork.BancoRepository.Add(e);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<Task>(Task.FromResult(true)));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<Task>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<bool>> Update(BancoEntity e)
        {
            try
            {
                if (!await _unitOfWork.BancoRepository.IfExists(e.Id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
                }

                BancoEntity model = await _unitOfWork.BancoRepository.GetById(e.Id);

                model.Nombre = e.Nombre;

                _unitOfWork.BancoRepository.Update(model);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<bool>(true));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<bool>(ex.Message);
                return await Task.FromResult(error);
            }
        }
    }
}
