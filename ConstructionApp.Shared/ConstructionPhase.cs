using System;
using System.Collections.Generic;
using System.Text;


namespace ConstructionApp.Shared
{
    public class ConstructionPhase
    {
        public int PhaseID { get; set; }
        public int SiteID { get; set; }
        public string Stage { get; set; }
        public string Description { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
        public int PercentComplete { get; set; }
    }
}
