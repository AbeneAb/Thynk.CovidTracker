namespace TestManagement.Infrastructure.EntityConfigurations
{
    internal class BookingEntityTypeConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking", ThynkContext.DEFAULT_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.Id).IsUnique(true);
            builder.Property(b=>b.BookDate).HasColumnName("BookingDate").IsRequired();
            builder.Property<int>("_bookingStatus").
                UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("BookingStatus").IsRequired();
            builder.HasOne(b => b.TestCenter).
                WithMany(t => t.Bookings).HasForeignKey(b => b.TestCenterId).
                IsRequired(true);
            builder.HasOne(b => b.BookingStatus).WithMany().HasForeignKey("_bookingStatus");
            builder.HasOne(b=>b.User).
                WithMany(b=>b.Bookings).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
