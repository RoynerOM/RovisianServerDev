using RovisianServerDev.Domain.CustomEntities;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Repositories;
using RovisianServerDev.Domain.Services;

namespace RovisianServerDev.Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task<DataState<bool>> Delete(Guid id)
        {
            try
            {
                if (!await _unitOfWork.UsuarioRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Usuario con el ID proporcionado");
                }

                UsuarioEntity model = await _unitOfWork.UsuarioRepository.GetById(id);
                model.Borrado = true;

                _unitOfWork.UsuarioRepository.Update(model);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<bool>(true));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<bool>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<IEnumerable<UsuarioEntity>>> GetAll()
        {
            try
            {
                IEnumerable<UsuarioEntity> response = _unitOfWork.UsuarioRepository.GetAll();
                return await Task.FromResult(new DataSuccess<IEnumerable<UsuarioEntity>>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<IEnumerable<UsuarioEntity>>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<UsuarioEntity>> GetById(Guid id)
        {
            try
            {
                if (!await _unitOfWork.UsuarioRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Usuario con el ID proporcionado");
                }

                UsuarioEntity response = await _unitOfWork.UsuarioRepository.GetById(id);

                return await Task.FromResult(new DataSuccess<UsuarioEntity>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<UsuarioEntity>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<Task>> Save(UsuarioEntity e)
        {
            try
            {
                if (await _unitOfWork.UsuarioRepository.IfExists(e.Id))
                {
                    throw new DataNotFoundException($"Ya existe un Usuario con el ID proporcionado");
                }

                await _unitOfWork.UsuarioRepository.Add(e);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<Task>(Task.FromResult(true)));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<Task>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<bool>> Update(UsuarioEntity e)
        {
            try
            {
                if (!await _unitOfWork.UsuarioRepository.IfExists(e.Id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
                }

                UsuarioEntity model = await _unitOfWork.UsuarioRepository.GetById(e.Id);

                model.Nombre = e.Nombre;

                _unitOfWork.UsuarioRepository.Update(model);

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
