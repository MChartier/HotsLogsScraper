using HotsLogsScraper.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HotsLogsScraper.UnitTests
{
    [TestClass]
    public class ScraperTests
    {
        private Scraper scraper;

        [TestInitialize]
        public void TestSetup()
        {
            scraper = new Scraper();
        }

        [TestMethod]
        public void ScrapeHeroStatistics_ReturnsHeroStatistics()
        {
            List<HeroStatistics> heroStatistics = scraper.ScrapeHeroStatistics();
            Assert.IsNotNull(heroStatistics, "Result should not be null.");
            Assert.IsTrue(heroStatistics.Count > 0, "Result should not be empty.");
            heroStatistics.ForEach(x => Assert.IsNotNull(x, "Items in resulting list should not be null."));
        }
    }
}