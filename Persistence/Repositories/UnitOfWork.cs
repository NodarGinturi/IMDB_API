using Microsoft.Extensions.DependencyInjection;
using Application.Contracts.Persistence;
using System;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IServiceProvider _serviceProvider;

        public UnitOfWork(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public IMovieRepository MovieRepository => _serviceProvider.GetService<IMovieRepository>();

        public ISuggestedMovieRepository SuggestedMovieRepository => _serviceProvider.GetService<ISuggestedMovieRepository>();

        public IMovieWatchListRepository WatchListRepository => _serviceProvider.GetService<IMovieWatchListRepository>();
        public IEmailService EmailService => _serviceProvider.GetService<IEmailService>();
    }
}
