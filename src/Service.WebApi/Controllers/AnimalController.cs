using System.Web.Http;
using Mocosha.Library.KeyValueStore;
using Mocosha.WebApi.SimpleStorage.Models;

namespace Mocosha.WebApi.SimpleStorage.Controllers
{
    public class AnimalController : ApiController
    {
        private Storage myStorage = Startup.MyStorage;

        // GET: api/Animal/5
        public ReadResult<Animal> Get(string key)
        {
            return myStorage.Find<Animal>(key);
        }

        // POST: api/Animal
        public WriteResult Post(string key, Animal value)
        {            
            return myStorage.Insert(key, value);
        }

        // PUT: api/Animal
        public WriteResult Put(string key, Animal value)
        {
            return myStorage.Update(key, value);
        }

        // DELETE: api/Animal/5
        public WriteResult Delete(string key)
        {
            return myStorage.Delete(key);
        }
    }
}
