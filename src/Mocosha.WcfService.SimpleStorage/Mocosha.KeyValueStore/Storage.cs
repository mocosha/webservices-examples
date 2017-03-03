using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocosha.KeyValueStore
{
    public class Storage
    {
        public static string Insert(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return "Value parameter is missing";

            storage.Add(Guid.NewGuid().ToString(), value);
            return $"Value {value} successfully added";
        }

        public static string Insert(string key, string value)
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

        public static string Update(string key, string value)
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

        public static string Delete(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return "Key parameter is missing";

            if (!storage.ContainsKey(key))
                return $"Value with key {key} not found";

            storage.Remove(key);
            return $"Value with key {key} successfully removed";
        }

        public static string Find(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return $"Key parameter is missing";

            string value;
            if (storage.TryGetValue(key, out value))
                return value;

            return $"Value with key {key} not found";
        }

        public static string Insert<TValue>(string key, TValue value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return "Key parameter is missing";

            if (value == null)
                return "Value parameter is missing";

            if (storage.ContainsKey(key))
            {
                return $"Item with the key {key} already exists";
            }

            var serializeValue = JsonConvert.SerializeObject(value);
            storage.Add(key, serializeValue);
            return $"Value {serializeValue} successfully added";
        }

        public static TValue Find<TValue>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException($"Key parameter is missing");

            string value;
            if (storage.TryGetValue(key, out value))
                return JsonConvert.DeserializeObject<TValue>(value);

            throw new KeyNotFoundException($"Value with key {key} not found");
        }

        public static Dictionary<string, string> FindAll()
        {
            return storage;
        }

        private static Dictionary<string, string> storage = new Dictionary<string, string>() { { "test", "test" } };
    }
}
