using FilmwerteChallenge.Models;
using System.Collections.Generic;

namespace FilmwerteChallenge.Interfaces
{
    public interface IDataAccessService
    {
        void AddVideo(Movie movie);
        void AddVideo(Episode episode);
        void RemoveVideo(Movie movie);
        void RemoveOneEpisode(Episode episode);
        IEnumerable<Movie> GetAllMovies();
        IEnumerable<Episode> GetAllEpisodes();
        string WhatIsStorageType();

    }
}