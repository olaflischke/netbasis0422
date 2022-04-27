using EierfarmBl;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace EierfarmUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnNeuesHuhn_Click(object sender, RoutedEventArgs e)
        {
            Henne henne = new Henne("Neues Huhn");

            //henne.EigenschaftGeaendert += this.Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(henne);
            cbxTiere.SelectedItem = henne;
        }

        private void btnNeueGans_Click(object sender, RoutedEventArgs e)
        {
            Gans gans = new Gans();

            //gans.EigenschaftGeaendert += this.Gefluegel_EigenschaftGeaendert;

            cbxTiere.Items.Add(gans);
            cbxTiere.SelectedItem = gans;
        }

        private void Gefluegel_EigenschaftGeaendert(object? sender, GefluegelEventArgs e)
        {
            if (sender is Gefluegel tier)
            {
                MessageBox.Show($"Tier {tier.Name} hat Eigenschaft { e.GeaenderteProperty} geändert.");
            }
        }

        private void Henne_EigenschaftGeaendert(object? sender, EventArgs e)
        {
            MessageBox.Show($"Tier {((Henne)sender).Name} hat Eigenschaft geämdert.");
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            Tier tier = cbxTiere.SelectedItem as Tier; // SafeCast - liefert null, wenn Cast fehlschlägt.
            if (tier != null)
            {
                tier.Fressen();

            }
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is IEileger tier)
            {
                tier.EiLegen();
            }
        }

        private void btnSpeichern_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is IEileger tier)
            {
            // Benutzer nach Speicherort fragen
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    RestoreDirectory = true,
                    Filter = "Henne|*.hn|Gans|*.gs|Schnabeltier|*.st|Alles|*.*",
                    FilterIndex = 1
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Tier als XML dort speichern
                    XmlSerializer serializer = new XmlSerializer(tier.GetType());
                    StreamWriter writer= new StreamWriter(saveFileDialog.FileName);
                    serializer.Serialize(writer, tier);

                    MessageBox.Show("Tier gespeichert.");
                }

            }


        }

        private void btnLaden_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
