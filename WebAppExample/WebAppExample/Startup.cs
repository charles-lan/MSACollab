using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebAppExample.Startup))]

namespace WebAppExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
