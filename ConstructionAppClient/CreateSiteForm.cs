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
        

        public CreateSiteForm(Contractor loggedinContractor,List<Worker> workers)
        {

            InitializeComponent();
            if (loggedinContractor == null || loggedinContractor.ContractorID <= 0)
                throw new ArgumentException("A valid logged-in contractor is required.", nameof(loggedinContractor));
            this.loggedinContractor = loggedinContractor;
            cboxZoning.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxZoning.DataSource = Enum.GetValues(typeof(Site.Zoning));
            btnCancel.DialogResult = DialogResult.Cancel;
            CancelButton = btnCancel;
            
            
        }

        private void CreateSite_Load(object sender, EventArgs e)
        {

        }

        private async void  btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSiteName.Text) || string.IsNullOrWhiteSpace(txtSiteAddress.Text))
            {
                MessageBox.Show("Enter a site name and address.");
                return;
            }
            btnCreate.Enabled = false;
            try
            {
                Site site = new Site
                {
                    SiteName = txtSiteName.Text.Trim(),
                    Address = txtSiteAddress.Text.Trim(),
                    EstimatedCompletionDate = dtpickerCompletion.Value,
                    Description = txtDesc.Text,
                   
                    DateCreated = DateTime.Now,
                    StartDate = DateTime.Today,
                    zoning = (Site.Zoning)cboxZoning.SelectedItem,
                    contractor = new Contractor { ContractorID = loggedinContractor.ContractorID }
                };

                await siteservice.CreateSiteAsync(site);
                this.DialogResult = DialogResult.OK;
                this.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating site: {ex.Message}");
            }
            finally
            {
                if (!IsDisposed) btnCreate.Enabled = true;
            }


        }
    }
}
