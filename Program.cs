
using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;
using FilmwerteChallenge.Services;

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
        static void Main()
        {
            StorageService storage = new StorageService();
            var program = new App(storage);
            program.StoreSampleData();

            // see #1
            program.Query1();
          
            // see #2
            program.Query2();
           

          
        }
    }
}
