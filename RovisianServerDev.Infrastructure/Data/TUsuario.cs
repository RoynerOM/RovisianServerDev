using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TUsuario
    {
        public TUsuario()
        {
            TCasoContadors = new HashSet<TCaso>();
            TCasoTramitadors = new HashSet<TCaso>();
            TInstitucions = new HashSet<TInstitucion>();
        }

        public Guid UsuarioId { get; set; }
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
        public bool? Borrado { get; set; }

        public virtual TRol? Rol { get; set; }
        public virtual ICollection<TCaso> TCasoContadors { get; set; }
        public virtual ICollection<TCaso> TCasoTramitadors { get; set; }
        public virtual ICollection<TInstitucion> TInstitucions { get; set; }
    }
}
