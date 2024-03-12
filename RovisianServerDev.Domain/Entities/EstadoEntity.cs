namespace RovisianServerDev.Domain.Entities
{
    public partial class EstadoEntity : BaseEntity
    {
        public EstadoEntity()
        {
            Casos = new HashSet<CasoEntity>();
        }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<CasoEntity> Casos { get; set; }
    }
}
