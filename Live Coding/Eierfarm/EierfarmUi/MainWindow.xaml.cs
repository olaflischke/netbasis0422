using EierfarmBl;
using System;
using System.Collections.Generic;
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

            henne.EigenschaftGeaendert += this.Henne_EigenschaftGeaendert;

            cbxTiere.Items.Add(henne);
            cbxTiere.SelectedItem = henne;
        }

        private void Henne_EigenschaftGeaendert(object? sender, EventArgs e)
        {
            // MessageBox.Show($"Tier {((Henne)sender).Name} hat Eigenschaft geämdert.");
        }

        private void btnFuettern_Click(object sender, RoutedEventArgs e)
        {
            Henne henne = cbxTiere.SelectedItem as Henne; // SafeCast - liefert null, wenn Cast fehlschlägt.
            if (henne != null)
            {
                henne.Fressen();
            }
        }

        private void btnEiLegen_Click(object sender, RoutedEventArgs e)
        {
            if (cbxTiere.SelectedItem is Henne henne)
            {
                henne.EiLegen();
            }
        }
    }
}
