using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Mocosha.Library.KeyValueStore;

[assembly: OwinStartup(typeof(Mocosha.WepApi.SimpleStorage.Startup))]

namespace Mocosha.WepApi.SimpleStorage
{
    public class Startup
    {
        public static Storage MyStorage = new Storage();
        public void Configuration(IAppBuilder app)
        {
            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            SwaggerConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}
