// <copyright file="Base.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Base : BaseEntity
    {
        public BaseFleet AttachedFleet { get; set; }
        public int? AttachedFleetId { get; set; }
        public List<Droid> Droids { get; set; }
        public List<Clone> Clones { get; set; }
        public int AmmoSupplyId { get; set; }
        public Supply AmmoSupply { get; set; }    
    }
}
