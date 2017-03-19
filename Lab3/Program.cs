using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Lab4.Startup>()
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
