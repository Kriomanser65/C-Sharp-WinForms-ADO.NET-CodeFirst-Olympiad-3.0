using Olympiad_3._0.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Olympiad_3._0.ContextClases
{
    public class OlympicContext : DbContext
    {
        

        public DbSet<OlympicGame> OlympicGames { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<Medal> Medals { get; set; }
        public DbSet<CountryMedalStanding> CountryMedalStandings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sport>()
                .HasMany(s => s.Medals)
                .WithRequired(m => m.Sport)
                .HasForeignKey(m => m.SportId)
                .WillCascadeOnDelete(false);
        }
    }
}
