using Application.Contracts.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public class SuggesionJob : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly int _taskDelayHours;

        public SuggesionJob(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _taskDelayHours = Convert.ToInt32(configuration["TaskDelayHours"]);
        }

        protected override async Task ExecuteAsync(CancellationToken StoppingToken)
        {
            while (!StoppingToken.IsCancellationRequested)
            {
                using (var Scope = _serviceProvider.CreateScope())
                {
                    var OfferService = Scope.ServiceProvider.GetRequiredService<ISuggestedMovieRepository>();
                    await OfferService.SendUserSuggestedEmail();
                }
                await Task.Delay(TimeSpan.FromHours(_taskDelayHours), StoppingToken);
            }
        }
    }
}
