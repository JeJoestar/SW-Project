// <copyright file="StarshipWeaponry.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class StarshipWeaponry : BaseEntity
    {
        public int LaserTurretCnt { get; set; }
        public int LaserDoubleCannonCnt { get; set; }
        public int LaserTargetDefenseCannonCnt { get; set; }
        public int ProtonTorpedoLauncherCnt { get; set; }
    }
}
