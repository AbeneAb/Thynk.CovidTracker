namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class TestCenterLogEntityTypeConfiguration : IEntityTypeConfiguration<TestCenterLog>
    {
        public void Configure(EntityTypeBuilder<TestCenterLog> builder)
        {
            builder.ToTable("TestCenterInventory", ThynkContext.DEFAULT_SCHEMA);
            builder.HasKey(e => e.Id);  
            builder.HasIndex(e => e.Id).IsUnique();
            builder.HasOne(e => e.Booking).
                WithOne(b => b.TestCenterLog).
                HasForeignKey<TestCenterLog>(t => t.BookingId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(t=>t.TestCenter).
                WithMany(t=>t.TestCenterLogs).
                HasForeignKey(t=>t.TestCenterId).IsRequired().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(b=>b.User).
                WithMany(u=>u.TestCenterLogs).
                HasForeignKey(t=>t.UserId).IsRequired().OnDelete(DeleteBehavior.Restrict);


        }
    }
}
