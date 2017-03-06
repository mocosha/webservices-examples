using System.Collections.Generic;
using System.Collections.Concurrent;

namespace Mocosha.Library.KeyValueStore
{
    public class Storage
    {
        public WriteResult Insert(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return WriteResult.Failure("Key parameter is missing");

            if (string.IsNullOrWhiteSpace(value))
                return WriteResult.Failure("Value parameter is missing");

            var isSuccess = storage.TryAdd(key, value);

            return isSuccess 
                ? WriteResult.Success($"Key '{key}' with value '{value}' added") 
                : WriteResult.Failure($"Key '{key}' already exists");
        }

        public WriteResult Insert<T>(string key, T value)
        {
            return Insert(key, Serializer.Serialize(value));
        }

        public WriteResult Update(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key))
                return WriteResult.Failure("Key parameter is missing");

            if (string.IsNullOrWhiteSpace(value))
                return WriteResult.Failure("Value parameter is missing");

            var oldValue = Find<string>(key);

            if (oldValue.IsSuccess)
            {
                var isSuccess = storage.TryUpdate(key, value, oldValue.Value);
                return WriteResult.Success($"Value '{oldValue.Value}' with '{key}' updated with new value '{value}'");
            }
            else
            {
                return WriteResult.Failure(oldValue.Message);
            }
        }

        public WriteResult Update<T>(string key, T value)
        {
            return Update(key, Serializer.Serialize(value));
        }

        public WriteResult Delete(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return WriteResult.Failure("Key parameter is missing");

            string value;
            var isSuccess = storage.TryRemove(key, out value);

            return isSuccess
                ? WriteResult.Success($"Key '{key}' with value '{value}' removed")
                : WriteResult.Success($"Key '{key}' doesn't exist");
        }

        public ReadResult<T> Find<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return ReadResult<T>.Failure($"Key parameter is missing");

            string value;
            if (storage.TryGetValue(key, out value))
                return ReadResult<T>.Success(value);

            return ReadResult<T>.Failure($"Key '{key}' not found");
        }

        public KeyValuePair<string, string>[] FindAll()
        {
            return storage.ToArray();
        }

        private ConcurrentDictionary<string, string> storage = new ConcurrentDictionary<string, string>();
    }
}
