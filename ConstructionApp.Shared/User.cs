using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionApp.Shared
{
   
    public class User
    {
       
        public int userid { get; set;  }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        
        public Role role { get; set; }
       public enum Role
        {
            Contractor=0,
            Worker=1,
            Owner=2
        }


    }
}
