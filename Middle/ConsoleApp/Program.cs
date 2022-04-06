using System;
using System.Threading.Tasks;
using iLib;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello NDC Security 2022!");
            Console.WriteLine($"ConsoleApp - {typeof(System.Net.Http.HttpClient).Assembly.Location}");
            
            var loadContext = new IsolatedLoadContext("../Pub/lib.dll", new[]{ typeof(IProcessor) });
            var d = loadContext.CreateInstance<IProcessor>();

            var result = await d.ProcessDocumentAsync("Docs/schedule.pdf","Output/schedule2022.pdf");
            //var result = await d.ProcessDocumentAsync("https://ndc-security.com","output/ndcsecurity.html");
            
            Console.WriteLine("Done...");
        }
    }
}