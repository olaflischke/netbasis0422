namespace EierfarmBl
{
    public class Henne
    {
        public event EventHandler EigenschaftGeaendert;

        private void OnEigenschaftGeaendert()
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new EventArgs());
            }
        }

        public Henne(string name)
        {
            this.Name = name;
            //this.Gewicht = 1000;

            //this.Eier = new List<Ei>();
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnEigenschaftGeaendert();
            }
        }

        private double _gewicht = 1000;

        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert();
            }
        }

        public int Id { get; set; }
        public DateTime Schluepfdatum { get; set; }
        public List<Ei> Eier { get; set; } = new List<Ei>(); // Auto-Property-Initializer

        public void Fressen()
        {
            if (this.Gewicht <= 3000)
            {
                //this.Gewicht = this.Gewicht + 100;
                this.Gewicht += 100;
            }
        }

        public void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                Ei ei = new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }
    }
}
