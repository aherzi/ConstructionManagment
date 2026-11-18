using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionApp.Shared;

namespace ConstructionAppClient
{
    public partial class SiteEntryForm : Form
    {
        private SignalRClient signalRClient;

        public SiteEntryForm()
        {
            InitializeComponent();
            Load += SiteEntryForm_Load;
            btnSave.Click += btnSave_Click;
            btnPhases.Click += (s, ev) => new PhaseForm().Show();
            btnDashboard.Click += (s, ev) => new DashboardForm().Show();
            FormClosed += (s, e) => Application.Exit();
        }

        private async void SiteEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                signalRClient = new SignalRClient();
                await signalRClient.ConnectAsync();
                await RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task RefreshGrid()
        {
            List<ConstructionSite> sites = await signalRClient.GetAllSitesAsync();
            grid.DataSource = sites;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSiteName.Text))
            {
                MessageBox.Show("Please enter a site name.");
                return;
            }

            try
            {
                ConstructionSite site = new ConstructionSite
                {
                    SiteName = txtSiteName.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    OwnerID = (int)numOwnerId.Value,
                    ContractorID = (int)numContractorId.Value,
                    StartDate = dtpStart.Value.Date
                };

                bool success = await signalRClient.AddSiteAsync(site);
                if (success)
                {
                    MessageBox.Show("Site saved!");
                    txtSiteName.Clear();
                    txtAddress.Clear();
                    await RefreshGrid();
                }
                else
                {
                    MessageBox.Show("The site could not be saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}