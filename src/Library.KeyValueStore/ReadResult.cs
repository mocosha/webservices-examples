using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocosha.Library.KeyValueStore
{
    public class ReadResult<T>
    {
        public static ReadResult<T> Success(string value, string message = "")
        {
            var deserializedValue = (typeof(T) == typeof(string)) 
                ? (T)(object)value
                : Serializer.Deserialize<T>(value);

            return new ReadResult<T>()
            {
                IsSuccess = true,
                Value = deserializedValue,
                Message = message
            };
        }

        public static ReadResult<T> Failure(string message)
        {
            return new ReadResult<T>()
            {
                IsSuccess = false,
                Message = message
            };
        }

        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Message { get; set; }
    }
}
