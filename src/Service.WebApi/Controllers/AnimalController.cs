using System.Web.Http;
using System.Collections.Generic;
using Mocosha.Library.KeyValueStore;
using Mocosha.WebApi.SimpleStorage.Models;

namespace Mocosha.WebApi.SimpleStorage.Controllers
{
    public class AnimalController : ApiController
    {
        private Storage myStorage = Startup.MyStorage;

        // GET: api/Animal
        public KeyValuePair<string, string>[] Get()
        {
            return myStorage.FindAll();
        }

        // GET: api/Animal/5
        public ReadResult<Animal> Get(string id)
        {
            return myStorage.Find<Animal>(id);
        }

        // POST: api/Animal
        public WriteResult Post(string id, Animal value)
        {            
            return myStorage.Insert(id, value);
        }

        // PUT: api/Animal
        public WriteResult Put(string id, Animal value)
        {
            return myStorage.Update(id, value);
        }

        // DELETE: api/Animal/5
        public WriteResult Delete(string id)
        {
            return myStorage.Delete(id);
        }
    }
}
