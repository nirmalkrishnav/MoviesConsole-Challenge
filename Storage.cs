
using System.Collections.Generic;
// using Microsoft.Extensions.Configuration;
using FilmwerteChallenge.Models;

namespace FilmwerteChallenge
{
    /// <summary>
    /// Represents an in-memory storage for a list of movies.
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Contains the in-memory storage for all movies.
        /// </summary>
        private List<Movie> videos = new List<Movie>();

        /// <summary>
        /// Adds a new movie to the storage.
        /// </summary>
        /// <param name="movie">The movie that is to be stored.</param>
        public void AddVideo(Movie movie)
        {
            this.videos.Add(movie);

        }

        /// <summary>
        /// Remove a movie from the storage.
        /// </summary>
        /// <param name="movie">The movie that is to be removed from storage.</param>
        public void RemoveVideo(Movie movie)
        {
            this.videos.Remove(movie);
        }

        /// <summary>
        /// Gets a list of all stored movies.
        /// </summary>
        /// <returns>Returns a list of all stored movies.</returns>
        public IEnumerable<Movie> GetAllVideos()
        {
            return this.videos;
        }
    }
}
