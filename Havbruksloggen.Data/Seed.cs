using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Havbruksloggen.Entities;
using FizzWare.NBuilder;
using Bogus;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using Havbruksloggen.Common.Enum;

namespace Havbruksloggen.Data
{
    public class Seed
    {
        public Seed(ModelBuilder modelBuilder)
        {
            var faker = new Faker
            {
                Locale = "en"
            };

            var boats = Builder<Boat>.CreateListOfSize(20)
                .All()
                    .With(c => c.BoatId = Guid.NewGuid())
                    .With(c => c.Name = faker.Name.FirstName(Bogus.DataSets.Name.Gender.Female))
                    .With(c => c.Producer = faker.Name.LastName())
                    .With(c => c.BuildNumber = faker.Random.String2(12, 12, "ABCDEFGHIJKLMNOPRSTUVZX0123456789"))
                    .With(c => c.Loa = (short)faker.Random.Decimal(11, 20))
                    .With(c => c.B = (short)faker.Random.Decimal(4, 6))
                    .With(c => c.Picture = "https://picsum.photos/200/300?random=" + faker.Random.Number(1, 1024))
                .Build().ToList();

            var sailors = Builder<Sailor>.CreateListOfSize(80)
                .All()
                    .With(c => c.SailorId = Guid.NewGuid())
                    .With(c => c.Name = faker.Name.FullName())
                    .With(c => c.Picture = "https://picsum.photos/200/300?random=" + faker.Random.Number(1, 1024))
                    .With(c => c.Email = c.Name.Replace(" ", string.Empty).ToLower() + "@havbruksloggen.no")
                    .With(c => c.BirthDate = faker.Date.Past(20, DateTime.Now.AddYears(-20)))
                    .With(c => c.CertifiedUntil = faker.Date.Future(1, DateTime.Now.AddMonths(-3)))
                .Build().ToList();

            var crews = new List<Crew>();
            foreach (var boat in boats)
            {
                for (int i = 0; i < 4; i++)
                {
                    crews.Add(new Crew()
                    {
                        CrewId = Guid.NewGuid(),
                        BoatId = boat.BoatId,
                        SailorId = Pick<Sailor>.RandomItemFrom(sailors).SailorId,
                        Role = (CrewRoleEnum)i
                    });
                }
            }


            modelBuilder.Entity<Boat>().HasData(boats.ToArray());
            modelBuilder.Entity<Sailor>().HasData(sailors.ToArray());
            modelBuilder.Entity<Crew>().HasData(crews.ToArray());
        }
    }
}
