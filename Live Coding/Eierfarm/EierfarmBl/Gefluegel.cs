using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EierfarmBl
{
    public abstract class Gefluegel : Vogel, IEileger, INotifyPropertyChanged //, IGefluegel
    {
        public Gefluegel(string name)
        {
            this.Name = name;
        }

        // Eigenes Event mit eigenen EventArgs
        public event EventHandler<GefluegelEventArgs> EigenschaftGeaendert;

        // Event aus INotifyPropertyChanged
        // Aktualisieren der WPF-UI, wenn sich Elemente im Hintergrund ändern
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<Ei> Eier { get; set; } = new ObservableCollection<Ei>();

        private double _gewicht;
        public double Gewicht
        {
            get { return _gewicht; }
            set
            {
                _gewicht = value;
                OnEigenschaftGeaendert(); // nameof(this.Gewicht));
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }

        public DateTime Schluepfdatum { get; set; }

        private void OnEigenschaftGeaendert([CallerMemberName] string propertyName = "")
        {
            if (EigenschaftGeaendert != null)
            {
                EigenschaftGeaendert(this, new GefluegelEventArgs(propertyName));
            }
        }

        public abstract void EiLegen();
    }

    public class GefluegelEventArgs : EventArgs
    {
        public GefluegelEventArgs(string geaenderteProperty)
        {
            this.GeaenderteProperty = geaenderteProperty;
        }

        public string GeaenderteProperty { get; set; }
    }
}