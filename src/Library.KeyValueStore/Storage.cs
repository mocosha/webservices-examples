using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mocosha.Library.KeyValueStore
{
    public class Storage
    {
        public string Insert(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return "Key parameter is missing";

            if (string.IsNullOrWhiteSpace(value))
                return "Value parameter is missing";

            if (storage.ContainsKey(key))
            {
                return $"Item with the key {key} already exists";
            }

            storage.Add(key, value);
            return $"Value {value} successfully added";
        }

        public string Update(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return "Key parameter is missing";

            if (string.IsNullOrWhiteSpace(value))
                return "Value parameter is missing";

            if (!storage.ContainsKey(key))
                return $"Value with key {key} not found";

            storage[key] = value;
            return $"Value {value} with key {key} successfully updated";
        }

        public string Delete(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return "Key parameter is missing";

            if (!storage.ContainsKey(key))
                return $"Value with key {key} not found";

            storage.Remove(key);
            return $"Value with key {key} successfully removed";
        }

        public string Find(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return $"Key parameter is missing";

            string value;
            if (storage.TryGetValue(key, out value))
                return value;

            return $"Value with key {key} not found";
        }

        public TValue Find<TValue>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException($"Key parameter is missing");

            string value;
            if (storage.TryGetValue(key, out value))
                return JsonConvert.DeserializeObject<TValue>(value);

            throw new KeyNotFoundException($"Value with key {key} not found");
        }

        public Dictionary<string, string> FindAll()
        {
            return storage;
        }

        private Dictionary<string, string> storage = new Dictionary<string, string>() { { "test", "test" } };

        public string SerializeObject(Object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
