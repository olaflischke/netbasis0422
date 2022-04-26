using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EierfarmBl
{
    public class Fisch : IGefluegel, IEileger
    {

        ObservableCollection<Ei> IEileger.Eier
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }


        public string Eier
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public double Gewicht
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }


        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        public void EiLegen()
        {
            throw new NotImplementedException();
        }
    }
}
