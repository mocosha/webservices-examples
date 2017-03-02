using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mocosha.SoapTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SoapService.Service1Client ss = new SoapService.Service1Client();
            var result = ss.GetData(5);
            Console.WriteLine(result);
            Console.ReadKey(true);
        }
    }
}
