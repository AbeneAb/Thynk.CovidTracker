using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagement.Infrastructure.EntityConfigurations
{
    public class TestCenterAvailableCapacityEntityTypeConfiguration : IEntityTypeConfiguration<TestCenterAvailableCapacity>
    {
        public void Configure(EntityTypeBuilder<TestCenterAvailableCapacity> builder)
        {
            builder.ToTable("TestCenterAvailableCapacity", ThynkContext.DEFAULT_SCHEMA);    
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id);
            builder.HasOne(x => x.TestCenter).WithOne(x => x.TestCenterAvailableCapacity).HasForeignKey<TestCenterAvailableCapacity>(x => x.TestCenterId);
        }
    }
}
