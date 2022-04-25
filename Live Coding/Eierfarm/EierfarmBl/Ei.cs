namespace EierfarmBl
{
    public class Ei
    {
        public Ei()
        {
            Random random = new Random();
            this.Gewicht = random.Next(45, 81);

            //this.Gewicht = 70;
            //_gewicht = 80;

            // this.Farbe = (EiFarbe)42; Geht!

            this.Farbe = (EiFarbe)random.Next(Enum.GetNames<EiFarbe>().Count()); // DirectCast, schmeißt Exception, wenn der Cast fehlschlägt.
        }

        // Auto-Property
        // Property mit durch den Compiler automatisch generiertem Backing Field
        public int Id { get; private set; }

        public DateTime Legendatum { get; set; }

        // Gewicht-Property (full-qualified)
        // Property mit Backing Field

        // Backing Field
        private double _gewicht;

        // Ei ei = new Ei();

        // Öffenticher Teil der Property
        public double Gewicht
        {
            // Getter
            get { return _gewicht; } // var g = ei.Gewicht;
            // Setter
            set // ei.Gewicht = 65;
            {
                if (value >= 0)
                {
                    _gewicht = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }

        public EiFarbe Farbe { get; set; }
    }

    public enum EiFarbe
    {
        Hell,
        Dunkel,
        Gruen
    }
}