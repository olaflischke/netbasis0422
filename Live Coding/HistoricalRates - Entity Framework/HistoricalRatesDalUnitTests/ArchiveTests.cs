using HistoricalRatesDal;
using NUnit.Framework;
using System;
using System.Globalization;
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

            Console.WriteLine($"Erster Tadingday: {archive.TradingDays.FirstOrDefault()?.Date:dd.MM.yy}");
            Console.WriteLine($"AUD des ersten TradingDays: {archive.TradingDays?.FirstOrDefault()?.ExchangeRates?.Where(er => er.Symbol=="AUD")?.FirstOrDefault()?.EuroRate}");

            Assert.AreEqual(GetCubeCount(), archive.TradingDays.Count);
        }

        [Test]
        public void DoubleConversion()
        {
            CultureInfo ci = new CultureInfo("tr-TR");
            NumberFormatInfo nfiTr = ci.NumberFormat;

            NumberFormatInfo nfi = new NumberFormatInfo()
            {
                NumberDecimalSeparator = ".",
                NumberGroupSeparator = ","
            }; // NumberFormatInfo.InvariantInfo;

            string wert = "1,234.567";
            double zahl = Convert.ToDouble(wert, ci.NumberFormat);
            Console.WriteLine(zahl);
        }

        private int GetCubeCount()
        {
            return 62;
        }
    }
}