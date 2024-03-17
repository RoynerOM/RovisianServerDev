namespace RovisianServerDev.Application.DTOs
{
    public class InstitutionDTO
    {
        public Guid Id { get; set; }
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
    }
}
