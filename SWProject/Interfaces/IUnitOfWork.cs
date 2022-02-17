using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        public IGenericRepository<Clone> CloneRepository { get; }
        public IGenericRepository<Droid> DroidRepository { get; }
        public IGenericRepository<Base> BaseRepository { get; }
        public IGenericRepository<BaseFleet> FleetRepository { get; }
        public IGenericRepository<Jedi> JediRepository { get; }
        public IGenericRepository<Legion> LegionRepository { get; }
        public IGenericRepository<Starship> StarshipRepository { get; }
        public IGenericRepository<Supply> SupplyRepository { get; }
        public IGenericRepository<StarshipWeaponry> StarshipWeaponryRepository { get; }
        public void Save();
        
    }
}
