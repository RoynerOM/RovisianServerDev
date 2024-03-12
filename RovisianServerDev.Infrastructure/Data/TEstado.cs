using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TEstado
    {
        public TEstado()
        {
            TCasos = new HashSet<TCaso>();
        }

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool? Borrado { get; set; }

        public virtual ICollection<TCaso> TCasos { get; set; }
    }
}
