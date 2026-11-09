using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
namespace ConstructionAppClient
{
    public partial class ContractorDashboard : Form
    {
        private SignalRClient signalRClient;
        public ContractorDashboard()
        {
            InitializeComponent();
            signalRClient = new SignalRClient();
        }

       
    }
}
