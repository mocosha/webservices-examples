using System.Collections.Generic;
using Mocosha.Library.KeyValueStore;

namespace Mocosha.WcfService.SimpleStorage
{
    public class AnimalService : IAnimalService
    {
        private static Storage myStorage = Store.MyStorage;

        public KeyValuePair<string, string>[] FindAll()
        {
            return myStorage.FindAll();
        }

        public ReadResult<Animal> Find(string id)
        {
            return myStorage.Find<Animal>(id);
        }

        public WriteResult Add(string key, Animal animal)
        {
            return myStorage.Insert(key, animal);
        }

        public WriteResult Update(string key, Animal animal)
        {
            return myStorage.Update(key, animal);
        }

        public WriteResult Remove(string id)
        {
            return myStorage.Delete(id);
        }
    }
}
