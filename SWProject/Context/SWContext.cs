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
    }
}
