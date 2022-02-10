namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class BookingStatusEntityTypeConfiguration : IEntityTypeConfiguration<BookingStatus>
    {
        public void Configure(EntityTypeBuilder<BookingStatus> builder)
        {
            builder.ToTable("BookingStatus", ThynkContext.ENUM_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(b=>b.Name).HasMaxLength(200).IsRequired();
        }
    }
}
