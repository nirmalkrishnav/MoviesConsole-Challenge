
using System;
using FilmwerteChallenge.Enums;

namespace FilmwerteChallenge.Models
{
    /// <summary>
    /// Represents a set of metadata of a movie.
    /// </summary>
    public class Movie : VideoContent
    {
        /// <summary>
        /// Gets or sets the ID of the movie in the IMDb. Can be <c>null</c> if the movie is not present in the IMDb.
        /// The IMDb ID usually starts with "tt", followed by an integer.
        /// </summary>
        public string ImdbId { get; set; }
    }
}
