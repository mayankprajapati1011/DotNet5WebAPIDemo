using BusinessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLayer.EntityConfiguration
{
    public class BinCollectionTransactionConfiguration : IEntityTypeConfiguration<BinCollectionTransaction>
    {
        public void Configure(EntityTypeBuilder<BinCollectionTransaction> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Date)
               .IsRequired()
               .HasColumnType("datetime");

            
        }
    }
}
