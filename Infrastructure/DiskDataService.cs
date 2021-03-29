using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;

namespace FilmwerteChallenge.Infrastructure
{
    public class DiskDataService
    {
        private readonly IConfiguration _config;
        public DiskDataService(IConfiguration config) => _config = config;


    }
}