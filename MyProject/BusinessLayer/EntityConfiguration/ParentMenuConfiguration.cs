using BusinessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLayer.EntityConfiguration
{
    public class ParentMenuConfiguration : IEntityTypeConfiguration<ParentMenu>
    {
        public void Configure(EntityTypeBuilder<ParentMenu> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(p => p.DisplayName)
                .IsRequired()
                .HasColumnType("varchar(40)");

            builder.Property(p => p.OrderCode)
                .IsRequired();

            builder.Property(p => p.ImageUrl)
               .IsRequired(false)
               .HasColumnType("varchar(20)");

            builder.Property(p => p.IsActive)
              .IsRequired(true)
              .HasDefaultValue(1);

        }
    }
}
