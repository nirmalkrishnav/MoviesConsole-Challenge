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
        IEnumerable<Movie> GetAllMovies(QueryParam sortparam);
        IEnumerable<Episode> GetAllEpisodes(QueryParam sortParam);
        int WhatIsStorageType();
        int GetAllVideosRunTimeTotal(QueryParam sortParam);
        
    }
}