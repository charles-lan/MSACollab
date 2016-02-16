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
    [Authorize]
    public class NotificationHub : Microsoft.AspNet.SignalR.Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SendMessageOnChat(string users, string message)
        {
            string curr = DateTime.Now.ToString();
            string[] userids = new JavaScriptSerializer().Deserialize<string[]>(users);

            foreach (string s in userids)
            {
                foreach (var connectionId in _connections.GetConnections(s))
                {
                    Clients.Client(connectionId).addMessageToUser(message, curr);
                }
            }

            Clients.All.addMessageToAdmin(userids, message, curr);

        }

        public void SendMessageOnPost(string username, string message)
        {
            string curr = DateTime.Now.ToString();
            foreach (var connectionId in _connections.GetConnections(username))
            {
                Clients.Client(connectionId).addMessagetouser(message, curr);
            }
        }


        public override Task OnConnected()
        {
            string name = Context.User.Identity.Name;

            _connections.Add(name, Context.ConnectionId);
            Clients.All.addUser(name);

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnReconnected();
        }
    }

    public class ConnectionMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> _connections =
            new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public void Add(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections);
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if (_connections.TryGetValue(key, out connections))
            {
                return connections;
            }

            return Enumerable.Empty<string>();
        }

        public void Remove(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if (!_connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if (connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }
}