namespace HotsLogsScraper.Models
{
    public class HeroStatistics
    {
        /// <summary>
        /// Number of times the hero was banned.
        /// </summary>
        public int GamesBanned { get; set; }

        /// <summary>
        /// Number of games in which the hero was picked.
        /// </summary>
        public int GamesPlayed { get; set; }

        /// <summary>
        /// The hero's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Percentage of games in which the hero was picked or banned.
        /// </summary>
        public float PopularityPercentage { get; set; }

        /// <summary>
        /// The hero's role, as defined in-game.
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// The hero's sub-role, as defined by HotsLogs.
        /// </summary>
        public SubRole SubRole { get; set; }

        /// <summary>
        /// Percentage of games in which the hero was on the winning team.
        /// </summary>
        public float WinPercentage { get; set; }
    }
}