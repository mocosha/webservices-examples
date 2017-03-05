using System.Web.Http;
using Swashbuckle.Application;

namespace Mocosha.WepApi.SimpleStorage
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Mocosha.WepApi.SimpleStorage");
                    })
                .EnableSwaggerUi(c => { });
        }
    }
}
