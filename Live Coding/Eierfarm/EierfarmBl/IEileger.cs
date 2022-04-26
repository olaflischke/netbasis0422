using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfarmBl
{
    public interface IEileger
    {
        event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        double Gewicht { get; set; }
        ObservableCollection<Ei> Eier { get; set; }

        void EiLegen();
    }
}