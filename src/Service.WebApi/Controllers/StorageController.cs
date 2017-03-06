using Mocosha.Library.KeyValueStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mocosha.WebApi.SimpleStorage.Controllers
{
    public class StorageController : ApiController
    {
        private Storage myStorage = Startup.MyStorage;

        // GET: api/Storage
        public KeyValuePair<string,string>[] GetAll()
        {
            return myStorage.FindAll();
        }

        // GET: api/Storage/5
        public ReadResult<string> GetValueById(string id)
        {
            return myStorage.Find<string>(id);
        }

        // POST: api/Storage
        public WriteResult Post(string id, [FromBody]string value)
        {
            return myStorage.Insert(id, value);
        }

        // PUT: api/Storage/5
        public WriteResult Put(string id, [FromBody]string value)
        {
            return myStorage.Update(id, value);
        }

        // DELETE: api/Storage/5
        public WriteResult Delete(string id)
        {
            return myStorage.Delete(id);
        }
    }
}
