namespace RovisianServerDev.Domain.Entities
{
    public class BancoEntity:BaseEntity
    {
        public BancoEntity()
        {
            Instituciones = new HashSet<InstitucionEntity>();
        }

        public string Nombre { get; set; } = null!;

        public virtual ICollection<InstitucionEntity> Instituciones { get; set; }
    }

}
