using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionAppClient
{
    internal class Site
    {
        int siteid;
        string sitename;
        string address;
        DateTime start;
        enum Status
        {
            NotStarted,
            inProgress,
            Completed


        }
        Status status;
    }
}
