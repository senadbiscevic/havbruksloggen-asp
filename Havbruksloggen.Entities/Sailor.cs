using System;
using System.Collections.ObjectModel;

namespace Havbruksloggen.Entities
{
    public class Sailor
    {
        public Sailor()
        {

        }

        public Sailor(Guid? sailorId)
        {
            SailorId = sailorId;
        }

        public Guid? SailorId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime CertifiedUntil { get; set; }


        public Collection<Crew> BoatCrewCollection { get; set; }
    }
}
