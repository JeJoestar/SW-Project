// <copyright file="BaseFleet.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class BaseFleet : BaseEntity
    {
        public string Fraction { get; set; }

        public List<Base>? AttachedBases { get; set; } 

        public List<Starship> Starships { get; set; }
    }
}