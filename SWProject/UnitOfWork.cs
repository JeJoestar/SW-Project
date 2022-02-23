// <copyright file="UnitOfWork.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SWContext _swContext;

        public UnitOfWork(SWContext swContext)
        {
            _swContext = swContext;
        }

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
            => _cloneRepository ??= new GenericRepository<Clone>(_swContext);

        public IGenericRepository<Droid> DroidRepository
            => _droidRepository ??= new GenericRepository<Droid>(_swContext);

        public IGenericRepository<Base> BaseRepository
            => _baseRepository ??= new GenericRepository<Base>(_swContext);

        public IGenericRepository<BaseFleet> FleetRepository 
            => _fleetRepository ??= new GenericRepository<BaseFleet>(_swContext);

        public IGenericRepository<Jedi> JediRepository 
            => _jediRepository ??= new GenericRepository<Jedi>(_swContext);

        public IGenericRepository<Legion> LegionRepository 
            => _legionRepository ??= new GenericRepository<Legion>(_swContext);

        public IGenericRepository<Starship> StarshipRepository 
            => _starshipRepository ??= new GenericRepository<Starship>(_swContext);

        public IGenericRepository<Supply> SupplyRepository 
            => _supplyRepository ??= new GenericRepository<Supply>(_swContext);

        public IGenericRepository<StarshipWeaponry> StarshipWeaponryRepository 
            => _starshipWeaponryRepository ??= new GenericRepository<StarshipWeaponry>(_swContext);

        public async Task SaveAsync()
        {
            await _swContext.SaveChangesAsync();
        }
    }
}
