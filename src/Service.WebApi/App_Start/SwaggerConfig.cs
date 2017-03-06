using System.Web.Http;
using Swashbuckle.Application;

namespace Mocosha.WebApi.SimpleStorage
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Mocosha.WebApi.SimpleStorage");
                    })
                .EnableSwaggerUi(c => { });
        }
    }
}
