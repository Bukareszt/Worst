using Microsoft.Extensions.Hosting;
using Backend.Persistence;

namespace Backend.Console.Hosts
{
    public class BaseHost : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        public BaseHost(IServiceProvider provider)
        {
            this.serviceProvider = provider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            serviceProvider.GetService<IUserRepository>()?.Migrate();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
