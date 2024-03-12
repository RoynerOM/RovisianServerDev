using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TTipoInstitucion
    {
        public TTipoInstitucion()
        {
            TInstitucions = new HashSet<TInstitucion>();
        }

        public int TipoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<TInstitucion> TInstitucions { get; set; }
    }
}
