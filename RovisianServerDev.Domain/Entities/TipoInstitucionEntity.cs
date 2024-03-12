namespace RovisianServerDev.Domain.Entities
{
    public class TipoInstitucionEntity
    {
        public TipoInstitucionEntity()
        {
            Instituciones = new HashSet<InstitucionEntity>();
        }

        public int TipoId { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<InstitucionEntity> Instituciones { get; set; }
    }
}
