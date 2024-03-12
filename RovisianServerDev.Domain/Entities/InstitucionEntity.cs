namespace RovisianServerDev.Domain.Entities
{
    public class InstitucionEntity : BaseEntity
    {

        public InstitucionEntity()
        {
            Casos = new HashSet<CasoEntity>();
        }

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

        public virtual BancoEntity? Banco { get; set; }
        public virtual UsuarioEntity? Contador { get; set; }
        public virtual RutaEntity? Ruta { get; set; }
        public virtual TipoInstitucionEntity? Tipo { get; set; }
        public virtual ICollection<CasoEntity> Casos { get; set; }
    }

}
