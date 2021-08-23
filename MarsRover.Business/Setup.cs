using MarsRover.Business.Abstractions;
using MarsRover.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Business
{
    public static class Setup
    {
        public static void SetupRoverService(this IServiceCollection services)
        {
            services.AddTransient<IRoverService, RoverService>();
        }
    }
}
