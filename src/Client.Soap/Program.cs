using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using Mono.Options;

namespace Mocosha.SoapTestClient
{
    class Program
    {
        static void PrintReadResult(SimpleService.ReadResultOfstring result)
        {
            Console.WriteLine($"IsSuccess: {result.IsSuccess}, Value: {result.Value}, Message: {result.Message}");
        }

        static void PrintWriteResult(SimpleService.WriteResult result)
        {
            Console.WriteLine($"IsSuccess: {result.IsSuccess}, Message: {result.Message}");
        }

        static void PrintAll(KeyValuePair<string, string>[] items)
        {
            if (items.Length == 0)
                Console.WriteLine("No items found");
            else
            {
                Console.WriteLine("Items from storage as key - value:");

                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
        }

        static void ShowHelp(OptionSet p)
        {
            Console.WriteLine("Usage: cli -command [key] [value]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }

        static void Main(string[] args)
        {
            // these variables will be set when the command line is parsed            
            var shouldShowHelp = args.Length == 0;

            var client = new SimpleService.SimpleServiceClient();

            var endpoint = "http://localhost:50051/SimpleService.svc/soap";
            client.Endpoint.Address = new EndpointAddress(endpoint);

            var options = new OptionSet {
                { "l|findall", "Find all.", _ => PrintAll(client.FindAll())},
                { "f|find", "Find item by key.", k => PrintReadResult(client.Find(k))},
                { "a|add=", "Add item.", (k,v) => PrintWriteResult(client.Add(k,v))},
                { "p|put=", "Update item by key.", (k,v) => PrintWriteResult(client.Update(k,v))},
                { "d|remove=", "Delete item by key.", k => PrintWriteResult(client.Remove(k))},
                { "h|help", "show this message and exit", h => shouldShowHelp = h != null },
            };

            List<string> extra;
            try
            {
                // parse the command line
                extra = options.Parse(args);
            }
            catch (OptionException e)
            {
                shouldShowHelp = true;
            }

            if (shouldShowHelp)
            {
                ShowHelp(options);
                return;
            }
        }
    }
}
