using BusinessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLayer.EntityConfiguration
{
    public class BinConfiguration : IEntityTypeConfiguration<Bin>
    {
        public void Configure(EntityTypeBuilder<Bin> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Type)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");
        }
    }
}
