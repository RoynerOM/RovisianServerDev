namespace RovisianServerDev.Domain.Entities
{
    public class CasoEntity:BaseEntity
    {
        public Guid? InstitucionId { get; set; }
        public Guid? TramitadorId { get; set; }
        public Guid? ContadorId { get; set; }
        public string MotivoRechazo { get; set; } = "";
        public int Secuencia { get; set; } = 0;
        public string CodigoCaso { get; set; } = "R-0";
        public Guid? EstadoId { get; set; }

        // Propiedades de navegación
        public InstitucionEntity? Institucion { get; set; }
        public UsuarioEntity? Tramitador { get; set; }
        public UsuarioEntity? Contador { get; set; }
        public EstadoEntity ?Estado { get; set; }
    }

}
