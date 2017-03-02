using Mocosha.KeyValueStore;
using System;
using System.Collections.Generic;

namespace Mocosha.WcfService.SimpleStorage
{
    public class SimpleService : ISimpleService
    {
        public Dictionary<string, string> GetAll()
        {
            return Storage.FindAll();
        }

        public string FindById(string id)
        {
            return Storage.Find(id);
        }

        public string Add(string value)
        {
            return Storage.Insert(value);
        }

        public string Add(string key, string value)
        {
            return Storage.Insert(key, value);
        }

        public string Update(string id, string value)
        {
            return Storage.Update(id, value);
        }

        public string Remove(string id)
        {
            return Storage.Delete(id);
        }

        public Response<Animal> FindAnimalById(string id)
        {
            try
            {
                var animal = Storage.Find<Animal>(id);

                return new Response<Animal> { Result = animal, Success = true };
            }
            catch (Exception ex)
            {
                return new Response<Animal> { Message = ex.Message, Success = false };
            }
        }

        public string AddAnimal(string key, Animal animal)
        {
            return Storage.Insert(key, animal);
        }
    }
}
