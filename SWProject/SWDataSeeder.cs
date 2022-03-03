// <copyright file="SWDataSeeder.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.DAL
{
    public class SWDataSeeder
    {
        private readonly SWContext _swContext;
        public SWDataSeeder(SWContext swContext)
        {
            _swContext = swContext;
        }
        public void SeedData()
        {
            var bases = new List<Base>()
            {
                new Base()
                {
                    AttachedFleet = new BaseFleet(),
                    AmmoSupply = new Supply()
                    {
                        CartridgesCount = 1,
                        FuelLitresAmount = 4,
                        GrenadesCount = 1,
                    }
                }
            };
            _swContext.Bases.AddRange(bases);
            _swContext.SaveChanges();
            var starships = new List<Starship>()
            {
                new Starship()
                {
                    FleetId = 1,
                    PathList = "Sector 3-1",
                    Supply = new Supply()
                    {
                        CartridgesCount = 1000,
                        FuelLitresAmount = 5000,
                        GrenadesCount = 300,
                    },
                    Type = "Acclamator",
                    Weaponry = new StarshipWeaponry()
                    {
                        LaserDoubleCannonCnt = 8,
                        LaserTargetDefenseCannonCnt = 8,
                        LaserTurretCnt = 16,
                        ProtonTorpedoLauncherCnt = 2,
                    },
                },
                new Starship()
                {
                    FleetId = 1,
                    PathList = "Sector 3-1",
                    Supply = new Supply()
                    {
                        CartridgesCount = 1500,
                        FuelLitresAmount = 5000,
                        GrenadesCount = 400,
                    },
                    Type = "Acclamator",
                    Weaponry = new StarshipWeaponry()
                    {
                        LaserDoubleCannonCnt = 8,
                        LaserTargetDefenseCannonCnt = 8,
                        LaserTurretCnt = 16,
                        ProtonTorpedoLauncherCnt = 2,
                    },
                },
                new Starship()
                {
                    FleetId = 1,
                    PathList = "Sector 3-1",
                    Supply = new Supply()
                    {
                        CartridgesCount = 4000,
                        FuelLitresAmount = 15000,
                        GrenadesCount = 1000,
                    },
                    Type = "Venator",
                    Weaponry = new StarshipWeaponry()
                    {
                        LaserDoubleCannonCnt = 16,
                        LaserTargetDefenseCannonCnt = 16,
                        LaserTurretCnt = 32,
                        ProtonTorpedoLauncherCnt = 4,
                    },
                }
            };
            var jedis = new List<Jedi>()
            {
                new Jedi()
                {
                    Name = "Enakin Skywalker",
                    PadawanId = 2,
                    TeacherId = null,
                },
                new Jedi()
                {
                    Name = "Asoka Tano",
                    PadawanId = null,
                    TeacherId = 1,
                },
                new Jedi()
                {
                    Name = "Yoda",
                    PadawanId = null,
                    TeacherId = null,
                },
                new Jedi()
                {
                    Name = "Obi-Wan Kenobi",
                    PadawanId = null,
                    TeacherId = null,
                }
            };

            _swContext.Starships.AddRange(starships);
            _swContext.Jedis.AddRange(jedis);
            _swContext.SaveChanges();

            var legions = new List<Legion>()
            {
                new Legion()
                {
                    Name = "501th",
                    GeneralJediId = 1,
                },
                new Legion()
                {
                    Name = "41st",
                    GeneralJediId = 3,
                },
                new Legion()
                {
                    Name = "212th",
                    GeneralJediId = 4,
                },
            };
            _swContext.Legions.AddRange(legions);

            jedis.ForEach(jedi => jedi.LegionId = 1);
            jedis.First(jedi => jedi.Name == "Yoda").LegionId = 2;    
            jedis.First(jedi => jedi.Name == "Obi-Wan Kenobi").LegionId = 3;    
            _swContext.SaveChanges();
            
            var clones = new List<Clone>()
            {
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "2710",
                    StarshipId = 1,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "8008",
                    StarshipId = 1,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "3212",
                    StarshipId = 3,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "3333",
                    StarshipId = 2,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "2711",
                    StarshipId = 2,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "2330",
                    StarshipId = 3,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "4344",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "8118",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = null,
                    LegionId = 3,
                    Number = "4442",
                    StarshipId = 3,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "3003",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "1132",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "1012",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "5890",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "6666",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "2221",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "9980",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "0003",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "5433",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "7777",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "7073",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "6909",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "4040",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "3131",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "2090",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "1121",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "1123",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "0404",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "0999",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "4509",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "6303",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "5553",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "5555",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "2121",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "4180",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "4100",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "3456",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "9876",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "3000",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "3202",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "1002",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "0002",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "4803",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "3200",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "7000",
                    StarshipId = null,
                    Equipment = "DC-15X",
                    Qualification = "ARF",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "0009",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "ARC",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "4321",
                    StarshipId = null,
                    Equipment = "DC-15S",
                    Qualification = "Assault",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "6930",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "Engineer",
                },
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 2,
                    Number = "0906",
                    StarshipId = null,
                    Equipment = "DC-15A",
                    Qualification = "None",
                }
            };
            var droids = new List<Droid>()
            {
                new Droid()
                {
                    BaseId = 1,
                    Model = "R2D2",
                    StarshipId = null,
                }
            };

            _swContext.Clones.AddRange(clones);
            _swContext.Droids.AddRange(droids);
            _swContext.SaveChanges();
        }
    }
}
