using System.Collections.Generic;
using FilmwerteChallenge.Infrastructure;
using FilmwerteChallenge.Interfaces;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;

namespace FilmwerteChallenge.Infrastructure
{
    public class StorageAdapter : IDataAccessService
    {
        readonly IDataAccessService _disk;
        readonly IDataAccessService _memory;
        private readonly IConfiguration _config;

        public StorageAdapter(
            DiskDataService disk,
             InMemoryDataService memory,
             IConfiguration config)
        {
            _memory = memory;
            _disk = disk;
            _config = config;
        }

        private int storageType => _config.GetValue<int>("storageType");
        private IDataAccessService db => storageType == 1 ? _disk : _memory;

        public void AddVideo(Movie movie)
        {
            db.AddVideo(movie);
        }


        public void AddVideo(Episode episode)
        {
            db.AddVideo(episode);
        }

        public void RemoveVideo(Movie movie)
        {
            db.RemoveVideo(movie);
        }


        public void RemoveOneEpisode(Episode episode)
        {
            db.RemoveOneEpisode(episode);
        }

        public IEnumerable<Movie> GetAllVideos(SortParam sortparam)
        {
            return db.GetAllVideos(sortparam);
        }

        public IEnumerable<Episode> GetAllEpisodes()
        {
            return db.GetAllEpisodes();
        }
        public int WhatIsStorageType()
        {
            return _config.GetValue<int>("storageType");
        }

    }
}