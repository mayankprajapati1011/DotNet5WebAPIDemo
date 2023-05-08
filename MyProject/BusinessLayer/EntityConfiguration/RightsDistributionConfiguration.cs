using BusinessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLayer.EntityConfiguration
{
    public class RightsDistributionConfiguration : IEntityTypeConfiguration<RightsDistribution>
    {
        public void Configure(EntityTypeBuilder<RightsDistribution> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.AllowView)
               .IsRequired();
            builder.Property(p => p.AllowAdd)
                .IsRequired();
            builder.Property(p => p.AllowUpdate)
                .IsRequired();
            builder.Property(p => p.AllowDelete)
                .IsRequired();
            builder.Property(p => p.AllowPrint)
                .IsRequired();
        }
    }
}
