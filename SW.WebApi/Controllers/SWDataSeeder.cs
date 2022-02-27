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
            
            var fleets = new List<BaseFleet>()
            {
                new BaseFleet()
                {
                    Id = 1,
                }
            };
            var bases = new List<Base>()
            {
                new Base()
                {
                    Id = 1,
                    AttachedFleetId = 1,
                }
            };
            var jedis = new List<Jedi>()
            {
                new Jedi()
                {
                    Id = 1,
                    LegionId = 1,
                    Name = "Enakin Skywalker",
                    PadawanId = 2,
                    TeacherId = null,
                },
                new Jedi()
                {
                    Id = 2,
                    LegionId = 1,
                    Name = "Asoka Tano",
                    PadawanId = null,
                    TeacherId = 1,
                }
            };
            var legions = new List<Legion>()
            {
                new Legion()
                {
                    Id = 1,
                    Name = "501th",
                    GeneralJediId = 1,
                }
            };
            var clones = new List<Clone>()
            {
                new Clone()
                {
                    Id = 1,
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
                    Id = 1,
                    BaseId = 1,
                    Model = "R2D2",
                    StarshipId = null,
                }
            };
            _swContext.Fleets.AddRange(fleets);
            _swContext.Bases.AddRange(bases);
            _swContext.Legions.AddRange(legions);
            _swContext.Jedis.AddRange(jedis);
            _swContext.Clones.AddRange(clones);
            _swContext.Droids.AddRange(droids);
            _swContext.SaveChanges();
        }
    }
}
