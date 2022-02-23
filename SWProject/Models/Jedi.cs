// <copyright file="Jedi.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Jedi : BaseEntity
    {
        public string Name { get; set; }

        public int? PadawanId { get; set; }
        public Jedi? Padawan { get; set; }

        public int? TeacherId { get; set; }
        public Jedi? Teacher { get; set; }

        public int? LegionId { get; set; }
        public Legion? Legion { get; set; }
    }
}