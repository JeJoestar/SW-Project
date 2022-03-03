// <copyright file="Starship.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Starship : BaseEntity
    {
        public List<Droid> Droids { get; set; }

        public List<Clone> Passangers { get; set; }

        public string PathList { get; set; }

        public Supply Supply { get; set; }

        public StarshipWeaponry Weaponry { get; set; }

        public BaseFleet Fleet { get; set; }

        public int FleetId { get; set; }

        public string Type { get; set; }
    }
}
