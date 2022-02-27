// <copyright file="CloneDTO.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace SW.DAL
{
    public class CloneDTO
    {
        [Required]
        [StringLength(4)]
        public string Number { get; set; }
        [Required]
        public int LegionId { get; set; }
        public int? BaseId { get; set; }
        public int? StarshipId { get; set; }
        [Required]
        public string Equipment { get; set; }
        public string Qualification { get; set; }
    }
}
