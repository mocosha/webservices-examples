using System;
using System.Collections.Generic;
using Mocosha.Library.KeyValueStore;

namespace Mocosha.WcfService.SimpleStorage
{
    public class SimpleService : ISimpleService
    {
        private static Storage myStorage = new Storage();

        public KeyValuePair<string, string>[] FindAll()
        {
            return myStorage.FindAll();
        }

        public ReadResult<string> Find(string id)
        {
            return myStorage.Find<string>(id);
        }

        public WriteResult Add(string key, string value)
        {
            return myStorage.Insert(key, value);
        }

        public WriteResult Update(string id, string value)
        {
            return myStorage.Update(id, value);
        }

        public WriteResult Remove(string id)
        {
            return myStorage.Delete(id);
        }

        public ReadResult<Animal> FindAnimalById(string id)
        {
            return myStorage.Find<Animal>(id);
        }

        public WriteResult AddAnimal(string key, Animal animal)
        {
            return myStorage.Insert(key, animal);
        }
    }
}
