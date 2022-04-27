using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class Archive
    {
        public Archive(string url)
        {
            this.TradingDays = GetData(url);
            SaveToDb();
        }

        private void SaveToDb()
        {
            
        }

        public List<TradingDay> TradingDays { get; set; }



        private List<TradingDay> GetData(string url)
        {
            List<TradingDay> days = new List<TradingDay>();

            XDocument document = XDocument.Load(url);

            // Deklarativ
            var qDays = from xe in document.Root.Descendants()
                        where xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => CheckAttribute(at, "time"))
                        // Projektion
                        select new TradingDay(xe);

            // Lambda
            var qDaysMeth = document.Root.Descendants()
                                        .Where(xe => xe.Name.LocalName == "Cube" && xe.Attributes().Any(at => at.Name == "time"))
                                        .Select(xe => new TradingDay(xe) { Date = Convert.ToDateTime(xe.Attribute("time").Value) });

            //foreach (XElement item in qDays)
            //{
            //    TradingDay day = new TradingDay() { Date = Convert.ToDateTime(item.Attribute("time").Value) };
            //    days.Add(day);
            //}

            days = qDays.ToList();
            // Alternative: days.AddRange(qDays);

            return days;
        }

        private bool CheckAttribute(XAttribute at, string name)
        {
            {
                if (at.Name == name)
                {
                    return true;
                }
                return false;
            }

        }

        private List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}