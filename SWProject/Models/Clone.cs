// <copyright file="Clone.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Clone : BaseEntity
    {
        public string Number { get; set; }
        public Legion Legion { get; set; }
        public int LegionId { get; set; }
        public Base? Base { get; set; }
        public int? BaseId { get; set; }
        public Starship? Starship { get; set; }
        public int? StarshipId { get; set; }
        public string Equipment { get; set; }
        public string Qualification { get; set; }
    }
}
