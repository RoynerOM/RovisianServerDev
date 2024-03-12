using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TCaso
    {
        public Guid CasoId { get; set; }
        public Guid? InstitucionId { get; set; }
        public Guid? TramitadorId { get; set; }
        public Guid? ContadorId { get; set; }
        public string? MotivoRechazo { get; set; }
        public int? Secuencia { get; set; }
        public string? CodigoCaso { get; set; }
        public Guid? EstadoId { get; set; }
        public bool? Borrado { get; set; }

        public virtual TUsuario? Contador { get; set; }
        public virtual TEstado? Estado { get; set; }
        public virtual TInstitucion? Institucion { get; set; }
        public virtual TUsuario? Tramitador { get; set; }
    }
}
