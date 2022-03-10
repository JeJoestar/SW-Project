// <copyright file="BaseDto.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class BaseDto
    {
        public int? AttachedFleetId { get; set; }

        public Supply AmmoSupply { get; set; }
        
        public List<CloneDto>? Clones { get; set; }

        public List<DroidDto>? Droids { get; set; }
    }
}
