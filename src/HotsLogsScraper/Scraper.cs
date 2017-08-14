using cloudscribe.HtmlAgilityPack;
using HotsLogsScraper.Models;
using System.Collections.Generic;
using System.Linq;

namespace HotsLogsScraper
{
    /// <summary>
    /// HotsLogs web scraper.
    /// </summary>
    public class Scraper
    {
        #region Private Fields

        private const string hotsLogsBaseUrl = "https://www.hotslogs.com/";

        private static readonly Dictionary<string, Role> roleDictionary = new Dictionary<string, Role>()
        {
            { "Warrior", Role.Warrior }, { "Assassin", Role.Assassin }, { "Support", Role.Support },
            { "Specialist", Role.Specialist }
        };

        private static readonly Dictionary<string, SubRole> subRoleDictionary = new Dictionary<string, SubRole>()
        {
            { "Tank", SubRole.Tank }, { "Bruiser", SubRole.Bruiser }, { "Healer", SubRole.Healer },
            { "Support", SubRole.Support }, { "Ambusher", SubRole.Ambusher },
            { "Burst Damage", SubRole.BurstDamage }, { "Sustained Damage", SubRole.SustainedDamage },
            { "Siege", SubRole.Siege }, { "Utility", SubRole.Utility }
        };

        #endregion Private Fields

        #region Public Methods

        /// <summary>
        /// Scrape the table of "Sitewide Hero Statistics over the Last 7 Days" from the HotsLogs front page.
        /// This data is limited to Hero League matches where the player's Hero Level was at least 5.
        /// </summary>
        /// <returns>A list containing a HeroStatistics object for each scraped row.</returns>
        public List<HeroStatistics> ScrapeHeroStatistics()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(hotsLogsBaseUrl);

            return scrapeHeroStatistics(doc).Select(extractHeroStatistics).ToList();
        }

        #endregion Public Methods

        #region Private Methods

        private HeroStatistics extractHeroStatistics(HtmlNode node)
        {
            var childNodes = node.SelectNodes(".//td").ToList();
            string name = childNodes[1].ChildNodes[0].Attributes["title"].Value;
            string gamesPlayed = childNodes[2].InnerText;
            string gamesBanned = childNodes[3].InnerText;

            string popularityPercentage = childNodes[4].InnerText;

            string winPercentage = childNodes[5].InnerText;

            string role = childNodes[7].InnerText;
            string subRole = childNodes[8].InnerText;

            return new HeroStatistics()
            {
                GamesBanned = int.Parse(gamesBanned.Replace(",", "")),
                GamesPlayed = int.Parse(gamesPlayed.Replace(",", "")),
                Name = name,
                PopularityPercentage = float.Parse(popularityPercentage.Replace(" %", "")),
                Role = parseRole(role),
                SubRole = parseSubRole(subRole),
                WinPercentage = float.Parse(winPercentage.Replace(" %", ""))
            };
        }

        private Role parseRole(string role)
        {
            return roleDictionary.ContainsKey(role) ? roleDictionary[role] : Role.Unknown;
        }

        private SubRole parseSubRole(string subRole)
        {
            return subRoleDictionary.ContainsKey(subRole) ? subRoleDictionary[subRole] : SubRole.Unknown;
        }

        private List<HtmlNode> scrapeHeroStatistics(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//tr").Where(x => x.HasAttributes).ToList();
        }

        #endregion Private Methods
    }
}