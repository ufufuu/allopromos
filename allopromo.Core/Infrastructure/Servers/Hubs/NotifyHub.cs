using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
namespace allopromo.Api.Services.Factory
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string Name, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Name, message);
        }
    }
    
}
namespace allopromo.Api.Servers.Hubs.Chat
{
    public class NotifyHub : Hub
    {

    }
}

//Uninstall-Package OpenIdPortableArea –RemoveDependenciesz

//Make a Factory or Service pattern Class around any Library you want to Use
//SignalR : real-time Web functionnality in Applications
//Service Class
//Extension Methods to Add Functionnalites to Classes - Layered Architecture