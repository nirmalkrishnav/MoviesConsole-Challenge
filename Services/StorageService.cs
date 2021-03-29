using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;

namespace FilmwerteChallenge.Services
{
    public class StorageService {
        
        /// <summary>
        /// Contains the in-memory storage for all movies.
        /// </summary>
        private List<Movie> videos = new List<Movie>();
        private List<Episode> series = new List<Episode>();

        /// <summary>
        /// Adds a new movie to the storage.
        /// </summary>
        /// <param name="movie">The movie that is to be stored.</param>
        public void AddVideo(Movie movie)
        {
            this.videos.Add(movie);
        }

        /// <summary>
        /// Adds a new episode to the storage.
        /// </summary>
        /// <param name="episode">The episode that is to be stored.</param>
        public void AddVideo(Episode episode)
        {
            this.series.Add(episode);
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