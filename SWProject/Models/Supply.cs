// <copyright file="Supply.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class Supply : BaseEntity
    {
        public int CartridgesCount { get; set; }

        public int GrenadesCount { get; set; }

        public int FuelLitresAmount { get; set; }
    }
}
