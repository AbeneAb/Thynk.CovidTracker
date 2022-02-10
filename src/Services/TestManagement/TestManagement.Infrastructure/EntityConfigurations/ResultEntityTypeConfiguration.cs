namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class ResultEntityTypeConfiguration : IEntityTypeConfiguration<Result>
    {
        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Result", ThynkContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);  
            builder.HasIndex(x => x.Id).IsUnique(true);
            builder.Property<int>("_resultStatusId").
                UsePropertyAccessMode(PropertyAccessMode.Field).
                HasColumnName("ResultStatusId").IsRequired();
            builder.Property(p => p.ResultIssuedDate).
                HasColumnName("ResultIssueDate").IsRequired(false);
            builder.HasOne(r=>r.Booking).WithOne(b => b.Result).HasForeignKey<Result>(r=>r.BookingId).IsRequired(true);
            builder.HasOne(r => r.Status).WithMany().HasForeignKey("_resultStatusId");
        }
    }
}
