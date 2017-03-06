using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocosha.Library.KeyValueStore
{
    public class WriteResult
    {
        public static WriteResult Success(string message)
        {
            return new WriteResult()
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static WriteResult Failure(string message)
        {
            return new WriteResult()
            {
                IsSuccess = false,
                Message = message
            };
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
