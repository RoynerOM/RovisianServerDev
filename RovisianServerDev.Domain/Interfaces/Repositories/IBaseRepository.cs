using RovisianServerDev.Domain.Entities;

namespace RovisianServerDev.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interfaz base para operaciones CRUD en entidades de tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que se manejará en el repositorio. Debe heredar de <see cref="BaseEntity"/>.</typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Obtiene todas las instancias de la entidad <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Una colección de instancias de la entidad <typeparamref name="T"/>.</returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Obtiene la instancia de la entidad <typeparamref name="T"/> por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>Una tarea que representa la operación y contiene la instancia de la entidad <typeparamref name="T"/>.</returns>
        Task<T> GetById(Guid id);

        /// <summary>
        /// Obtiene la instancia de la entidad <typeparamref name="T"/> por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>Una tarea que representa la operación y contiene la instancia de la entidad <typeparamref name="T"/>.</returns>
        Task<bool> IfExists(Guid id);

        /// <summary>
        /// Agrega una nueva instancia de la entidad <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Instancia de la entidad <typeparamref name="T"/> que se agregará.</param>
        /// <returns>Una tarea que representa la operación.</returns>
        Task Add(T entity);

        /// <summary>
        /// Actualiza la información de la instancia de la entidad <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Instancia de la entidad <typeparamref name="T"/> que se actualizará.</param>
        void Update(T entity);

        /// <summary>
        /// Elimina la instancia de la entidad <typeparamref name="T"/> por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la entidad que se eliminará.</param>
        /// <returns>Una tarea que representa la operación.</returns>
        Task Delete(Guid id);
    }


}
