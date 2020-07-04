using System;
using System.Collections.ObjectModel;

namespace Havbruksloggen.Entities
{
    public class Boat
    {
        public Boat()
        {

        }

        public Boat(Guid? boatId)
        {
            BoatId = boatId;
        }

        public Guid? BoatId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string BuildNumber { get; set; }
        public decimal Loa { get; set; }
        public decimal B { get; set; }
        public string Picture { get; set; }

        public Collection<Crew> BoatCrewCollection { get; set; }

    }
}
