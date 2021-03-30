
using System;
using System.Collections.Generic;
using System.IO;
using FilmwerteChallenge.Interfaces;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;
using FilmwerteChallenge.Enums;


namespace FilmwerteChallenge
{
    public class App
    {
        private readonly IStorageService _storage;

        private readonly IConfiguration _config;
        private readonly IReportService _report;

        public App(
            IStorageService storage,
            IConfiguration config,
            IReportService report
        )
        {
            _storage = storage;
            _config = config;
            _report = report;

        }

        public void StoreSampleData()
        {

            _storage.AddVideo(new Movie
            {
                Title = "HAGER",
                Duration = 4781,
                TypeOfContent = ContentType.Movie,
                VideoUri = "https://cdn.sample.com/nov_2019_hager_pro_res_1_1/nov_2019_hager_pro_res_1_1.mpd",
                ImdbId = "tt6698964"
            });
            _storage.AddVideo(new Movie
            {
                Title = "Berlin 4 Lovers",
                Duration = 3480,
                TypeOfContent = ContentType.Movie,
                VideoUri = "https://www.youtube.com/watch?v=K55o8_hrYtQ"
            });
            _storage.AddVideo(new Movie
            {
                Title = "Resistance Fighters – The Global Antibiotics Crisis",
                Duration = 1682,
                VideoUri = "https://cdn.sample.com/master_bvp-_resistance_fighters_de-ins-ut_de-20_h264-high/youtube_source_bvp-_resistance_fighters_de-ins-ut_de-20_h264-high.mpd"
            });
            _storage.AddVideo(new Movie
            {
                Title = "Following Habeck",
                Duration = 1095,
                TypeOfContent = ContentType.Movie,
                VideoUri = "https://m.youtube.com/watch?v=vo8hxCLv4FU",
                ImdbId = "tt8014110"
            });
            _storage.AddVideo(new Movie
            {
                Title = "Yves' Promise",
                Duration = 4738,
                TypeOfContent = ContentType.Movie,
                VideoUri = "https://cdn.sample.de/yves-versprechen/yves-versprechen.mpd",
                ImdbId = "tt7842194"
            });

            _storage.AddVideo(new Movie
            {
                Title = "HAGER",
                Duration = 4781,
                TypeOfContent = ContentType.Movie,
                VideoUri = "https://cdn.sample.com/nov_2019_hager_pro_res_1_1/nov_2019_hager_pro_res_1_1.mpd",
                ImdbId = "tt6698964"
            });

            _storage.AddVideo(new Episode
            {
                Title = "Beginning",
                Duration = 4781,
                TypeOfContent = ContentType.Series,
                VideoUri = "https://cdn.netflix.com/mar_2020_dark_1_1/mar_2020_dark_1_1.mpd",
                SeasonNumber = 1,
                SeriesTitle = "Dark",
            });

            _storage.AddVideo(new Episode
            {
                Title = "Apocalypse",
                Duration = 5402,
                TypeOfContent = ContentType.Series,
                VideoUri = "https://cdn.netflix.com/mar_2020_dark_1_2/mar_2020_dark_1_2.mpd",
                SeasonNumber = 1,
                SeriesTitle = "Dark",
            });

        }

        public void Query1()
        {
            IEnumerable<Movie> allMovies = _storage.GetAllMovies(new QueryParam());
            Console.WriteLine("All movies:");
            var headerSpan = "{0, -36} {1, -25} {2, -15} {3, -25}";
            var detailSpan = "{0, -36} {1, -25} {2, 15} {3, -25}";
            Console.WriteLine($"{headerSpan}\n", "ID", "Title", "Duration (mins)", "Video URI");
            foreach (Movie movie in allMovies)
                Console.WriteLine($"{detailSpan}", movie.Id, movie.Title, movie.Duration / 60, new Uri(movie.VideoUri).Host);

        }

        public void QuerySeries()
        {
            IEnumerable<Episode> allSeries = _storage.GetAllEpisodes(new QueryParam());
            Console.WriteLine("\n\nAll Episodes:");
            var headerSpan = "{0, -36} {1, -25} {2, -15} {3, -25}";
            var detailSpan = "{0, -36} {1, -25} {2, 15} {3, -25}";

            Console.WriteLine($"{headerSpan}\n", "ID", "Title", "Duration (mins)", "Video URI");
            foreach (Episode ep in allSeries)
                Console.WriteLine($"{detailSpan}", ep.Id, ep.Title, ep.Duration / 60, ep.SeriesTitle);

        }

        public void Query2()
        {
            IEnumerable<Movie> query1 = _storage.GetAllMovies(new QueryParam()
            {
                FilterParam = new FilterParam()
                {
                    MinDuration = 30 * 60,
                    VideoContentType = Enums.ContentType.Movie
                },
            }); // TODO
            Console.WriteLine("\n\nQuery 1:");
            Console.WriteLine("All movies that are longer than 30 minutes");
            foreach (Movie movie in query1)
                Console.WriteLine(movie.Title);



            IEnumerable<Movie> query2 = _storage.GetAllMovies(new QueryParam()
            {
                OrderBy = "TITLE",
                FilterParam = new FilterParam()
                {
                    Domain = "YOUTUBE",
                    VideoContentType = Enums.ContentType.Movie
                },
            }); // TODO
            Console.WriteLine("\n\nQuery 2:");
            Console.WriteLine("All movies that are hosted on YouTube, ordered by title");
            foreach (Movie movie in query2)
                Console.WriteLine(movie.Title);


            int query3 = _storage.GetAllVideosRunTimeTotal(new QueryParam()
            {
                FilterParam = new FilterParam()
                {
                    HasImdb = true,
                    VideoContentType = Enums.ContentType.Movie
                },
            });
            Console.WriteLine($"\n\nQuery 3:");
            Console.WriteLine($"Total runtime of all movies that have an IMDb ID: {query3 / 60}");


        }

        public void GenerateReport()
        {
            try
            {
                _report.GenerateReport();
                Console.WriteLine("Report generated");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error generating report: {e.Message}");
            }
        }

        public void WhatIsStorageType()
        {
            Console.WriteLine(_storage.WhatIsStorageType());
        }

    }
}