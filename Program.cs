
using System;
using System.Collections.Generic;
using FilmwerteChallenge.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using FilmwerteChallenge.Infrastructure;
using FilmwerteChallenge.Interfaces;

namespace FilmwerteChallenge
{
    /// <summary>
    /// Represents the main program of the challenge.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Represents the main function of the program.
        /// </summary>
        static void Main(string[] args)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            BuildConfig(builder);


            var host = CreateHostBuilder(args, builder).Build();
            var app = host.Services.GetRequiredService<App>();
            app.StoreSampleData();
            app.Query1();
            app.Query2();
        }

        private static IHostBuilder CreateHostBuilder(string[] args, ConfigurationBuilder builder)
        {
            IConfiguration configuration = builder.Build();


            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<App>();
                    services.AddTransient<IStorageService, StorageService>();

                    if (configuration.GetValue<int>("storageType") == 1)
                    {
                        services.AddTransient<IDataAccessService, InMemoryDataService>();
                    }
                    else
                    {
                        services.AddTransient<IDataAccessService, DiskDataService>();
                    }

                });
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile("appsettings.prod.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        }
    }
}
