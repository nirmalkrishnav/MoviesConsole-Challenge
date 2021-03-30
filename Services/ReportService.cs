using System;
using System.Collections.Generic;
using FilmwerteChallenge.Models;
using Microsoft.Extensions.Configuration;
using FilmwerteChallenge.Interfaces;
using System.Linq;
using FilmwerteChallenge.Enums;
using ClosedXML.Excel;
using System.IO;

namespace FilmwerteChallenge.Services
{
    public class ReportService : IReportService
    {

        private readonly IConfiguration _config;
        private readonly IDataAccessService _dataAccess;


        public ReportService(
            IConfiguration config,
            IDataAccessService dataAccess
            )
        {
            _config = config;
            _dataAccess = dataAccess;
        }

        private string reportsPath => _config.GetValue<string>("reportsPath");

        public void GenerateReport(IEnumerable<Movie> allMovies, IEnumerable<Episode> allEpisodes)
        {
            var reportPath = $"{reportsPath}report_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm")}.xlsx";

            using (var workbook = new XLWorkbook())
            {
                var worksheet1 = workbook.Worksheets.Add("Movies");
                var currentRow = 1;

                worksheet1.Cell(currentRow, 1).Value = "ID";
                worksheet1.Cell(currentRow, 2).Value = "Content Type";
                worksheet1.Cell(currentRow, 3).Value = "Title";
                worksheet1.Cell(currentRow, 4).Value = "Duration";
                worksheet1.Cell(currentRow, 5).Value = "Video URI";

                foreach (Movie movie in allMovies)
                {
                    currentRow++;
                    worksheet1.Cell(currentRow, 1).Value = movie.Id;
                    worksheet1.Cell(currentRow, 2).Value = movie.TypeOfContent;
                    worksheet1.Cell(currentRow, 3).Value = movie.Title;
                    worksheet1.Cell(currentRow, 4).Value = movie.Duration;
                    worksheet1.Cell(currentRow, 5).Value = movie.VideoUri;
                }

                var worksheet2 = workbook.Worksheets.Add("Episodes");
                currentRow = 1;

                worksheet2.Cell(currentRow, 1).Value = "ID";
                worksheet2.Cell(currentRow, 2).Value = "Content Type";
                worksheet2.Cell(currentRow, 3).Value = "Title";
                worksheet2.Cell(currentRow, 4).Value = "Duration";
                worksheet2.Cell(currentRow, 5).Value = "Video URI";

                foreach (Episode episode in allEpisodes)
                {
                    currentRow++;
                    worksheet2.Cell(currentRow, 1).Value = episode.Id;
                    worksheet2.Cell(currentRow, 2).Value = episode.TypeOfContent;
                    worksheet2.Cell(currentRow, 3).Value = episode.Title;
                    worksheet2.Cell(currentRow, 4).Value = episode.Duration / 60;
                    worksheet2.Cell(currentRow, 5).Value = episode.VideoUri;
                }
                workbook.SaveAs(reportPath);
            }

        }

    }
}