using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionApp.Shared;



namespace ConstructionAppClient
{
    using Microsoft.AspNetCore.SignalR.Client;
    using System.Diagnostics.Eventing.Reader;
    using System.Windows.Forms;
    

    public class SignalRClient
    {
        private HubConnection connection;


        public SignalRClient()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7071/NotificationHub")
                .WithAutomaticReconnect()
                .Build();
        }


        private void RecieveNotification(string message)
        {
            MessageBox.Show(message);
        }
        public async Task ConnectAsync()

        {
            try {
                Console.WriteLine("Before: " + connection.State);

              
                await connection.StartAsync();
                Console.WriteLine("After: " + connection.State);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        public async Task<bool> RegisterAsync(User user)
        {
            if(connection.State != HubConnectionState.Connected)
        {
                throw new InvalidOperationException(
                    "SignalR connection is not active.");
            }

            return await connection.InvokeAsync<bool>(
                "RegisterUser", user);
        }
        public async Task<bool> VerifyAsync(User user)
        {
            if (connection.State != HubConnectionState.Connected)
            {
                throw new InvalidOperationException(
                    "SignalR connection is not active.");
            }
            return await connection.InvokeAsync<bool>("VerifyUser", user);

        }
        public async Task<int> GetRole(User user)
        {
            if (connection.State != HubConnectionState.Connected)
            {
                throw new InvalidOperationException(
                    "SignalR connection is not active.");
            }
            return await connection.InvokeAsync<int>("GetRole", user);
        }
    }
    }

    

