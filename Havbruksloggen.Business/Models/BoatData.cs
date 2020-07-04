using System;
using System.Collections.Generic;
using System.Text;

namespace Havbruksloggen.Business.Models
{
    public class BoatData
    {
        public Guid? BoatId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string BuildNumber { get; set; }
        public decimal Loa { get; set; }
        public decimal B { get; set; }
        public string Picture { get; set; }

        public CrewData[] BoatCrewCollection { get; set; }
    }
}
