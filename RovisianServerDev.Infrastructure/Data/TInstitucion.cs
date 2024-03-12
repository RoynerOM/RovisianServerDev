using System;
using System.Collections.Generic;

namespace RovisianServerDev.Infrastructure.Data
{
    public partial class TInstitucion
    {
        public TInstitucion()
        {
            TCasos = new HashSet<TCaso>();
        }

        public Guid InstitucionId { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; } = null!;
        public int? Circuito { get; set; }
        public string? CedulaJuridica { get; set; }
        public string? CuentaDanea { get; set; }
        public string? Cuenta6746 { get; set; }
        public string? Responsable { get; set; }
        public Guid? BancoId { get; set; }
        public int? RutaId { get; set; }
        public int? TipoId { get; set; }
        public Guid? ContadorId { get; set; }
        public bool? Borrado { get; set; }

        public virtual TBanco? Banco { get; set; }
        public virtual TUsuario? Contador { get; set; }
        public virtual TRutum? Ruta { get; set; }
        public virtual TTipoInstitucion? Tipo { get; set; }
        public virtual ICollection<TCaso> TCasos { get; set; }
    }
}
