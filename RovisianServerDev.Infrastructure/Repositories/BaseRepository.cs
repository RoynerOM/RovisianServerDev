using Microsoft.EntityFrameworkCore;
using RovisianServerDev.Domain.Entities;
using RovisianServerDev.Domain.Repositories;
using RovisianServerDev.Infrastructure.Data;

namespace RovisianServerDev.Infrastructure.Repositories
{
    /// <summary>
    /// Implementa la interfaz base para operaciones CRUD en entidades de tipo <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad que se manejará en el repositorio. Debe heredar de <see cref="BaseEntity"/>.</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly RovisianDBContext _context;
        protected readonly DbSet<T> _entities;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseRepository{T}"/>.
        /// </summary>
        /// <param name="context">Contexto de base de datos que se utilizará para operaciones de acceso a datos.</param>
        public BaseRepository(RovisianDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = context.Set<T>();
        }

        /// <summary>
        /// Obtiene todas las instancias de la entidad <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Una colección de instancias de la entidad <typeparamref name="T"/>.</returns>
        public IEnumerable<T> GetAll() => _entities.AsEnumerable();

        /// <summary>
        /// Obtiene la instancia de la entidad <typeparamref name="T"/> por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la entidad.</param>
        /// <returns>Una tarea que representa la operación y contiene la instancia de la entidad <typeparamref name="T"/> si se encuentra; de lo contrario, null.</returns>
        public async Task<T> GetById(Guid id) => await _entities.FirstAsync(x => x.Id == id);

        /// <summary>
        /// Agrega una nueva instancia de la entidad <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Instancia de la entidad <typeparamref name="T"/> que se agregará.</param>
        /// <returns>Una tarea que representa la operación.</returns>
        public async Task Add(T entity) => await _entities.AddAsync(entity);

        /// <summary>
        /// Actualiza la información de la instancia de la entidad <typeparamref name="T"/>.
        /// </summary>
        /// <param name="entity">Instancia de la entidad <typeparamref name="T"/> que se actualizará.</param>
        public void Update(T entity) => _entities.Update(entity);

        /// <summary>
        /// Elimina la instancia de la entidad <typeparamref name="T"/> por su identificador.
        /// </summary>
        /// <param name="id">Identificador único de la entidad que se eliminará.</param>
        /// <returns>Una tarea que representa la operación.</returns>
        public async Task Delete(Guid id) => _entities.Remove(await GetById(id));

        /// <summary>
        /// Verifica si existe una instancia de la entidad <typeparamref name="T"/> con el identificador especificado.
        /// </summary>
        /// <param name="id">Identificador único de la entidad que se verificará.</param>
        /// <returns>Una tarea que representa la operación y devuelve true si la entidad existe; de lo contrario, false.</returns>
        public async Task<bool> IfExists(Guid id) => await _entities.FindAsync(id) != null;
    }

}
