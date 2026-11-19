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
        private readonly WorkerApiClient workerApiClient;
        private readonly SiteApiClient siteapiclient;


        public ContractorDashboard(Contractor contractor,WorkerApiClient workerapiclient)
        {
            InitializeComponent();
            workerApiClient = workerapiclient;
            if (contractor == null || contractor.ContractorID <= 0)
                throw new ArgumentException("A valid logged-in contractor is required.", nameof(contractor));
            this.loggedinContractor = contractor;
            ShowPanel(pnlContent);
            lblTitle.Text = "Welcome " + (string.IsNullOrWhiteSpace(contractor.firstname) ? contractor.username : contractor.firstname);
            signalRClient = new SignalRClient();
            siteapiclient = new SiteApiClient();
            Shown += async (sender, args) => await LoadSitesAsync();
            l.Click += btnCreateSite_Click;
        }
        

       

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlContent);
        }

        private void btnAssignWorkers_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAssignWorkers);
        }

        private async void btnMySites_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlMySites);
            await LoadSitesAsync();
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
            LoginForm loginForm = new LoginForm(workerApiClient);
            loginForm.Show();
            this.Hide();
        }
        private async Task LoadSitesAsync()
        {
            try
            {
                List<Site> sites =
                    await siteapiclient.GetContractorSitesAsync(
                        loggedinContractor.ContractorID);

                lviewSites.Items.Clear();

                foreach (Site site in sites)
                {
                    ListViewItem item =
                        new ListViewItem(site.SiteName);

                    item.SubItems.Add(site.Address);
                    item.SubItems.Add(site.EstimatedCompletionDate.ToShortDateString());

                    

                    lviewSites.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCreateSite_Click(object sender, EventArgs e)
        {
            List<Worker> workers = await workerApiClient.GetWorkersAsync();

            using (CreateSiteForm createSiteForm =
                new CreateSiteForm(loggedinContractor,workers))
            {
                if (createSiteForm.ShowDialog() == DialogResult.OK)
                {
                    await LoadSitesAsync();
                }
                }
            }
        
        private async Task LoadWorkersAsync()
        {
            List<Worker> workers = await workerApiClient.GetWorkersAsync();
           


            cboxAssignWorker.DataSource = workers;
            cboxAssignWorker.DisplayMember = "username";
            cboxAssignWorker.ValueMember = "WorkerID";
            MessageBox.Show(
    "First worker name: [" + workers[0].firstname + "]");
            //  cboxAssignWorker.SelectedIndex = -1;
        }
       

        private async void  ContractorDashboard_Load(object sender, EventArgs e)
        {
            await LoadWorkersAsync();
        }
    }
}
