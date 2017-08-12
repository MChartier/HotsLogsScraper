using HotsLogsScraper.Models;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace HotsLogsScraper
{
    public class Scraper
    {
        private string hotsLogsBaseUrl = "https://www.hotslogs.com/";

        public List<HeroStatistics> ScrapeHeroStatistics()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(hotsLogsBaseUrl);

            return scrapeHeroStatistics(doc).Select(extractHeroStatistics).ToList();
        }

        private List<HtmlNode> scrapeHeroStatistics(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("//tr").Where(x => x.HasAttributes).ToList();
        }

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
                Role = role,
                SubRole = subRole,
                WinPercentage = float.Parse(winPercentage.Replace(" %", ""))
            };
        }
    }
}