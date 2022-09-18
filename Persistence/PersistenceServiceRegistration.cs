using Application;
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                           options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                       );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ISuggestedMovieRepository, SuggesionMovies>();
            services.AddScoped<IMovieWatchListRepository, MovieWatchListRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddHostedService<SuggesionJob>();
            return services;
        }
    }
}
