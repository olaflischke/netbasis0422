using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class Archive
    {
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
        }

        public List<TradingDay> TradingDays { get; set; }



        private List<TradingDay> GetData(string url)
        {
            List<TradingDay> days = new List<TradingDay>();

            XDocument document = XDocument.Load(url);

            var qDays = from xe in document.Root.Descendants()
                        where xe.Name.LocalName == "Cube" && xe.Attributes().Count() == 1
                        // Projektion
                        select new TradingDay() { Date = Convert.ToDateTime(xe.Attribute("time").Value) };

            //foreach (XElement item in qDays)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            days = qDays.ToList();
            // Alternative: days.AddRange(qDays);

            return days;
        }

        private List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}