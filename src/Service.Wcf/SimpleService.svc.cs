using System;
using System.Collections.Generic;
using Mocosha.Library.KeyValueStore;

namespace Mocosha.WcfService.SimpleStorage
{
    public class SimpleService : ISimpleService
    {
        private static Storage myStorage = Store.MyStorage;

        public KeyValuePair<string, string>[] FindAll()
        {
            return myStorage.FindAll();
        }

        public ReadResult<string> Find(string key)
        {
            return myStorage.Find<string>(key);
        }

        public WriteResult Add(string key, string value)
        {
            return myStorage.Insert(key, value);
        }

        public WriteResult Update(string key, string value)
        {
            return myStorage.Update(key, value);
        }

        public WriteResult Remove(string key)
        {
            return myStorage.Delete(key);
        }
    }
}
