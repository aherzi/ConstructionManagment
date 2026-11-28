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
            cboxOwner.DropDownStyle = ComboBoxStyle.DropDownList;
            cboxOwner.DisplayMember = "username";
            cboxOwner.ValueMember = "OwnerID";
            cboxOwner.Enabled = false;
            btnCreate.Enabled = false;
            btnCancel.DialogResult = DialogResult.Cancel;
            CancelButton = btnCancel;
            
            
        }

        private async void CreateSite_Load(object sender, EventArgs e)
        {
            try
            {
                List<Owner> owners = await siteservice.GetOwnersAsync();
                if (IsDisposed) return;
                cboxOwner.DataSource = owners;
                cboxOwner.SelectedIndex = -1;
                cboxOwner.Enabled = owners.Count > 0;
                btnCreate.Enabled = owners.Count > 0;
                if (owners.Count == 0)
                    MessageBox.Show("No property owners are available. Create an owner account first.");
            }
            catch (Exception ex)
            {
                if (!IsDisposed)
                    MessageBox.Show("Could not load property owners: " + ex.Message);
            }
        }

        private async void  btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSiteName.Text) || string.IsNullOrWhiteSpace(txtSiteAddress.Text))
            {
                MessageBox.Show("Enter a site name and address.");
                return;
            }
            Owner selectedOwner = cboxOwner.SelectedItem as Owner;
            if (selectedOwner == null || selectedOwner.OwnerID <= 0)
            {
                MessageBox.Show("Select a property owner.");
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
                    owner = new Owner { OwnerID = selectedOwner.OwnerID },
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
