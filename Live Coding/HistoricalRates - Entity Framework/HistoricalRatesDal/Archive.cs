using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Xml.Linq;

namespace HistoricalRatesDal
{
    public class Archive
    {
        public Archive(string url)
        {
            try
            {
                this.TradingDays = GetData(url);

                SaveToDb();

            }
            catch (ArchiveException ex)
            {
                throw new ArchiveException("Fehler beim Initialsieren des Archivs.", ex);
            }
            // Allgemeiner Catch für alle Exceptions, die oben nicht genannt wurden
            catch (Exception)
            {

                
            }
        }

        private void SaveToDb()
        {
            try
            {
                TradingDayContext context = new TradingDayContext();

                context.Database.EnsureCreated();

                context.TradingDays.AddRange(this.TradingDays);
                context.SaveChanges();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Gleichzeitiger, konkurrierender Datenzugriff behandeln -> lokale Behandlung des Problems
            }
            catch (Exception ex)
            {
                throw new ArchiveException("Fehler beim Datenzugriff", ex);
            }
        }

        public List<TradingDay> TradingDays { get; set; }



        private List<TradingDay> GetData(string url)
        {
            List<TradingDay> days = new List<TradingDay>();

            try
            {
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
            }
            catch (WebException ex)
            {
                // Internet nicht verfügbar,
                // wenn möglich, lade alte Daten aus der lokalen Db
                // + Benutzer davon informieren
            }

            catch (Exception ex)
            {

                throw new ArchiveException("Fehler beim Web-Zugriff", ex);
            }
            finally
            {

            }

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