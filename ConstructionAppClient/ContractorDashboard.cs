using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionApp.Shared;
using Microsoft.AspNetCore.SignalR.Client;
namespace ConstructionAppClient
{
    public partial class ContractorDashboard : Form
    {
        private SignalRClient signalRClient;
        private readonly Contractor loggedinContractor;

        private readonly User user;
        public ContractorDashboard(Contractor contractor)
        {
            InitializeComponent();
            this.loggedinContractor = contractor;
            ShowPanel(pnlContent);
            lblTitle.Text = "Welcome " + contractor.firstname;
            signalRClient = new SignalRClient();
        }

       

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlContent);
        }

        private void btnAssignWorkers_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAssignWorkers);
        }

        private void btnMySites_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlMySites);
        }
        private void ShowPanel(System.Windows.Forms.Panel selectedPanel)
        {
            pnlContent.Hide();
            pnlMySites.Hide();
            pnlAssignWorkers.Hide();
            pnlReviewUpdates.Hide();

            selectedPanel.Show();
            selectedPanel.BringToFront();

            Color selectedColor = Color.FromArgb(242, 242, 242);
            Color defaultColor = Color.White;
            btnDashboard.BackColor = selectedPanel == pnlContent ? selectedColor : defaultColor;
            btnMySites.BackColor = selectedPanel == pnlMySites ? selectedColor : defaultColor;
            btnAssignWorkers.BackColor = selectedPanel == pnlAssignWorkers ? selectedColor : defaultColor;
            btnReviewUpdates.BackColor = selectedPanel == pnlReviewUpdates ? selectedColor : defaultColor;
        }

        private void btnReviewUpdates_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlReviewUpdates);

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateSiteForm createSiteForm = new CreateSiteForm(loggedinContractor);
            createSiteForm.Show();
            
        }
    }
}
