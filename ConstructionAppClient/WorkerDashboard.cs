using ConstructionApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

    public partial class WorkerDashboard : Form
    {
        private SignalRClient SignalRClient;
        public WorkerDashboard(User userSession)
        {
            InitializeComponent();
            User user = userSession;
            lblTitle.Text = "Welcome " + user.username;
            ShowPanel(pnlContent);
            SignalRClient = new SignalRClient();

        }

        private void btnMySites_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlMySites);

        }
        private void ShowPanel(System.Windows.Forms.Panel selectedPanel)
        {
            pnlContent.Hide();
            pnlMySites.Hide();
            pnlSubmitUpdates.Hide();
            pnlSubmissions.Hide();

            selectedPanel.Show();
            selectedPanel.BringToFront();

            Color selectedColor = Color.FromArgb(242, 242, 242);
            Color defaultColor = Color.White;
            btnDashboard.BackColor = selectedPanel == pnlContent ? selectedColor : defaultColor;
            btnMySites.BackColor = selectedPanel == pnlMySites ? selectedColor : defaultColor;
            btnSubmitUpdates.BackColor = selectedPanel == pnlSubmitUpdates ? selectedColor : defaultColor;
            btnSubmissions.BackColor = selectedPanel == pnlSubmissions ? selectedColor : defaultColor;
        }

        private void btnSubmitUpdates_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlSubmitUpdates);
        }

        private void btnSubmissions_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlSubmissions);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlContent);
        }
    }

}
