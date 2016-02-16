using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(NotificationHubAPI.Startup))]

namespace NotificationHubAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);
                var hubconfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };

                map.RunSignalR(hubconfiguration);
            });

            
        }
    }
}
