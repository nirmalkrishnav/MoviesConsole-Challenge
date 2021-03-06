using System;
using System.Collections.Generic;
using System.Linq;
using FilmwerteChallenge.Interfaces;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;


namespace FilmwerteChallenge.Infrastructure
{
    public class InMemoryDataService : IDataAccessService
    {
        private readonly IConfiguration _config;
        public InMemoryDataService(IConfiguration config) => _config = config;

        /// <summary>
        /// Contains the in-memory storage for all movies.
        /// </summary>
        private List<Movie> videos = new List<Movie>();
        private List<Episode> episodes = new List<Episode>();

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
            this.episodes.Add(episode);
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
        /// Remove a movie from the storage.
        /// </summary>
        /// <param name="episode">The movie that is to be removed from storage.</param>
        public void RemoveOneEpisode(Episode episode)
        {
            this.episodes.Remove(episode);
        }

        /// <summary>
        /// Gets a list of all stored movies.
        /// </summary>
        /// <returns>Returns a list of all stored movies.</returns>
        public IEnumerable<Movie> GetAllMovies()
        {
            return this.videos;
        }

        /// <summary>
        /// Gets a list of all stored episodes.
        /// </summary>
        /// <returns>Returns a list of all stored Episodes.</returns>
        public IEnumerable<Episode> GetAllEpisodes()
        {
            return this.episodes;
        }

        public string WhatIsStorageType()
        {
            return "In Memory";
        }

    }
}