using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWProject
{
    public class SWContext : DbContext
    {
        public DbSet<Base>? Base { get; set; }
        public DbSet<Supply>? Supplies { get; set; }
        public DbSet<Clone>? Clones { get; set; }
        public DbSet<Jedi>? Jedies { get; set; }
        public DbSet<Legion>? Legions { get; set; }
        public DbSet<BaseFleet>? Fleets { get; set; }
        public DbSet<Starship>? Starships { get; set; }
        public DbSet<StarshipWeaponry>? StarshipWeaponries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=StoreDB;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Legion)
                .WithMany(legion => legion.Clones)
                .HasForeignKey(clone => clone.LegionId)
                .OnDelete(DeleteBehavior.ClientCascade);
                                                           

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Base)
                .WithMany(basee => basee.Clones)
                .HasForeignKey(clone => clone.BaseId)
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Legion>()
                .HasOne(legion => legion.GeneralJedi)
                .WithOne(jedi => jedi.Legion)
                .HasForeignKey<Legion>(a => a.GeneralJediId); 
                                                              

            modelBuilder.Entity<Jedi>()
                .HasOne(jedi => jedi.Padawan)
                .WithOne(jedi => jedi.Teacher)
                .HasForeignKey<Jedi>(a => a.PadawanId); 
                                                        

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Starship)
                .WithMany(starDestroyer => starDestroyer.Passangers)
                .HasForeignKey(a => a.StarshipId)
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Droid>()
                .HasOne(droid => droid.Starship)
                .WithMany(starDestroyer => starDestroyer.Droids)
                .HasForeignKey(a => a.StarshipId)
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Starship>()
                .HasOne(starDestroyer => starDestroyer.Fleet)
                .WithMany(fleet => fleet.Starships)
                .HasForeignKey(a => a.FleetId)
                .OnDelete(DeleteBehavior.ClientCascade);


            modelBuilder.Entity<Base>()
                .HasOne(basee => basee.AttachedFleet)
                .WithMany(fleet => fleet.AttachedBases)
                .HasForeignKey(a => a.AttachedFleetId);


            modelBuilder.Entity<Droid>()
                .HasOne(droid => droid.Base)
                .WithMany(basee => basee.Droids)
                .HasForeignKey(a => a.BaseId)
                .OnDelete(DeleteBehavior.ClientCascade);
            

        }
    }
}
