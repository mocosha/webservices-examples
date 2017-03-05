using Mocosha.Library.KeyValueStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mocosha.WepApi.SimpleStorage.Controllers
{
    public class StorageController : ApiController
    {
        private Storage myStorage = Startup.MyStorage;

        // GET: api/Storage
        public IDictionary<string, string> GetAll()
        {
            return myStorage.FindAll();
        }

        // GET: api/Storage/5
        public string GetValueById(string id)
        {
            return myStorage.Find(id);
        }

        // POST: api/Storage
        public string Post([FromBody]string value)
        {
            return myStorage.Insert(Guid.NewGuid().ToString(), value);
        }

        // PUT: api/Storage/5
        public string Put(string id, [FromBody]string value)
        {
            return myStorage.Update(id, value);
        }

        // DELETE: api/Storage/5
        public string Delete(string id)
        {
            return myStorage.Delete(id);
        }
    }
}
