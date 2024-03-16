using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;
using RovisianServerDev.Domain.Error;


namespace RovisianServerDev.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.EstateRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
            }

            EstadoEntity model = await _unitOfWork.EstateRepository.GetById(id);
            model.Borrado = true;

            _unitOfWork.EstateRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<EstadoEntity>> GetAll()
        {
            try
            {
                IEnumerable<EstadoEntity> response = await _unitOfWork.EstateRepository.GetAll();
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message);
            }
        }

        public async Task<EstadoEntity> GetById(Guid id)
        {
            if (!await _unitOfWork.EstateRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
            }

            EstadoEntity response = await _unitOfWork.EstateRepository.GetById(id);

            return await Task.FromResult(response);
        }

        public async Task Save(EstadoEntity post)
        {
            if (await _unitOfWork.EstateRepository.IfExists(post.Id))
            {
                throw new DataNotFoundException($"Ya existe un Estado con el ID proporcionado");
            }

            await _unitOfWork.EstateRepository.Add(post);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(EstadoEntity post)
        {
            if (!await _unitOfWork.EstateRepository.IfExists(post.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
            }

            EstadoEntity model = await _unitOfWork.EstateRepository.GetById(post.Id);

            model.Nombre = post.Nombre;

            _unitOfWork.EstateRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
