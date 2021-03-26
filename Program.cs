
using System;
using System.Collections.Generic;

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
            Storage storage = new Storage();
            storage.AddVideo(new Movie
            {
                Title = "HAGER",
                Duration = 4781,
                VideoUri = "https://cdn.sample.com/nov_2019_hager_pro_res_1_1/nov_2019_hager_pro_res_1_1.mpd",
                ImdbId = "tt6698964"
            });
            storage.AddVideo(new Movie
            {
                Title = "Berlin 4 Lovers",
                Duration = 3480,
                VideoUri = "https://www.youtube.com/watch?v=K55o8_hrYtQ"
            });
            storage.AddVideo(new Movie
            {
                Title = "Resistance Fighters – The Global Antibiotics Crisis",
                Duration = 1682,
                VideoUri = "https://cdn.sample.com/master_bvp-_resistance_fighters_de-ins-ut_de-20_h264-high/youtube_source_bvp-_resistance_fighters_de-ins-ut_de-20_h264-high.mpd"
            });
            storage.AddVideo(new Movie
            {
                Title = "Following Habeck",
                Duration = 1095,
                VideoUri = "https://m.youtube.com/watch?v=vo8hxCLv4FU",
                ImdbId = "tt8014110"
            });
            storage.AddVideo(new Movie
            {
                Title = "Yves' Promise",
                Duration = 4738,
                VideoUri = "https://cdn.sample.de/yves-versprechen/yves-versprechen.mpd",
                ImdbId = "tt7842194"
            });

            // see #1
            IEnumerable<Movie> allMovies = storage.GetAllVideos();
            Console.WriteLine("All movies:");
            var headerSpan = "{0, -36} {1, -25} {2, -15} {3, -25}";
            var detailSpan = "{0, -36} {1, -25} {2, 15} {3, -25}";

            Console.WriteLine($"{headerSpan}\n", "ID", "Title", "Duration (mins)", "Video URI");
            foreach (Movie movie in allMovies)
                Console.WriteLine($"{detailSpan}", movie.Id, movie.Title, movie.Duration / 60, movie.VideoUri);

            // see #2
            IEnumerable<Movie> query1 = storage.GetAllVideos(); // TODO
            Console.WriteLine("Query 1:");
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
