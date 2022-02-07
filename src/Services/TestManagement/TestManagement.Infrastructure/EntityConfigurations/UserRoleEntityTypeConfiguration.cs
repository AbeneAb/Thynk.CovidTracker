namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class UserRoleEntityTypeConfiguration : IEntityTypeConfiguration<UserRoles>
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable("UserRole", ThynkContext.ENUM_SCHEMA);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).HasDefaultValue(1).ValueGeneratedNever().IsRequired();
            builder.Property(b => b.Name).HasMaxLength(200).IsRequired();
        }
    }
}
