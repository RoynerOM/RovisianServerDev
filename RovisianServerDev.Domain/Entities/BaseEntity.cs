namespace RovisianServerDev.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public bool? Borrado { get; set; } = false;
    }
}
