using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly:OwinStartup(typeof(eFocus.Amar2000.API.Startup))]
namespace eFocus.Amar2000.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
