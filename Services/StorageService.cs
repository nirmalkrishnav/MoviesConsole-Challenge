using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;
using FilmwerteChallenge.Interfaces;
using System.Linq;
using FilmwerteChallenge.Enums;
using ClosedXML.Excel;

namespace FilmwerteChallenge.Services
{
    public class StorageService : IStorageService
    {
        private readonly IConfiguration _config;
        private readonly IDataAccessService _dataAccess;
        private readonly IReportService _reportService;


        public StorageService(
            IConfiguration config,
            IDataAccessService dataAccess,
             IReportService reportService
            )
        {
            _config = config;
            _dataAccess = dataAccess;
            _reportService = reportService;
        }

        private string reportsPath => _config.GetValue<string>("reportsPath");

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
        public IEnumerable<Movie> GetAllMovies(QueryParam sortParam)
        {
            var result = _dataAccess.GetAllMovies();
            if (sortParam.FilterParam.MinDuration > 0)
            {
                result = result.Where(movie => movie.Duration > sortParam.FilterParam.MinDuration);
            }

            if (sortParam.FilterParam.Domain != null && sortParam.FilterParam.Domain.Length > 0)
            {
                result = result.Where(movie => new Uri(movie.VideoUri).Host.ToUpper().Contains(sortParam.FilterParam.Domain.ToUpper()));
            }
            if (sortParam.FilterParam.HasImdb)
            {
                result = result.Where(movie => movie.ImdbId != null && movie.ImdbId.Length > 0);
            }


            switch (sortParam.OrderBy)
            {
                case "TITLE":
                    result = result.OrderBy(movie => movie.Title);
                    break;
            }


            return result;
        }

        /// <summary>
        /// Gets sum of total duration according to sort,filter param.
        /// </summary>
        /// <returns>Returns a int  total duration in seconds.</returns>
        public int GetAllVideosRunTimeTotal(QueryParam sortParam)
        {
            var result = GetAllMovies(sortParam);
            return result.Select(m => m.Duration).Aggregate(0, (acc, x) => acc + x);
        }

        /// <summary>
        /// Gets a list of all stored movies.
        /// </summary>
        /// <returns>Returns a list of all stored movies.</returns>
        public IEnumerable<Episode> GetAllEpisodes(QueryParam sortParam)
        {
            var result = _dataAccess.GetAllEpisodes();
            if (sortParam.FilterParam.MinDuration > 0)
            {
                result = result.Where(movie => movie.Duration > sortParam.FilterParam.MinDuration);
            }

            if (sortParam.FilterParam.Domain != null && sortParam.FilterParam.Domain.Length > 0)
            {
                result = result.Where(movie => new Uri(movie.VideoUri).Host.ToUpper().Contains(sortParam.FilterParam.Domain.ToUpper()));
            }

            switch (sortParam.OrderBy)
            {
                case "TITLE":
                    result = result.OrderBy(movie => movie.Title);
                    break;
            }


            return result;
        }

        public int WhatIsStorageType()
        {
            return _config.GetValue<int>("storageType");
        }

        public void GenerateReport()
        {
            IEnumerable<Movie> allMovies = _dataAccess.GetAllMovies();
            IEnumerable<Episode> allEpisodes = _dataAccess.GetAllEpisodes();

            _reportService.GenerateReport(allMovies, allEpisodes);
        }
    }
}