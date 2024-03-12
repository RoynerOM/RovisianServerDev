namespace RovisianServerDev.Domain.Entities
{
    public class UsuarioEntity : BaseEntity
    {
        public UsuarioEntity()
        {
            CasoContadors = new HashSet<CasoEntity>();
            CasoTramitadors = new HashSet<CasoEntity>();
            Instituciones = new HashSet<InstitucionEntity>();
        }

        public string Cedula { get; set; } = null!;
        public int TipoCedula { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Carnet { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenna { get; set; } = null!;
        public string Firma { get; set; } = null!;
        public bool? Activo { get; set; }
        public DateTime? UtimaVez { get; set; }
        public Guid? RolId { get; set; }

        public virtual RolEntity? Rol { get; set; }
        public virtual ICollection<CasoEntity> CasoContadors { get; set; }
        public virtual ICollection<CasoEntity> CasoTramitadors { get; set; }
        public virtual ICollection<InstitucionEntity> Instituciones { get; set; }
    }

}
