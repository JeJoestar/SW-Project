// <copyright file="DroidDto.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace SW.DAL
{
    public class DroidDto
    {
        [Required]
        public string Model { get; set; }
        public int? BaseId { get; set; }
        public int? StarshipId { get; set; }
        public string Equipment { get; set; }
    }
}
