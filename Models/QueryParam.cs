using FilmwerteChallenge.Enums;

namespace FilmwerteChallenge.Models
{
    public class QueryParam
    {
        public FilterParam FilterParam { get; set; } = new FilterParam();
        public string OrderBy { get; set; } = "";

    }

    public class FilterParam
    {
        public string Domain { get; set; } = "";
        public int MinDuration { get; set; } = 0;
        public ContentType VideoContentType { get; set; } = ContentType.Movie;
        public bool HasImdb { get; set; } = false;

    }

}