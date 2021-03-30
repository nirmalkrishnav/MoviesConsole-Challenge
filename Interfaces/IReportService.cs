using System.Collections.Generic;
using FilmwerteChallenge.Models;

namespace FilmwerteChallenge.Interfaces
{
    public interface IReportService
    {
        void GenerateReport(IEnumerable<Movie> allMovies, IEnumerable<Episode> allEpisodes);
    }
}