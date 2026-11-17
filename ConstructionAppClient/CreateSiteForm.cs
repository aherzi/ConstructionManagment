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
    public partial class CreateSiteForm : Form

    {
private readonly SiteApiClient siteservice = new SiteApiClient();
        private readonly Contractor loggedinContractor;

        public CreateSiteForm(Contractor loggedinContractor)
        {

            InitializeComponent();
            this.loggedinContractor = loggedinContractor;
        }

        private void CreateSite_Load(object sender, EventArgs e)
        {

        }

        private async void  btnCreate_Click(object sender, EventArgs e)
        {
            Site site = new Site();
            
            site.SiteName = txtSiteName.Text;
            site.Address = txtSiteAddress.Text;
           
            
            site.EstimatedCompletionDate = dtpickerCompletion.Value;
            site.Description = txtDesc.Text;
            site.workers = clboxWorkers.CheckedItems.Cast<Worker>().ToList();
            site.DateCreated = DateTime.Now;
            site.contractor = new Contractor
            {
                ContractorID = loggedinContractor.ContractorID,

            };


            try
            {
                await  siteservice.CreateSiteAsync(site);
                MessageBox.Show("Site created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating site: {ex.Message}");
            }

        }
    }
}
