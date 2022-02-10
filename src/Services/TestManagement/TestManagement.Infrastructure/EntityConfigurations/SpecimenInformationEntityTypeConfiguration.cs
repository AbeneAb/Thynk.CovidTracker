using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class SpecimenInformationEntityTypeConfiguration : IEntityTypeConfiguration<SpecimenInformation>
    {
        public void Configure(EntityTypeBuilder<SpecimenInformation> builder)
        {
            builder.ToTable("SpecimenInformation", ThynkContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique(true);
            builder.Property<int>("_specimenTypeId").
                UsePropertyAccessMode(PropertyAccessMode.Field).
                HasColumnName("SpecimenTypeId").IsRequired(true);
            builder.HasOne(b => b.Booking).WithOne(b => b.SpecimenInformation).
                HasForeignKey<SpecimenInformation>(b => b.BookingId).IsRequired(true);
            builder.HasOne(b => b.SpecimenTypes).WithMany().HasForeignKey("_specimenTypeId");


        }
    }
}
