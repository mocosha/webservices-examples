using Mocosha.KeyValueStore;
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
        // GET: api/Storage
        public IDictionary<string, string> GetAll()
        {
            return Storage.FindAll();
        }

        // GET: api/Storage/5
        public string GetValueById(string id)
        {
            return Storage.Find(id);
        }

        // POST: api/Storage
        public string Post([FromBody]string value)
        {
            return Storage.Insert(value);
        }

        // PUT: api/Storage/5
        public string Put(string id, [FromBody]string value)
        {
            return Storage.Update(id, value);
        }

        // DELETE: api/Storage/5
        public string Delete(string id)
        {
            return Storage.Delete(id);
        }
    }
}
