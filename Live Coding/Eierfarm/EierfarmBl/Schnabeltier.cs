using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace EierfarmBl
{
    public class Schnabeltier : Saeugetier, IEileger
    {
        public double Gewicht{get;set;}

        public ObservableCollection<Ei> Eier{get;set;}=new ObservableCollection<Ei>();

        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        public void EiLegen()
        {
            if (this.Gewicht>2000)
            {
                Ei ei = new Ei(this);
                this.Gewicht-=ei.Gewicht;
                this.Eier.Add(ei);  
            }
        }

        public override void Fressen()
        {
            throw new NotImplementedException();
        }

        public override void Saeugen()
        {
            throw new NotImplementedException();
        }
    }
}