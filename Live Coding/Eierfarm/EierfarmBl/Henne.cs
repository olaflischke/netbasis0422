namespace EierfarmBl
{
    public class Henne : Gefluegel
    {
        private Henne():base("")
        {

        }

        public Henne(string name) : base(name)
        {
            this.Gewicht = 1000;
        }

        public override void Fressen()
        {
            if (this.Gewicht <= 3000)
            {
                //this.Gewicht = this.Gewicht + 100;
                this.Gewicht += 100;
            }
        }

        public override void EiLegen()
        {
            if (this.Gewicht > 1500)
            {
                //Huehnerei ei = new Huehnerei(this);
                Ei ei= new Ei(this);
                this.Gewicht -= ei.Gewicht;
                this.Eier.Add(ei);
            }
        }
    }
}
