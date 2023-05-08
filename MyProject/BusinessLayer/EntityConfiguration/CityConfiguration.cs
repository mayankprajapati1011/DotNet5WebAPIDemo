using BusinessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLayer.EntityConfiguration 
{
   public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.CreatedDate)
               .IsRequired()
               .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
               .HasColumnType("datetime");

        }
    }
}
