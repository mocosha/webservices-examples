using Mocosha.Library.KeyValueStore;
using Mocosha.WepApi.SimpleStorage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



namespace Mocosha.WepApi.SimpleStorage.Controllers
{
    public class AnimalController : ApiController
    {
        private Storage myStorage = Startup.MyStorage;

        // GET: api/Animal/5
        public Animal Get(string key)
        {                        
            return myStorage.Find<Animal>(key);
        }

        // POST: api/Animal
        public void Post(string key, Animal value)
        {            
            myStorage.Insert(key, myStorage.SerializeObject(value));
        }

        // DELETE: api/Animal/5
        public void Delete(string key)
        {
            myStorage.Delete(key);
        }
    }
}
