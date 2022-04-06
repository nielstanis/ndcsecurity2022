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

            var result = await d.ProcessDocumentAsync("Docs/schedule.pdf","niels.pdf");
            //var result = await d.ProcessDocumentAsync("https://ndc-security.com","output/security.html");
            Console.WriteLine($"{result.Item1} - {result.Item2}");

            // var client = new System.Net.Http.HttpClient();
            // var download = await client.GetStreamAsync("https://ndc-security.com");
            // var fileStream = new System.IO.FileStream("output.html", System.IO.FileMode.CreateNew);
            // await download.CopyToAsync(fileStream);
            
            Console.WriteLine("Done...");
        }
    }
}