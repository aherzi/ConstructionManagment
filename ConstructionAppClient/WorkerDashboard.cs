using ConstructionApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;


namespace ConstructionAppClient
{
    public partial class WorkerDashboard : Form
    {
        private readonly User signedInWorker;
        private readonly SignalRClient signalRClient;
        private string selectedFilePath;
        private bool loadingSites;
        private static readonly HttpClient httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7071/")
        };
        public WorkerDashboard()
        {
            InitializeComponent();
            lblAssignments.Text = "My Sites";
            Column1.DataPropertyName = nameof(AssignedSite.SiteId);
            Column2.DataPropertyName = nameof(AssignedSite.SiteName);
            CurrentPhase.HeaderText = "Address";
            CurrentPhase.DataPropertyName = nameof(AssignedSite.Address);
            Column3.HeaderText = "Date Assigned";
            Column3.DataPropertyName = nameof(AssignedSite.DateAssigned);
            Column3.DefaultCellStyle.Format = "d";
            Column4.HeaderText = "Assignment Status";
            Column4.DataPropertyName = nameof(AssignedSite.AssignmentStatus);
            dataGridView1.AutoGenerateColumns = false;
            ShowPanel(pnlContent);
            btnDashboard.Click += async (sender, e) =>
            {
                ShowPanel(pnlContent);
                if (signedInWorker != null) await LoadSitesAsync();
            };
            btnSubmitUpdates.Click += (sender, e) => ShowSubmitUpdates();
            btnMyUpdates.Click += (sender, e) => ShowPanel(pnlMyUpdates);
            btnSubmitProgressUpdate.Click += (sender, e) => ShowSubmitUpdates();
            btnUpdateStatus.Click += (sender, e) => ShowPanel(pnlMyUpdates);
        }

        public WorkerDashboard(User worker, SignalRClient client) : this()
        {
            signedInWorker = worker ?? throw new ArgumentNullException(nameof(worker));
            signalRClient = client ?? throw new ArgumentNullException(nameof(client));
            lblTitle.Text = "Welcome, " + worker.username;
            Shown += async (sender, e) => await LoadSitesAsync();
        }

        private void ShowPanel(Panel selectedPanel)
        {
            pnlContent.Visible = selectedPanel == pnlContent;
            pnlSubmitUpdates.Visible = selectedPanel == pnlSubmitUpdates;
            pnlMyUpdates.Visible = selectedPanel == pnlMyUpdates;
            selectedPanel.BringToFront();
            Color selectedColor = Color.FromArgb(242, 242, 242);
            btnDashboard.BackColor = selectedPanel == pnlContent ? selectedColor : Color.White;
            btnSubmitUpdates.BackColor = selectedPanel == pnlSubmitUpdates ? selectedColor : Color.White;
            btnMyUpdates.BackColor = selectedPanel == pnlMyUpdates ? selectedColor : Color.White;
        }

        private void ShowSubmitUpdates()
        {
            var selectedSite = dataGridView1.CurrentRow?.DataBoundItem as AssignedSite;
            if (selectedSite != null) cboxUpdateSite.SelectedValue = selectedSite.SiteId;
            ShowPanel(pnlSubmitUpdates);
        }

        private async Task LoadSitesAsync()
        {
            if (loadingSites) return;
            loadingSites = true;
            btnDashboard.Enabled = false;
            lblSelectionHint.Text = "Loading your assigned sites...";
            try
            {
                var sites = await signalRClient.GetAssignedSitesAsync(signedInWorker);
                if (IsDisposed) return;
                dataGridView1.DataSource = sites;
                int? previousSiteId = (cboxUpdateSite.SelectedItem as AssignedSite)?.SiteId;
                cboxUpdateSite.DataSource = new List<AssignedSite>(sites);
                cboxUpdateSite.Enabled = sites.Count > 0;
                cboxUpdateSite.SelectedIndex = -1;
                if (previousSiteId.HasValue && sites.Any(site => site.SiteId == previousSiteId.Value))
                    cboxUpdateSite.SelectedValue = previousSiteId.Value;
                lblAssignedSitesValue.Text = sites.Count.ToString();
                lblSelectionHint.Text = sites.Count == 0
                    ? "Your contractor has not assigned you to any sites yet."
                    : "All your assigned sites are shown. Click Dashboard to refresh.";
            }
            catch (Exception)
            {
                if (IsDisposed) return;
                dataGridView1.DataSource = null;
                cboxUpdateSite.DataSource = null;
                cboxUpdateSite.Enabled = false;
                lblAssignedSitesValue.Text = "\u2014";
                lblSelectionHint.Text = "Unable to load your sites. Check the server connection and click Dashboard to retry.";
            }
            finally
            {
                loadingSites = false;
                if (!IsDisposed) btnDashboard.Enabled = true;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LoginForm loginform = new LoginForm();
            loginform.Show();
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog1.FileName;
                pboxPhoto.ImageLocation = selectedFilePath;
            }

        }

        private async void btnSubmitUpdate_Click(object sender, EventArgs e)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StringContent(
                    cboxUpdateSite.SelectedValue.ToString()), "SiteID");

                content.Add(new StringContent(
                    cboxPhases.SelectedValue.ToString()), "PhaseID");

                content.Add(new StringContent(
                    txtUpdateDescription.Text), "Description");

                byte[] photo = File.ReadAllBytes(selectedFilePath);

                content.Add(new ByteArrayContent(photo),
                    "Photo", Path.GetFileName(selectedFilePath));

                var response = await httpClient.PostAsync(
                    "api/progressupdates", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Update submitted successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to submit update.");
                }
            }
        }
    }
}
