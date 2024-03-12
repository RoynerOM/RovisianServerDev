using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Repositories;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Infrastructure.Services
{
    public class RolService : IRolService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RolService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<DataState<bool>> Delete(Guid id)
        {
            try
            {
                if (!await _unitOfWork.RolRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Rol con el ID proporcionado");
                }

                RolEntity model = await _unitOfWork.RolRepository.GetById(id);
                model.Borrado = true;

                _unitOfWork.RolRepository.Update(model);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<bool>(true));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<bool>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<IEnumerable<RolEntity>>> GetAll()
        {
            try
            {
                IEnumerable<RolEntity> response = _unitOfWork.RolRepository.GetAll();
                return await Task.FromResult(new DataSuccess<IEnumerable<RolEntity>>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<IEnumerable<RolEntity>>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<RolEntity>> GetById(Guid id)
        {
            try
            {
                if (!await _unitOfWork.RolRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Rol con el ID proporcionado");
                }

                RolEntity response = await _unitOfWork.RolRepository.GetById(id);

                return await Task.FromResult(new DataSuccess<RolEntity>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<RolEntity>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<Task>> Save(RolEntity e)
        {
            try
            {
                if (await _unitOfWork.RolRepository.IfExists(e.Id))
                {
                    throw new DataNotFoundException($"Ya existe un Rol con el ID proporcionado");
                }

                await _unitOfWork.RolRepository.Add(e);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<Task>(Task.FromResult(true)));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<Task>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<bool>> Update(RolEntity e)
        {
            try
            {
                if (!await _unitOfWork.RolRepository.IfExists(e.Id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
                }

                RolEntity model = await _unitOfWork.RolRepository.GetById(e.Id);

                model.Nombre = e.Nombre;

                _unitOfWork.RolRepository.Update(model);

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
