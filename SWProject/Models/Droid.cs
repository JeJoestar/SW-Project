// <copyright file="Droid.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Droid : BaseEntity
    {
        public string Model { get; set; }
        public Base? Base { get; set; }
        public int? BaseId { get; set; }
        public Starship? Starship { get; set; }
        public int? StarshipId { get; set; }
        public string Equipment { get; set; }
    }
}
