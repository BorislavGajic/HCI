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
using System.Windows.Shapes;

namespace WpfApp1.Dijalozi
{
    /// <summary>
    /// Interaction logic for DodajKorisnikaTool.xaml
    /// </summary>
    public partial class DodajKorisnikaTool : Window
    {
        public DodajKorisnikaTool()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DijalogKorisnika dk = new DijalogKorisnika();
            this.Close();
            dk.Show();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dijalozi.DijalogTipa dt = new Dijalozi.DijalogTipa();
            this.Close();
            dt.ShowDialog();
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DijalogEtikete de = new DijalogEtikete();
            this.Close();
            de.ShowDialog();
            
        }
    }
}
