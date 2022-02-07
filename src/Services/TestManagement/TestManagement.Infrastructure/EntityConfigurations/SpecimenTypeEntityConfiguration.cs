namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class SpecimenTypeEntityConfiguration : IEntityTypeConfiguration<SpecimenTypes>
    {
        public void Configure(EntityTypeBuilder<SpecimenTypes> builder)
        {
            builder.ToTable("SpecimenType", ThynkContext.ENUM_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
        }
    }
}
