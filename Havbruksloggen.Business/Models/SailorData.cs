using System;
using System.Collections.Generic;
using System.Text;

namespace Havbruksloggen.Business.Models
{
    public class SailorData
    {
        public Guid? SailorId { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public DateTime CertifiedUntil { get; set; }
        public int Age { get; set; }


        public CrewData[] BoatCrewCollection { get; set; }
    }
}
