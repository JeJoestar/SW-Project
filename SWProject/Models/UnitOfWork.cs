using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private SWContext _swContext = new SWContext();
        private IGenericRepository<Clone> _cloneRepository;
        private IGenericRepository<Legion> _legionRepository;
        private IGenericRepository<Droid> _droidRepository;
        private IGenericRepository<Jedi> _jediRepository;
        private IGenericRepository<Base> _baseRepository;
        private IGenericRepository<BaseFleet> _fleetRepository;
        private IGenericRepository<Starship> _starshipRepository;
        private IGenericRepository<Supply> _supplyRepository;
        private IGenericRepository<StarshipWeaponry> _starshipWeaponryRepository;

        public IGenericRepository<Clone> CloneRepository
            => _cloneRepository ?? (_cloneRepository = new GenericRepository<Clone>(_swContext));

        public IGenericRepository<Droid> DroidRepository
            => _droidRepository ?? (_droidRepository = new GenericRepository<Droid>(_swContext));

        public IGenericRepository<Base> BaseRepository
            => _baseRepository ?? (_baseRepository = new GenericRepository<Base>(_swContext));

        public IGenericRepository<BaseFleet> FleetRepository 
            => _fleetRepository ?? (_fleetRepository = new GenericRepository<BaseFleet>(_swContext));

        public IGenericRepository<Jedi> JediRepository 
            => _jediRepository ?? (_jediRepository = new GenericRepository<Jedi>(_swContext));

        public IGenericRepository<Legion> LegionRepository 
            => _legionRepository ?? (_legionRepository = new GenericRepository<Legion>(_swContext));

        public IGenericRepository<Starship> StarshipRepository 
            => _starshipRepository ?? (_starshipRepository = new GenericRepository<Starship>(_swContext));

        public IGenericRepository<Supply> SupplyRepository 
            => _supplyRepository ?? (_supplyRepository = new GenericRepository<Supply>(_swContext));

        public IGenericRepository<StarshipWeaponry> StarshipWeaponryRepository 
            => _starshipWeaponryRepository ?? (_starshipWeaponryRepository = new GenericRepository<StarshipWeaponry>(_swContext));

        public async Task SaveAsync()
        {
            await _swContext.SaveChangesAsync();
        }
 
    }
}
