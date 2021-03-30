using System;
using FilmwerteChallenge.Enums;

namespace FilmwerteChallenge.Models
{
    /// <summary>
    /// Represents a set of metadata of a Video Content.
    /// </summary>
    public class VideoContent
    {
        /// <summary>
        /// Gets or sets the ID of the movie, which is globally unique.
        /// </summary>
        public string Id { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// Gets or sets the official movie title in English.
        /// </summary>

        public string Title { get; set; }
        /// <summary>

        /// Gets or sets the duration of the movie in seconds.
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the URI that points to the web storage where the movie file is located.
        /// </summary>
        public string VideoUri { get; set; }

        /// <summary>
        /// Gets or sets the Type Of Content
        /// 1. Movies
        /// 2. Episode
        /// </summary>
        public ContentType TypeOfContent { get; set; }
    }
}
