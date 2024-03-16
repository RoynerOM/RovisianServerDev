using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Resources;


namespace RovisianServerDev.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DataState<bool>> DeleteState(Guid id)
        {
            try
            {
                if (!await _unitOfWork.EstateRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
                }

                EstadoEntity model = await _unitOfWork.EstateRepository.GetById(id);
                model.Borrado = true;

                _unitOfWork.EstateRepository.Update(model);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<bool>(true));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<bool>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<IEnumerable<EstadoEntity>>> GetAll()
        {
            try
            {
                IEnumerable<EstadoEntity> response = await _unitOfWork.EstateRepository.GetAll();
                return await Task.FromResult(new DataSuccess<IEnumerable<EstadoEntity>>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<IEnumerable<EstadoEntity>>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<EstadoEntity>> GetById(Guid id)
        {
            try
            {
                if (!await _unitOfWork.EstateRepository.IfExists(id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
                }

                EstadoEntity response = await _unitOfWork.EstateRepository.GetById(id);

                return await Task.FromResult(new DataSuccess<EstadoEntity>(response));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<EstadoEntity>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<Task>> SaveState(EstadoEntity post)
        {
            try
            {
                if (await _unitOfWork.EstateRepository.IfExists(post.Id))
                {
                    throw new DataNotFoundException($"Ya existe un Estado con el ID proporcionado");
                }

                await _unitOfWork.EstateRepository.Add(post);

                await _unitOfWork.SaveChangesAsync();
                return await Task.FromResult(new DataSuccess<Task>(Task.FromResult(true)));
            }
            catch (Exception ex)
            {
                var error = new DataFailed<Task>(ex.Message);
                return await Task.FromResult(error);
            }
        }

        public async Task<DataState<bool>> UpdateState(EstadoEntity post)
        {
            try
            {
                if (!await _unitOfWork.EstateRepository.IfExists(post.Id))
                {
                    throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
                }

                EstadoEntity model = await _unitOfWork.EstateRepository.GetById(post.Id);

                model.Nombre = post.Nombre;

                _unitOfWork.EstateRepository.Update(model);

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
