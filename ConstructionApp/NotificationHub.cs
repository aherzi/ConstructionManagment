using ConstructionApp.Shared;

namespace ConstructionAppServer

{
    using Microsoft.AspNetCore.SignalR;
    using Microsoft.AspNetCore.SignalR.Client;

    public class NotificationHub : Hub
    {
        public NotificationHub(UserService userservice)
        {
            this.UserService = userservice;

        }
        private readonly UserService UserService;

        public async Task SendTestMessage(string message)
        {
            await Clients.All.SendAsync("RecieveNotification", message);
        }

        public bool RegisterUser(User user)
        {
            return UserService.Register(user);



        }
        public bool UserExists(User user)
        {
            return UserService.UserExists(user);

        }
        public bool VerifyUser(User user)
        {
            return UserService.UserVerify(user);
        }
        public int GetRole(User user)
        {
            return UserService.GetRole(user);
        }
    }
}

