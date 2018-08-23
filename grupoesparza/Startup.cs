using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;


[assembly: OwinStartup(typeof(grupoesparza.Startup))]

namespace grupoesparza
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

        }
    }
}
