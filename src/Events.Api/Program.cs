namespace EventsApi;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] arguments) =>
        CreateHostBuilder(arguments).Build().Run();

    public static IHostBuilder CreateHostBuilder(string[] arguments) =>
        Host.CreateDefaultBuilder(arguments)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
}
