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
        private readonly WorkerApiClient workerApiClient;
        private readonly SiteApiClient siteapiclient;


        public ContractorDashboard(Contractor contractor,WorkerApiClient workerapiclient,User loggedinUser)
        {
            InitializeComponent();
            user = loggedinUser;
            workerApiClient = workerapiclient;
            if (contractor == null || contractor.ContractorID <= 0)
                throw new ArgumentException("A valid logged-in contractor is required.", nameof(contractor));
            this.loggedinContractor = contractor;
            ShowPanel(pnlContent);
            lblTitle.Text = "Welcome " + (string.IsNullOrWhiteSpace(contractor.firstname) ? contractor.username : contractor.firstname);
            signalRClient = new SignalRClient();
            siteapiclient = new SiteApiClient();
            BindSiteDropdown(cboxSite, new List<Site>());
            BindSiteDropdown(cboxSelectSite, new List<Site>());
            Shown += async (sender, args) => await LoadSitesAsync();
            l.Click += btnCreateSite_Click;
        }
        

       

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlContent);
        }

        private async void btnAssignWorkers_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlAssignWorkers);
            await LoadSitesAsync();
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

        private async void btnReviewUpdates_Click(object sender, EventArgs e)
        {
            ShowPanel(pnlReviewUpdates);
            await LoadSitesAsync();
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

                BindSiteDropdown(cboxSite, sites);
                BindSiteDropdown(cboxSelectSite, sites);
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

        private static void BindSiteDropdown(ComboBox dropdown, List<Site> sites)
        {
            Site previousSite = dropdown.SelectedItem as Site;
            dropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            dropdown.DisplayMember = "SiteName";
            dropdown.ValueMember = "SiteID";
            // Each dropdown needs its own list so their selections stay independent.
            dropdown.DataSource = new List<Site>(sites);
            dropdown.Enabled = sites.Count > 0;
            dropdown.SelectedIndex = -1;
            if (previousSite != null && sites.Any(site => site.SiteID == previousSite.SiteID))
                dropdown.SelectedValue = previousSite.SiteID;
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
            
            //  cboxAssignWorker.SelectedIndex = -1;
        }
       

        private async void  ContractorDashboard_Load(object sender, EventArgs e)
        {
             try
            {   
                await signalRClient.ConnectAsync();
                await LoadWorkersAsync();
            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message);
             }
        }

        private async void btnAssignWorker_Click(object sender, EventArgs e)
        {
            Site site = cboxSite.SelectedItem as Site;
            Worker worker = cboxAssignWorker.SelectedItem as Worker;
            

            if (site == null || worker == null)
            {
                MessageBox.Show("Select a site and a worker.");
                return;
            }

            try
            {
               bool success=await signalRClient.AssignWorkerToSiteAsync(
               user, site.SiteID, worker.WorkerID);
                if (success)
                {
                    MessageBox.Show("Worker was successfully added to the site");
                }


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
        }
    }
}
