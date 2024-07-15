namespace RovisianServerDev.Application.DTOs
{
    public class InstitutionGetDTO
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
        public BankDTO? Banco { get; set; }
        public UserDetailsDTO? Contador { get; set; }

        public class UserDetailsDTO
        {
            public Guid Id { get; set; }
            public string Cedula { get; set; } = null!;
            public string Nombre { get; set; } = null!;
            public string Apellidos { get; set; } = null!;
            public string? Carnet { get; set; }
            public string Correo { get; set; } = null!;
        }
    }
}
