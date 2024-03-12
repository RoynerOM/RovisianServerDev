namespace RovisianServerDev.Domain.Entities
{
    public class RutaEntity
    {
        public RutaEntity()
        {
            Instituciones = new HashSet<InstitucionEntity>();
        }

        public int RutaId { get; set; }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<InstitucionEntity> Instituciones { get; set; }
    }

}
