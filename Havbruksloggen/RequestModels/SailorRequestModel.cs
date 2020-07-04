using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Havbruksloggen.RequestModels
{
    public class SailorRequestModel
    {
        public Guid? SailorId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime CertifiedUntil { get; set; }


        public CrewRequestModel[] BoatCrewCollection { get; set; }
    }
}
