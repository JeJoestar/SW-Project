// <copyright file="Legion.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Legion : BaseEntity
    {
        public string Name { get; set; }

        public int GeneralJediId { get; set; }

        public Jedi GeneralJedi { get; set; }

        public List<Clone> Clones { get; set; }
    }
}
