using Havbruksloggen.Common.Enum;
using System;

namespace Havbruksloggen.RequestModels
{
    public class CrewRequestModel
    {
        public Guid? CrewId { get; set; }
        public BoatRequestModel Boat { get; set; }
        public SailorRequestModel Sailor { get; set; }
        public CrewRoleEnum Role { get; set; }
    }
}
