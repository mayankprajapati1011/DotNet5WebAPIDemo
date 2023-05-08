using BusinessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLayer.EntityConfiguration
{
    public  class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FullName)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.PasswordHash)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(p => p.PasswordSalt)
               .IsRequired()
               .IsUnicode(false);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.MobileNo)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(p => p.AddressLine1)
                .IsRequired(false)
                .HasColumnType("varchar(200)");

            builder.Property(u => u.CreatedDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.ModifiedDate)
               .HasColumnType("datetime");

        }
    }
}
