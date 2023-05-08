using BusinessLayer.Dtos;
using BusinessLayer.Entity;
using BusinessLayer.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BusinessLayer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new ParentMenuConfiguration());
            modelBuilder.ApplyConfiguration(new ChildMenuConfiguration());
            modelBuilder.ApplyConfiguration(new RightsDistributionConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new StateConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());

            modelBuilder.ApplyConfiguration(new ZoneConfiguration());
            modelBuilder.ApplyConfiguration(new AreaConfiguration());
            modelBuilder.ApplyConfiguration(new SocietyConfiguration());
            modelBuilder.ApplyConfiguration(new BinConfiguration());
            modelBuilder.ApplyConfiguration(new BinCollectionTransactionConfiguration());

            modelBuilder.Entity<ZoneWiseBinCollectionReport>().HasNoKey().ToView(null);


           // modelBuilder.Ignore<ZoneWiseBinCollectionReport>();

            #region Seeding Data
            modelBuilder.Entity<Application>().HasData(
                new Application
                {
                    Id = 1,
                    Name = "Web Application"
                });

            modelBuilder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "India",
                    CreatedDate = new DateTime(2021, 1, 1, 00, 0, 0, 00, DateTimeKind.Local).AddTicks(00)
                });

            //modelBuilder.Entity<Role>().HasData(
            //    new Role
            //    {
            //        Id = 1,
            //        Name = "Administrator",
            //        CreatedBy = 9999,
            //        CreatedDate = new DateTime(2021, 1, 1, 00, 0, 0, 00, DateTimeKind.Local).AddTicks(00)
            //    });
            #endregion Seeding Data
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<ParentMenu> ParentMenus { get; set; }
        public DbSet<ChildMenu> ChildMenus { get; set; }
        public DbSet<RightsDistribution> RightsDistributions { get; set; }

        public DbSet<Zone> Zones { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Society> Societies { get; set; }
        public DbSet<Bin> Bins { get; set; }
        public DbSet<BinCollectionTransaction> BinCollectionTransactions { get; set; }


    }
}
