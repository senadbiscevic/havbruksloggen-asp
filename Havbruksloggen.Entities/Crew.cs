using Havbruksloggen.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Havbruksloggen.Entities
{
    public class Crew
    {
        public Crew()
        {

        }

        public Crew(Guid? crewId)
        {
            CrewId = crewId;
        }

        public Guid? CrewId { get; set; }
        public Guid? BoatId { get; set; }
        public Boat Boat { get; set; }
        public Guid? SailorId { get; set; }
        public Sailor Sailor { get; set; }
        public CrewRoleEnum Role { get; set; }

    }
}
