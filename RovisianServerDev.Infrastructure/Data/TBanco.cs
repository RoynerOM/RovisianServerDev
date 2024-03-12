using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TBanco
    {
        public TBanco()
        {
            TInstitucions = new HashSet<TInstitucion>();
        }

        public Guid BancoId { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Borrado { get; set; }

        public virtual ICollection<TInstitucion> TInstitucions { get; set; }
    }
}
