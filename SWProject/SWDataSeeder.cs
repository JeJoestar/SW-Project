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
                }
            };

            _swContext.Bases.AddRange(bases);
            _swContext.Jedis.AddRange(jedis);
            _swContext.SaveChanges();

            var legions = new List<Legion>()
            {
                new Legion()
                {
                    Name = "501th",
                    GeneralJediId = 1,
                }
            };
            _swContext.Legions.AddRange(legions);

            jedis.ForEach(jedi => jedi.LegionId = 1);

            _swContext.SaveChanges();
            
            var clones = new List<Clone>()
            {
                new Clone()
                {
                    BaseId = 1,
                    LegionId = 1,
                    Number = "2710",
                    StarshipId = null,
                    Equipment = "DX-15A",
                    Qualification = "Engineer",
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
