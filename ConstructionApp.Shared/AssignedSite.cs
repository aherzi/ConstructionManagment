using System;

namespace ConstructionApp.Shared
{
    public class AssignedSite
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public DateTime? DateAssigned { get; set; }
        public string AssignmentStatus { get; set; }
    }
}
