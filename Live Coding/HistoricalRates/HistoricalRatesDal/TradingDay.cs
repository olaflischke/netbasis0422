using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            // Date

            // ExchangesRates

        }

        public DateTime Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}