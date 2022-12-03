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
            using (var scope = serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                repository.Migrate();
            }
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
