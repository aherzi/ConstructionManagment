using System;
using System.Collections.Generic;
using System.Text;


namespace ConstructionApp.Shared
{
    public class ConstructionSite
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public int OwnerID { get; set; }
        public int ContractorID { get; set; }
        public DateTime StartDate { get; set; }
    }
}
