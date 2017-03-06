using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocosha.Library.KeyValueStore
{
    public class Serializer
    {
        public static string Serialize(Object value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
