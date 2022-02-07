namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class ResultStatusEntityTypeConfiguration : IEntityTypeConfiguration<ResultStatus>
    {
        public void Configure(EntityTypeBuilder<ResultStatus> builder)
        {
            builder.ToTable("ResultStatus", ThynkContext.ENUM_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
        }
    }
}
