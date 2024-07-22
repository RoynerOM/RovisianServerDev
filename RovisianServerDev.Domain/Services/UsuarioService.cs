using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Error;
using RovisianServerDev.Domain.Interfaces.Repositories;
using RovisianServerDev.Domain.Interfaces.Services;

namespace RovisianServerDev.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<bool> Delete(Guid id)
        {

            if (!await _unitOfWork.UsuarioRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Usuario con el ID proporcionado");
            }

            UsuarioEntity model = await _unitOfWork.UsuarioRepository.GetById(id);
            model.Borrado = true;

            _unitOfWork.UsuarioRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<UsuarioEntity>> GetAll() => await _unitOfWork.UsuarioRepository.GetAll();

        public async Task<UsuarioEntity> GetById(Guid id)
        {

            if (!await _unitOfWork.UsuarioRepository.IfExists(id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Usuario con el ID proporcionado");
            }

            return await _unitOfWork.UsuarioRepository.GetById(id);
        }

        public async Task<IEnumerable<UsuarioEntity>> GetByRol(Guid rolId)
        {
          return  await _unitOfWork.UsuarioRepository.GetByRol(rolId);
        }

        public async Task<UsuarioEntity> GetLogin(string dni)
        {
            UsuarioEntity? userEntity = await _unitOfWork.UsuarioRepository.GetLogin(dni);
            return userEntity?? throw new DataNotFoundException($"Las credenciales del usuario proporcionado son inválidas"); 
        }

        public async Task Save(UsuarioEntity e)
        {
            if (await _unitOfWork.UsuarioRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"Ya existe un Usuario con el ID proporcionado");
            }

            await _unitOfWork.UsuarioRepository.Add(e);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(UsuarioEntity e)
        {

            if (!await _unitOfWork.UsuarioRepository.IfExists(e.Id))
            {
                throw new DataNotFoundException($"No se pudo encontrar el Estado con el ID proporcionado");
            }

            UsuarioEntity model = await _unitOfWork.UsuarioRepository.GetById(e.Id);
            model.Nombre = e.Nombre;
            model.Apellidos = e.Apellidos;
            model.TipoCedula = e.TipoCedula;
            model.Carnet = e.Carnet;
            model.Correo = e.Correo;
            model.RolId = e.RolId;
            model.Contrasenna = e.Contrasenna;
           

            _unitOfWork.UsuarioRepository.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return true;

        }
    }
}
