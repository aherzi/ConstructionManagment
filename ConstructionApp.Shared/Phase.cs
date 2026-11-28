using System;
using System.Collections.Generic;
using System.Text;


namespace ConstructionApp.Shared
{
    public class Phase
    {
        public int PhaseID { get; set; }
        public Site site { get; set; }
        public Stage stage { get; set; }

        public string Description { get; set; }
        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
        public decimal PercentComplete { get; set; }
        public enum Stage
        {
            Plannning,
            Foundation,
            Framing,
            Roofing,
            Electrical,
            Plumbing,
            Finishing
        }
        
    }
}
