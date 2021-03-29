using System.Collections.Generic;
using FilmwerteChallenge.Infrastructure;
using FilmwerteChallenge.Interfaces;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;

public class StorageAdapter : IStorageService
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
    private IDataAccessService serviceType => storageType == 1 ? _disk : _memory;

    public void AddVideo(Movie movie)
    {
        serviceType.AddVideo(movie);
    }


    public void AddVideo(Episode episode)
    {
        serviceType.AddVideo(episode);
    }

    public void RemoveVideo(Movie movie)
    {
        serviceType.RemoveVideo(movie);
    }


    public void RemoveOneEpisode(Episode episode)
    {
        serviceType.RemoveOneEpisode(episode);
    }

    public IEnumerable<Movie> GetAllVideos()
    {
        return serviceType.GetAllVideos();
    }

    public IEnumerable<Episode> GetAllEpisodes()
    {
        return serviceType.GetAllEpisodes();
    }
    public int WhatIsStorageType()
    {
        return _config.GetValue<int>("storageType");
    }

}