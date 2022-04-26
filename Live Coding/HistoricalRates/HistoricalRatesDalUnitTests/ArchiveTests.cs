using HistoricalRatesDal;
using NUnit.Framework;
using System;
using System.Linq;

namespace HistoricalRatesDalUnitTests
{
    public class ArchiveTests
    {
        string url;

        [SetUp]
        public void Setup()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void IsArchiveInitializing()
        {
            Archive archive = new Archive(url);

            Console.WriteLine($"Erster Tadingday: {archive.TradingDays.First().Date:dd.MM.yy}");

            Assert.AreEqual(GetCubeCount(), archive.TradingDays.Count);
        }

        private int GetCubeCount()
        {
            return 62;
        }
    }
}