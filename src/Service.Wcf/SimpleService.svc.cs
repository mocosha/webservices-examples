using System;
using System.Collections.Generic;
using Mocosha.Library.KeyValueStore;

namespace Mocosha.WcfService.SimpleStorage
{
    public class SimpleService : ISimpleService
    {
        private Storage myStorage = new Storage();

        public Dictionary<string, string> GetAll()
        {
            return myStorage.FindAll();
        }

        public string FindById(string id)
        {
            return myStorage.Find(id);
        }

        public string Add(string value)
        {
            var dummyKey = Guid.NewGuid().ToString();
            return myStorage.Insert(dummyKey, value);
        }

        public string Add(string key, string value)
        {
            return myStorage.Insert(key, value);
        }

        public string Update(string id, string value)
        {
            return myStorage.Update(id, value);
        }

        public string Remove(string id)
        {
            return myStorage.Delete(id);
        }

        public Response<Animal> FindAnimalById(string id)
        {
            try
            {
                var animal = myStorage.Find<Animal>(id);

                return new Response<Animal> { Result = animal, Success = true };
            }
            catch (Exception ex)
            {
                return new Response<Animal> { Message = ex.Message, Success = false };
            }
        }

        public string AddAnimal(string key, Animal animal)
        {
            var animalJson = myStorage.SerializeObject(animal);
            return myStorage.Insert(key, animalJson);
        }
    }
}
