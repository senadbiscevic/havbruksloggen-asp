using System;

namespace Havbruksloggen.RequestModels
{
    public class BoatRequestModel
    {
        public Guid? BoatId { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string BuildNumber { get; set; }
        public decimal Loa { get; set; }
        public decimal B { get; set; }
        public string Picture { get; set; }

        public CrewRequestModel[] BoatCrewCollection { get; set; }
    }
}
