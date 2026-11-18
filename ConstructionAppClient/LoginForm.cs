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

namespace ConstructionAppClient
{
    public partial class LoginForm : Form
    {
        private readonly WorkerApiClient workerApiClient;

        public LoginForm(WorkerApiClient workerapiclient)
        {
            InitializeComponent();
            workerApiClient = workerapiclient;
            
            
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccount newAccount = new CreateAccount();
            newAccount.ShowDialog();
            
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {
            SignalRClient signalRClient = new SignalRClient();
            try
            {
                await signalRClient.ConnectAsync();
                User user = new User
                {
                    username = txtUsername.Text,
                    password = txtPass.Text,
                    
                };
                bool success = await signalRClient.VerifyAsync(user);

                if (success)
                {
                    int role = await signalRClient.GetRole(user);
                    if (role == 0)
                    {
                       Contractor loggedinContractor = await signalRClient.GetContractorAsync(user);
                        if (loggedinContractor == null)
                        {
                            MessageBox.Show("No contractor record is linked to this account.");
                            return;
                        }
                        ContractorDashboard contractordb = new ContractorDashboard(loggedinContractor,workerApiClient);
                        contractordb.Show();
                        this.Hide();
                        
                    }
                    else if (role == 1)
                    {
                        WorkerDashboard workerdb = new WorkerDashboard(user);
                        workerdb.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Display the Dashboard for the Owner");

                    }

                    
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
