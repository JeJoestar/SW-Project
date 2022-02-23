// <copyright file="IUnitOfWork.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public interface IUnitOfWork
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
        public Task SaveAsync();  
    }
}
