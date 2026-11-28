using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConstructionApp.Shared;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;

namespace ConstructionAppClient
{
    public partial class OwnerDashbaord : Form
    {
        private SignalRClient signalRClient;
        private PieChart pieChart;
        private CartesianChart barChart;

        public OwnerDashbaord(User user)
        {
            InitializeComponent();

            pieChart = new PieChart { Dock = DockStyle.Fill };
            panelPie.Controls.Add(pieChart);

            barChart = new CartesianChart { Dock = DockStyle.Fill };
            panelBar.Controls.Add(barChart);

            Load += DashboardForm_Load;
            btnRefresh.Click += btnRefresh_Click;
        }

        private async void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                signalRClient = new SignalRClient();
                await signalRClient.ConnectAsync();

                List<Site> sites = await signalRClient.GetAllSitesAsync();
                cmbSite.DisplayMember = "SiteName";
                cmbSite.ValueMember = "SiteID";
                cmbSite.DataSource = sites;
                cmbSite.SelectedIndexChanged += cmbSite_SelectedIndexChanged;

                await LoadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private async void cmbSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { await LoadDashboard(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            try { await LoadDashboard(); }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private async Task LoadDashboard()
        {
            Site site = cmbSite.SelectedItem as Site;
            if (site == null)
            {
                ShowPhases(new List<Phase>());
                return;
            }
            List<Phase> phases = await signalRClient.GetPhasesBySiteAsync(site.SiteID);
            ShowPhases(phases);
        }

        // How far along this phase SHOULD be today, based on its planned dates.
        private static int ExpectedPercent(Phase p)
        {
            DateTime today = DateTime.Today;
            if (today <= p.PlannedStart.Date) return 0;
            if (today >= p.PlannedEnd.Date) return 100;
            double total = (p.PlannedEnd.Date - p.PlannedStart.Date).TotalDays;
            if (total <= 0) return 100;
            double elapsed = (today - p.PlannedStart.Date).TotalDays;
            return (int)Math.Round(elapsed / total * 100);
        }

        // Delayed = actual is more than 10 points behind expected.
        private static string StatusFor(Phase p, int expected)
        {
            if (p.PercentComplete >= 100) return "Complete";
            if (DateTime.Today < p.PlannedStart.Date) return "Not started";
            return p.PercentComplete < expected - 10 ? "Delayed" : "On track";
        }

        private void ShowPhases(List<Phase> phases)
        {
            List<PhaseStatusRow> rows = new List<PhaseStatusRow>();
            foreach (Phase p in phases)
            {
                int expected = ExpectedPercent(p);
                rows.Add(new PhaseStatusRow
                {
                    Stage = p.stage.ToString(),
                    Start = p.PlannedStart.ToShortDateString(),
                    End = p.PlannedEnd.ToShortDateString(),
                    ActualPercent = Convert.ToInt16(p.PercentComplete),
                    ExpectedPercent = expected,
                    Status = StatusFor(p, expected)
                });
            }
            gridStatus.DataSource = rows;

            double overall = phases.Count == 0 ? 0 : phases.Average(p => (double)p.PercentComplete);
            lblOverall.Text = "Overall completion: " + Math.Round(overall) + "%";

            if (rows.Count == 0)
            {
                lblStatus.Text = "Status: no phases yet";
                lblStatus.ForeColor = Color.Gray;
            }
            else if (rows.Any(r => r.Status == "Delayed"))
            {
                lblStatus.Text = "Status: DELAYED";
                lblStatus.ForeColor = Color.Firebrick;
            }
            else if (rows.All(r => r.Status == "Complete"))
            {
                lblStatus.Text = "Status: COMPLETE";
                lblStatus.ForeColor = Color.SeaGreen;
            }
            else
            {
                lblStatus.Text = "Status: ON TRACK";
                lblStatus.ForeColor = Color.SeaGreen;
            }

            // Progress ring
            pieChart.Series = new ISeries[]
            {
                new PieSeries<double>
                {
                    Values = new double[] { overall },
                    Name = "Complete",
                    InnerRadius = 60,
                    Fill = new SolidColorPaint(SKColors.SeaGreen)
                },
                new PieSeries<double>
                {
                    Values = new double[] { 100 - overall },
                    Name = "Remaining",
                    InnerRadius = 60,
                    Fill = new SolidColorPaint(SKColors.LightGray)
                }
            };

            // Phase bars: actual vs expected
            barChart.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Name = "Actual %",
                    Values = rows.Select(r => (double)r.ActualPercent).ToArray(),
                    Fill = new SolidColorPaint(SKColors.SteelBlue)
                },
                new ColumnSeries<double>
                {
                    Name = "Expected %",
                    Values = rows.Select(r => (double)r.ExpectedPercent).ToArray(),
                    Fill = new SolidColorPaint(SKColors.Orange)
                }
            };
            barChart.XAxes = new Axis[]
            {
                new Axis { Labels = rows.Select(r => r.Stage).ToArray() }
            };
            barChart.YAxes = new Axis[]
            {
                new Axis { MinLimit = 0, MaxLimit = 100 }
            };
        }
    }

    public class PhaseStatusRow
    {
        public string Stage { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int ActualPercent { get; set; }
        public int ExpectedPercent { get; set; }
        public string Status { get; set; }
    }
}
