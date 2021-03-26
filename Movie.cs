
using System;

namespace FilmwerteChallenge
{
    /// <summary>
    /// Represents a set of metadata of a movie.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Gets or sets the ID of the movie, which is globally unique.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the official movie title in English.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the duration of the movie in seconds.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the URI that points to the web storage where the movie file is located.
        /// </summary>
        public string VideoUri { get; set; }

        /// <summary>
        /// Gets or sets the ID of the movie in the IMDb. Can be <c>null</c> if the movie is not present in the IMDb.
        /// The IMDb ID usually starts with "tt", followed by an integer.
        /// </summary>
        public string ImdbId { get; set; }
    }
}
