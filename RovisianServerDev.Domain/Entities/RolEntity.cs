namespace RovisianServerDev.Domain.Entities
{
    public class RolEntity : BaseEntity
    {
        public RolEntity()
        {
            Usuarios = new HashSet<UsuarioEntity>();
        }

        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }

        public virtual ICollection<UsuarioEntity> Usuarios { get; set; }
    }

}
