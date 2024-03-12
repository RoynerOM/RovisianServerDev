using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TRutum
    {
        public TRutum()
        {
            TInstitucions = new HashSet<TInstitucion>();
        }

        public int RutaId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<TInstitucion> TInstitucions { get; set; }
    }
}
