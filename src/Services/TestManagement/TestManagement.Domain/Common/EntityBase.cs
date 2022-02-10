namespace TestManagement.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
        public Guid CreatedBy { get; protected set; }
        public DateTime CreatedDate { get; protected set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; protected set; }
        public Guid? UpdateGuid { get; protected set; }
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedDate= DateTime.Now;
            CreatedBy = Guid.Empty;
        }
    }
}
