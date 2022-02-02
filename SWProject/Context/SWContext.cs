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
        public DbSet<CloneCommander>? CloneCommanders { get; set; }
        public DbSet<Jedi>? Jedies { get; set; }
        public DbSet<Legion>? Legions { get; set; }
        public DbSet<CombatDroid>? CombatDroids { get; set; }
        public DbSet<ServiceDroid>? ServiceDroids { get; set; }
        public DbSet<BaseFleet>? Fleets { get; set; }
        public DbSet<StarDestroyer>? StarDestroyers { get; set; }
        public DbSet<AssaultShip>? AssaultShipes { get; set;}
        public DbSet<StarshipWeaponry>? StarshipWeaponries { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=StoreDB;");
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


        }
    }
}
