using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructionApp.Shared
{
    public class Site
    {
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public Contractor contractor { get; set; }
        public List<Worker> workers { get; set; }
        public Owner owner { get; set; }
        public Zoning zoning { get; set; }
        public enum Zoning
        {
            Residential = 0,
            Commercial = 1,
            Industrial = 2
        }
    }
}
