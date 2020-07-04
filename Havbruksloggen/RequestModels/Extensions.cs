using Havbruksloggen.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Havbruksloggen.RequestModels
{
    public static class Extensions
    {
        public static Boat GetBoat(this BoatRequestModel requestModel)
        {
            return new Boat
            {
                BoatId = requestModel.BoatId == null ? Guid.NewGuid() : requestModel.BoatId,
                Name = requestModel.Name,
                Producer = requestModel.Producer,
                BuildNumber = requestModel.BuildNumber,
                Loa = requestModel.Loa,
                B = requestModel.B,
                Picture = requestModel.Picture
            };
        }

        public static IEnumerable<Crew> GetCrew(this BoatRequestModel requestModel)
        {
            if (requestModel.BoatCrewCollection == null)
                yield break;

            foreach (var crewMember in requestModel.BoatCrewCollection)
            {

                yield return new Crew
                {
                    CrewId = crewMember.CrewId,
                    BoatId = crewMember.Boat == null ? null : crewMember.Boat.BoatId,
                    SailorId = crewMember.Sailor == null ? null : crewMember.Sailor.SailorId,
                    Role = crewMember.Role
                };
            }
        }

        public static Sailor GetSailor(this SailorRequestModel requestModel)
        {
            return new Sailor
            {
                SailorId = requestModel.SailorId == null ? Guid.NewGuid() : requestModel.SailorId,
                Name = requestModel.Name,
                Picture = requestModel.Picture,
                BirthDate = requestModel.BirthDate,
                Email = requestModel.Email,
                CertifiedUntil = requestModel.CertifiedUntil
            };
        }
    }
}
