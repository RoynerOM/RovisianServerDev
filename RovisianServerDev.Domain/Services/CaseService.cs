using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Domain.Services
{
    public class CaseService : ICaseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CaseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Delete(Guid id)
        {
            if (!await _unitOfWork.CaseRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Caso con el ID proporcionado");
            }

            CasoEntity model = await _unitOfWork.CaseRepository.GetById(id);
            model.Borrado = true;

            _unitOfWork.CaseRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<CasoEntity>> GetAll()
        {
           return await _unitOfWork.CaseRepository.GetAll();
        }

        public async Task<CasoEntity> GetByConsecutive(string consecutive)
        {
           
            CasoEntity? model = await _unitOfWork.CaseRepository.GetByConsecutive(consecutive);
            
            return model??  throw new DataNotFoundException($"No se pudo encontrar el Caso con el Consecutivo proporcionado"); ;
        }

        public async Task<CasoEntity> GetById(Guid id)
        {
            if (!await _unitOfWork.CaseRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Caso con el ID proporcionado");
            }

           return await _unitOfWork.CaseRepository.GetById(id);
        }

        public async Task<IEnumerable<CasoEntity>> GetByReception(Guid stateId)
        {
            return await _unitOfWork.CaseRepository.GetByReception(stateId);
        }

        public async Task<IEnumerable<CasoEntity>> GetByState(Guid stateId)
        {
            return await _unitOfWork.CaseRepository.GetByState(stateId);
        }

        public async Task<IEnumerable<CasoEntity>> GetByUser(Guid userId)
        {
            return await _unitOfWork.CaseRepository.GetByUser(userId);
        }

        public async Task Reassign(CasoEntity e)
        {
            if (!await _unitOfWork.CaseRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Caso con el ID proporcionado");
            }

            CasoEntity model = await _unitOfWork.CaseRepository.GetById(e.Id);
            model.ContadorId = e.ContadorId;

            _unitOfWork.CaseRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task Save(CasoEntity e)
        {
            if (await _unitOfWork.CaseRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"Ya existe un Caso con el ID proporcionado");
            }

            await _unitOfWork.CaseRepository.Add(e);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(CasoEntity e)
        {
            if (!await _unitOfWork.CaseRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Banco con el ID proporcionado");
            }

            CasoEntity model = await _unitOfWork.CaseRepository.GetById(e.Id);

            model.MotivoRechazo = e.MotivoRechazo;
            model.InstitucionId = e.InstitucionId;

            _unitOfWork.CaseRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return await Task.FromResult(true);
        }
    }
}
