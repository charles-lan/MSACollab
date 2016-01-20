using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace NotificationSignalR.Hubs
{
    [HubName("notifHub")]
    public class NotificationHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        //when method is called, all clients receive the message.
        public void SendNotifications(string message)
        {
            Clients.All.receiveNotification(message);
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}