using System;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            SetGlobalExceptionHandler();

            var services = new ServiceCollection();
            var startup = new Startup();
            startup.ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<App>();

            app.Run();

            Console.WriteLine("END");
            Console.ReadKey();
        }

        static void SetGlobalExceptionHandler()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ExceptionObject.ToString());
            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

}
