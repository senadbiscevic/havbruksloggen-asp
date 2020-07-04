using Havbruksloggen.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Havbruksloggen.Business.Models
{
    public class CrewData
    {
        public Guid? CrewId { get; set; }
        public BoatData Boat { get; set; }
        public SailorData Sailor { get; set; }
        public CrewRoleEnum Role { get; set; }
    }
}
