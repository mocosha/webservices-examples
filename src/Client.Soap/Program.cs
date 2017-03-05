using System;
using System.Configuration;
using System.ServiceModel;

namespace Mocosha.SoapTestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleStorage.SimpleServiceClient client = new SimpleStorage.SimpleServiceClient();

            var endpoint = ConfigurationManager.AppSettings["endpoint"];
            client.Endpoint.Address = new EndpointAddress(endpoint);

            var result = client.Add(null);
            Console.WriteLine(result);

            result = client.Add("test2");
            Console.WriteLine(result);

            result = client.AddWithKey("ABC", "test2");
            Console.WriteLine(result);

            result = client.Remove("ABC");
            Console.WriteLine(result);

            result = client.AddAnimal("11", new SimpleStorage.Animal { Name = "lav" });
            Console.WriteLine(result);

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Items from storage as key - value:");
            foreach (var item in client.GetAll())
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            Console.ReadKey(true);
        }
    }
}
