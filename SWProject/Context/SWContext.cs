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
        public DbSet<StarDestroyer>? StarDestroyers { get; set; }
        public DbSet<AssaultShip>? AssaultShips { get; set;}
        public DbSet<StarshipWeaponry>? StarshipWeaponries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost;Initial Catalog=StoreDB;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Legion>()
                .HasOne(b => b.Commander)
                .WithMany(); //означає, що в одного легіона один командир, але в командира багато легіонів
                             //не впевнений чи це логічно, якщо ні, то треба щось трохи поміняти в зв'язках
            // Я поки це прибрав, але це треба передумати і трохи поговорити про ключі (id) і як ними користуватися для зв'язківІ
            */

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Legion)
                .WithMany()
                .HasForeignKey(clone => clone.LegionId); ; //означає, що в одного легіона багато клонів,
                                                           //але клон тільки в одному легіоні

            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Base)
                .WithMany()
                .HasForeignKey(clone => clone.BaseId);


            modelBuilder.Entity<Clone>()
                .HasOne(clone => clone.Fleet)
                .WithMany()
                .HasForeignKey(clone => clone.FleetId);


            modelBuilder.Entity<Legion>()
                .HasOne(legion => legion.GeneralJedi)
                .WithOne(jedi => jedi.Legion)
                .HasForeignKey<Legion>(a => a.GeneralJediId); //означає, що в одного легіона один джедай-генарл,
                                                              //і один джедай може керувати тільки одним легіоном

            modelBuilder.Entity<Jedi>()
                .HasOne(jedi => jedi.Padawan)
                .WithOne(jedi => jedi.Teacher)
                .HasForeignKey<Jedi>(a => a.PadawanId); //легких шляхів не шукаємо =) відразу складні випадки зв'зяків
                                                        //падаван і вчитель мають зв'язок один до одного

            modelBuilder.Entity<StarDestroyer>()    //Крейсер має багато дроїдів на борту
                .HasMany<Droid>()
                .WithOne();


            modelBuilder.Entity<StarDestroyer>()    //Крейсер має багато клонів на борту
                .HasMany<Clone>()
                .WithOne();


            modelBuilder.Entity<StarDestroyer>()
                .HasOne(starDestroyer => starDestroyer.Fleet)
                .WithMany()
                .HasForeignKey(a => a.FleetId);


            modelBuilder.Entity<AssaultShip>()
                .HasOne(assaultShip => assaultShip.Fleet)
                .WithMany()
                .HasForeignKey(a => a.FleetId);


            modelBuilder.Entity<Base>()
                .HasOne(basee => basee.AttachedFleet)
                .WithMany()
                .HasForeignKey(a => a.AttachedFleetId);


            modelBuilder.Entity<Droid>()
                .HasOne(droid => droid.Base)
                .WithMany()
                .HasForeignKey(a => a.BaseId);
            

            modelBuilder.Entity<Droid>()
                .HasOne(droid => droid.Fleet)
                .WithMany()
                .HasForeignKey(a => a.FleetId);


        }
    }
}
