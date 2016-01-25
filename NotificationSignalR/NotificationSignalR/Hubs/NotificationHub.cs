using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace NotificationSignalR.Hubs
{
    [HubName("notifHub")]
    public class NotificationHub : Microsoft.AspNet.SignalR.Hub
    {

        static Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

        
        public void SendNotifications(string groupname, string message)
        {
            Clients.Group(groupname).receiveNotification(message);
        }

        public void Send(string groupname, string message)
        {
            if(groupname == "all")
            {
                Clients.All.addNewMessageToPage(message);
            } else
            {
                Clients.Group(groupname).addNewMessageToPage(message);
            }
        }

        public Task JoinGroup(string groupname)
        {
            users[Context.ConnectionId].Add(groupname);
            Clients.All.addUserToGroup(groupname, Context.ConnectionId);
            return Groups.Add(Context.ConnectionId, groupname);
        }

        public Task LeaveGroup(string groupname)
        {
            return Groups.Remove(Context.ConnectionId, groupname);
        }

        public override Task OnConnected ()
        {
            users.Add(Context.ConnectionId, new List<string>());
            Clients.Client(Context.ConnectionId).getUserId(Context.ConnectionId);
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            
            List<string> s = users[Context.ConnectionId];

            foreach (string i in s)
            {
                LeaveGroup(i);
            }
            return base.OnDisconnected(stopCalled);
        }
    }
}