using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;
using FilmwerteChallenge.Interfaces;

namespace FilmwerteChallenge.Services
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _config;
        private readonly IStorageService _dataAccess;

        public StorageService(
            IConfiguration config,
            IStorageService dataAccess
            )
        {
            _config = config;
            _dataAccess = dataAccess;
        }
        

        /// <summary>
        /// Adds a new movie to the storage.
        /// </summary>
        /// <param name="movie">The movie that is to be stored.</param>
        public void AddVideo(Movie movie)
        {
            _dataAccess.AddVideo(movie);
        }

        /// <summary>
        /// Adds a new episode to the storage.
        /// </summary>
        /// <param name="episode">The episode that is to be stored.</param>
        public void AddVideo(Episode episode)
        {
             _dataAccess.AddVideo(episode);
        }

        /// <summary>
        /// Remove a movie from the storage.
        /// </summary>
        /// <param name="movie">The movie that is to be removed from storage.</param>
        public void RemoveVideo(Movie movie)
        {
             _dataAccess.RemoveVideo(movie);
        }

        /// <summary>
        /// Remove a movie from the storage.
        /// </summary>
        /// <param name="episode">The movie that is to be removed from storage.</param>
        public void RemoveOneEpisode(Episode episode)
        {
             _dataAccess.RemoveOneEpisode(episode);
        }

        /// <summary>
        /// Gets a list of all stored movies.
        /// </summary>
        /// <returns>Returns a list of all stored movies.</returns>
        public IEnumerable<Movie> GetAllVideos()
        {
            return  _dataAccess.GetAllVideos();
        }

        /// <summary>
        /// Gets a list of all stored movies.
        /// </summary>
        /// <returns>Returns a list of all stored movies.</returns>
        public IEnumerable<Episode> GetAllEpisodes()
        {
            return _dataAccess.GetAllEpisodes();
        }

        public int WhatIsStorageType()
        {
            return _config.GetValue<int>("storageType");
        }

    }
}