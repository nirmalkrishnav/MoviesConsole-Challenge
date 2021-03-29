using FilmwerteChallenge.Models;
using System.Collections.Generic;

namespace FilmwerteChallenge.Interfaces
{
    public interface IStorageService
    {
         void AddVideo(Movie movie);
         void AddVideo(Episode episode);
         void RemoveVideo(Movie movie);
        void RemoveOneEpisode(Episode episode);
        IEnumerable<Movie> GetAllVideos();
        IEnumerable<Episode> GetAllEpisodes();
        int WhatIsStorageType();
    }
}