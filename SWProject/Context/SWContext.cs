using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace SW.DAL
{
    public class SWContext : DbContext
    {
        public DbSet<Base> Bases { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Clone> Clones { get; set; }
        public DbSet<Droid> Droids { get; set; }
        public DbSet<Jedi> Jedis { get; set; }
        public DbSet<Legion> Legions { get; set; }
        public DbSet<BaseFleet> Fleets { get; set; }
        public DbSet<Starship> Starships { get; set; }
        public DbSet<StarshipWeaponry> StarshipWeaponries { get; set; }

        private string _connectionString;

        public SWContext()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false)
                .Build();

            _connectionString = configuration.GetConnectionString("SWDatabase");
        }

        public SWContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Legion)
                .WithMany(legion => legion.Clones)
                .HasForeignKey(clone => clone.LegionId);
                                                           

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Base)
                .WithMany(basee => basee.Clones)
                .HasForeignKey(clone => clone.BaseId);


            modelBuilder.Entity<Legion>()
                .HasOne(legion => legion.GeneralJedi)
                .WithOne(jedi => jedi.Legion)
                .HasForeignKey<Legion>(a => a.GeneralJediId); 
                                                              

            modelBuilder.Entity<Jedi>()
                .HasOne(jedi => jedi.Padawan)
                .WithOne(jedi => jedi.Teacher)
                .HasForeignKey<Jedi>(a => a.PadawanId)
                .OnDelete(DeleteBehavior.ClientSetNull); 
                                                        

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Starship)
                .WithMany(starDestroyer => starDestroyer.Passangers)
                .HasForeignKey(a => a.StarshipId);


            modelBuilder.Entity<Droid>()
                .HasOne(droid => droid.Starship)
                .WithMany(starDestroyer => starDestroyer.Droids)
                .HasForeignKey(a => a.StarshipId);


            modelBuilder.Entity<Starship>()
                .HasOne(starDestroyer => starDestroyer.Fleet)
                .WithMany(fleet => fleet.Starships)
                .HasForeignKey(a => a.FleetId);


            modelBuilder.Entity<Base>()
                .HasOne(basee => basee.AttachedFleet)
                .WithMany(fleet => fleet.AttachedBases)
                .HasForeignKey(a => a.AttachedFleetId);


            modelBuilder.Entity<Droid>()
                .HasOne(droid => droid.Base)
                .WithMany(basee => basee.Droids)
                .HasForeignKey(a => a.BaseId);
            

        }
    }
}
