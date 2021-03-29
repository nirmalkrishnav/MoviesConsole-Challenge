
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

            var host = CreateHostBuilder(args).Build();
            var app = host.Services.GetRequiredService<App>();
            app.StoreSampleData();
            app.Query1();
            app.Query2();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<App>();
                    services.AddTransient<IStorageService, StorageService>();
                    services.AddTransient<IDataAccessService, DiskDataService>();
                    services.AddTransient<IDataAccessService, InMemoryDataService>();

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
