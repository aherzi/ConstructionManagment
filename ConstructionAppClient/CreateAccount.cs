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

namespace ConstructionAppClient
{
    public partial class CreateAccount : Form
    {
        public CreateAccount()
        {
            InitializeComponent();
            cmbRole.DataSource = Enum.GetValues(typeof(User.Role));
            btnCreateAccount.Click += btnCreate_Click;


        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {
            UpdateCompanyNameVisibility();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCompanyNameVisibility();
        }

        private void UpdateCompanyNameVisibility()
        {
            //get the role the user selected
            string role = cmbRole.SelectedItem as string;
            // determine if the user selected contractor or worker
            bool allowsCompany = role == "Contractor" || role == "Worker";
            //if its either one of those make the nessassry controls visible to them
            lblCompanyName.Visible = allowsCompany;
            txtCompanyName.Visible = allowsCompany;
            lblCompanyHint.Visible = allowsCompany;
            txtCompanyName.Enabled = allowsCompany;

            // if they are not either of those(meaning they are an owner) hide it so they dont have that option

            if (!allowsCompany)
            {
                txtCompanyName.Clear();
            }
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            
            SignalRClient signalRClient = new SignalRClient();
            try
            {
                await signalRClient.ConnectAsync();
                User user = new User
                {
                    username = txtUsername.Text,
                    password = txtPassword.Text,
                    role = (User.Role)Enum.Parse(typeof(User.Role), cmbRole.SelectedItem.ToString()),
                    email = txtEmailAddress.Text
                };
                bool success = await signalRClient.RegisterAsync(user);

                if (success)
                {
                    MessageBox.Show("Account created successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to create account.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        
    }
    }

