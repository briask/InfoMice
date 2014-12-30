using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositories
{
    using System.Data.Entity;
    using EventModels;

    public class ParkDBContext : DbContext
    {
        public ParkDBContext()
        {
            Database.SetInitializer(new ParkDBInitialiser());
        }

        public DbSet<ParkOperatingHours> ParkOperatingHours { get; set; }

        public DbSet<Park> Parks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
