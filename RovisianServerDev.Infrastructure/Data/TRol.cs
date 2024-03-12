using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TRol
    {
        public TRol()
        {
            TUsuarios = new HashSet<TUsuario>();
        }

        public Guid RolId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public bool? Borrado { get; set; }

        public virtual ICollection<TUsuario> TUsuarios { get; set; }
    }
}
