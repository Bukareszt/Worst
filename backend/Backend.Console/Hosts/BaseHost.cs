using Microsoft.Extensions.Hosting;
using Backend.Persistence;

namespace Backend.Console.Hosts
{
    public class BaseHost : IHostedService
    {
        private readonly IUserRepository repository;

        public BaseHost(IServiceProvider provider)
        {
            //this.repository = provider.GetService<IUserRepository>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //repository.Migrate();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
