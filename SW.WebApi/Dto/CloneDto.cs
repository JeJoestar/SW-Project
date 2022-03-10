// <copyright file="CloneDto.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class CloneDto
    {
        public string Number { get; set; }
        public int LegionId { get; set; }
        public int? BaseId { get; set; }
        public int? StarshipId { get; set; }
        public string Equipment { get; set; }
        public string Qualification { get; set; }
    }
}
