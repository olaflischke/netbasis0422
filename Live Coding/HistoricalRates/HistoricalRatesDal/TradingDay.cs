namespace HistoricalRatesDal
{
    public class TradingDay
    {
        public DateTime Date { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
}