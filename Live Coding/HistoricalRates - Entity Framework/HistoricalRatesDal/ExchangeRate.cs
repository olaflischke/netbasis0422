namespace HistoricalRatesDal
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public double EuroRate { get; set; }
        public TradingDay TradingDay { get; set; }
    }
}