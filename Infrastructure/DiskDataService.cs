using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using FilmwerteChallenge.Interfaces;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;

namespace FilmwerteChallenge.Infrastructure
{
    public class DiskDataService : IDataAccessService
    {
        private readonly IConfiguration _config;
        public DiskDataService(IConfiguration config) => _config = config;

        private string movieJsonFile => _config.GetValue<string>("movieJson");
        private string episodeJsonFile => _config.GetValue<string>("episodeJson");

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
            try
            {
                string jsonStr = File.ReadAllText(@movieJsonFile);
                this.videos = JsonSerializer.Deserialize<List<Movie>>(jsonStr);
                this.videos.Add(movie);
            }
            catch (IOException e)
            {
                this.videos.Add(movie);
            }
            string json = JsonSerializer.Serialize(this.videos);
            File.WriteAllText(@movieJsonFile, json);
        }

        /// <summary>
        /// Adds a new episode to the storage.
        /// </summary>
        /// <param name="episode">The episode that is to be stored.</param>
        public void AddVideo(Episode episode)
        {
            try
            {
                string jsonStr = File.ReadAllText(@episodeJsonFile);
                this.episodes = JsonSerializer.Deserialize<List<Episode>>(jsonStr);
                this.episodes.Add(episode);
            }
            catch (IOException e)
            {
                this.episodes.Add(episode);
            }
            string json = JsonSerializer.Serialize(this.episodes);
            File.WriteAllText(@episodeJsonFile, json);
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
            string json = File.ReadAllText(@movieJsonFile);
            this.videos = JsonSerializer.Deserialize<List<Movie>>(json);
            return this.videos;
        }

        /// <summary>
        /// Gets a list of all stored movies.
        /// </summary>
        /// <returns>Returns a list of all stored movies.</returns>
        public IEnumerable<Episode> GetAllEpisodes()
        {
            string json = File.ReadAllText(@episodeJsonFile);
            this.episodes = JsonSerializer.Deserialize<List<Episode>>(json);
            return this.episodes;
        }

        public int WhatIsStorageType()
        {
            return 0;
        }
    }
}