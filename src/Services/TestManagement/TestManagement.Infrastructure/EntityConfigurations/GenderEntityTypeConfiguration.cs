namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class GenderEntityTypeConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender", ThynkContext.ENUM_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
        }
    }
}
