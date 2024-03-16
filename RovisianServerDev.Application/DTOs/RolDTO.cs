namespace RovisianServerDev.Application.DTOs
{
    public class RolDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
    }
}
