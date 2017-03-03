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
            SimpleStorage.SimpleServiceClient ss = new SimpleStorage.SimpleServiceClient();
            var r = ss.Endpoint;

            var result = ss.Add(null);
            Console.WriteLine(result);

            result = ss.Add("test2");
            Console.WriteLine(result);

            result = ss.AddWithKey("ABC", "test2");
            Console.WriteLine(result);

            result = ss.Remove("ABC");
            Console.WriteLine(result);

            result = ss.AddAnimal("11", new SimpleStorage.Animal { Name = "lav" });
            Console.WriteLine(result);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Items from storage as key - value:");
            foreach (var item in ss.GetAll())
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.ReadKey(true);
        }
    }
}
