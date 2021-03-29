using System;

namespace FilmwerteChallenge.Models
{
    /// <summary>
    /// Represents a set of metadata of an Episode.
    /// </summary>
    public class Episode: VideoContent
    {
        /// <summary>
        /// Gets or sets the Series Title
        /// </summary>
        public string SeriesTitle { get; set; }
        /// <summary>

        /// Gets or sets the Season Number
        /// </summary>
        public int SeasonNumber { get; set; }
        
    }
}
