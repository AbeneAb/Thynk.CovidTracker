namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class TestCenterEntityTypeConfiguration : IEntityTypeConfiguration<TestCenter>
    {
        public void Configure(EntityTypeBuilder<TestCenter> builder)
        {
            builder.ToTable("TestCenter", ThynkContext.DEFAULT_SCHEMA);
            builder.HasKey(t=>t.Id);
            builder.HasIndex(t=>t.Id).IsUnique(true);
            builder.HasIndex(t => t.Name).IsUnique(true).IsClustered(false);
            builder.Property(t => t.Name).HasMaxLength(400);
            builder.Property(t => t.Capacity).HasDefaultValue(0).IsRequired(true);
            builder.HasMany(t=>t.Bookings).WithOne(b=>b.TestCenter).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(t => t.TestCenterAvailableCapacity).WithOne(c => c.TestCenter).HasForeignKey<TestCenterAvailableCapacity>(c => c.TestCenterId);
            builder.OwnsOne(t => t.Address, a => {
                a.WithOwner(); 
            });
        }
    }
}
