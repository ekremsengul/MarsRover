using MarsRover.Business;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<App>();
            services.SetupRoverService();
        }
    }
}
