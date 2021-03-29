
using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;
using FilmwerteChallenge.Services;


namespace FilmwerteChallenge
{
    public class App{
        public StorageService _storage;

        public App(StorageService storage) {
            _storage = storage;
        }

        public void StoreSampleData() {
            
            _storage.AddVideo(new Movie
            {
                Title = "HAGER",
                Duration = 4781,
                VideoUri = "https://cdn.sample.com/nov_2019_hager_pro_res_1_1/nov_2019_hager_pro_res_1_1.mpd",
                ImdbId = "tt6698964"
            });
            _storage.AddVideo(new Movie
            {
                Title = "Berlin 4 Lovers",
                Duration = 3480,
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
                VideoUri = "https://m.youtube.com/watch?v=vo8hxCLv4FU",
                ImdbId = "tt8014110"
            });
            _storage.AddVideo(new Movie
            {
                Title = "Yves' Promise",
                Duration = 4738,
                VideoUri = "https://cdn.sample.de/yves-versprechen/yves-versprechen.mpd",
                ImdbId = "tt7842194"
            });

            _storage.AddVideo(new Movie
            {
                Title = "HAGER",
                Duration = 4781,
                VideoUri = "https://cdn.sample.com/nov_2019_hager_pro_res_1_1/nov_2019_hager_pro_res_1_1.mpd",
                ImdbId = "tt6698964"
            });

        }

        public void Query1() {
            IEnumerable<Movie> allMovies = _storage.GetAllVideos();
            Console.WriteLine("All movies:");
            var headerSpan = "{0, -36} {1, -25} {2, -15} {3, -25}";
            var detailSpan = "{0, -36} {1, -25} {2, 15} {3, -25}";

            Console.WriteLine($"{headerSpan}\n", "ID", "Title", "Duration (mins)", "Video URI");
            foreach (Movie movie in allMovies)
                Console.WriteLine($"{detailSpan}", movie.Id, movie.Title, movie.Duration / 60, movie.VideoUri);

        }

        public void Query2() {
            IEnumerable<Movie> query1 = storage.GetAllVideos(); // TODO
            Console.WriteLine("\n\nQuery 1:");
            Console.WriteLine("All movies that are longer than 30 minutes");
            foreach (Movie movie in query1)
                Console.WriteLine(movie.Id);

            IEnumerable<Movie> query2 = storage.GetAllVideos(); // TODO
            Console.WriteLine("Query 2:");
            foreach (Movie movie in query2)
                Console.WriteLine(movie.Id);

            IEnumerable<Movie> query3 = storage.GetAllVideos(); // TODO
            Console.WriteLine("Query 3:");
            foreach (Movie movie in query3)
                Console.WriteLine(movie.Id);
        }

    }
}