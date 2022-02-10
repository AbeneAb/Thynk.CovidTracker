namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", ThynkContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique(true);
            builder.HasIndex(x => x.Email).IsClustered(false).IsUnique(true);
            builder.HasIndex(x => x.FirstName).IsClustered(false);
            builder.HasIndex(x => x.LastName).IsClustered(false);
            builder.Property<int>("_genderId").
                UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("GenderId").IsRequired();  
            builder.Property<int>("_roleId").
                UsePropertyAccessMode(PropertyAccessMode.Field).HasColumnName("RoleId").IsRequired();
            builder.HasMany(b=>b.Bookings).WithOne(b => b.User).HasForeignKey(b => b.UserId);

            builder.HasMany(b => b.TestCenterLogs).WithOne(b => b.User).HasForeignKey(t => t.UserId);
            builder.HasOne(u => u.Gender).WithMany().HasForeignKey("_genderId");
            builder.HasOne(u => u.UserRole).WithMany().HasForeignKey("_roleId");
        }
    }
}
