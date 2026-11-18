using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionApp.Shared;

namespace ConstructionAppClient
{
    public partial class PhaseForm : Form
    {
        private SignalRClient signalRClient;
        private int selectedPhaseId = 0;

        public PhaseForm()
        {
            InitializeComponent();
            cmbStage.Items.AddRange(new object[]
            {
                "Foundation", "Framing", "Roofing", "Electrical", "Plumbing", "Finishing"
            });
            Load += PhaseForm_Load;
            btnAddPhase.Click += btnAddPhase_Click;
            btnUpdatePhase.Click += btnUpdatePhase_Click;
            gridPhases.SelectionChanged += gridPhases_SelectionChanged;
        }

        private async void PhaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                signalRClient = new SignalRClient();
                await signalRClient.ConnectAsync();

                List<ConstructionSite> sites = await signalRClient.GetAllSitesAsync();
                cmbSite.DisplayMember = "SiteName";
                cmbSite.ValueMember = "SiteID";
                cmbSite.DataSource = sites;
                cmbSite.SelectedIndexChanged += cmbSite_SelectedIndexChanged;

                if (sites.Count == 0)
                {
                    MessageBox.Show("There are no sites yet. Add a site first.");
                }
                else
                {
                    await LoadPhases();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                await LoadPhases();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async Task LoadPhases()
        {
            ConstructionSite site = cmbSite.SelectedItem as ConstructionSite;
            if (site == null)
            {
                gridPhases.DataSource = null;
                return;
            }
            gridPhases.DataSource = await signalRClient.GetPhasesBySiteAsync(site.SiteID);
            gridPhases.ClearSelection();
            selectedPhaseId = 0;
        }

        private void gridPhases_SelectionChanged(object sender, EventArgs e)
        {
            if (gridPhases.SelectedRows.Count == 0) return;
            ConstructionPhase phase = gridPhases.SelectedRows[0].DataBoundItem as ConstructionPhase;
            if (phase == null) return;

            selectedPhaseId = phase.PhaseID;
            cmbStage.SelectedItem = phase.Stage;
            txtDescription.Text = phase.Description;
            dtpPlannedStart.Value = phase.PlannedStart;
            dtpPlannedEnd.Value = phase.PlannedEnd;
            numPercent.Value = Math.Min(100, Math.Max(0, phase.PercentComplete));
        }

        private ConstructionPhase ReadInputs()
        {
            ConstructionSite site = cmbSite.SelectedItem as ConstructionSite;
            if (site == null)
            {
                MessageBox.Show("Please choose a site.");
                return null;
            }
            if (cmbStage.SelectedItem == null)
            {
                MessageBox.Show("Please choose a stage.");
                return null;
            }
            if (dtpPlannedEnd.Value.Date < dtpPlannedStart.Value.Date)
            {
                MessageBox.Show("The planned end date cannot be before the start date.");
                return null;
            }

            return new ConstructionPhase
            {
                SiteID = site.SiteID,
                Stage = cmbStage.SelectedItem.ToString(),
                Description = txtDescription.Text.Trim(),
                PlannedStart = dtpPlannedStart.Value.Date,
                PlannedEnd = dtpPlannedEnd.Value.Date,
                PercentComplete = (int)numPercent.Value
            };
        }

        private async void btnAddPhase_Click(object sender, EventArgs e)
        {
            ConstructionPhase phase = ReadInputs();
            if (phase == null) return;

            try
            {
                bool success = await signalRClient.AddPhaseAsync(phase);
                if (success)
                {
                    MessageBox.Show("Phase added!");
                    txtDescription.Clear();
                    numPercent.Value = 0;
                    await LoadPhases();
                }
                else
                {
                    MessageBox.Show("The phase could not be saved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void btnUpdatePhase_Click(object sender, EventArgs e)
        {
            if (selectedPhaseId == 0)
            {
                MessageBox.Show("Click a phase in the table first.");
                return;
            }

            ConstructionPhase phase = ReadInputs();
            if (phase == null) return;
            phase.PhaseID = selectedPhaseId;

            try
            {
                bool success = await signalRClient.UpdatePhaseAsync(phase);
                if (success)
                {
                    MessageBox.Show("Phase updated!");
                    await LoadPhases();
                }
                else
                {
                    MessageBox.Show("The phase could not be updated.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}