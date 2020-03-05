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
    /// Interaction logic for PregledResursaTool.xaml
    /// </summary>
    public partial class PregledResursaTool : Window
    {
        public PregledResursaTool()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PregledResursa pr = new PregledResursa();
            this.Close();
            pr.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PregledTipa pr = new PregledTipa();
            this.Close();
            pr.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            PregledEtiketa pr = new PregledEtiketa();
            this.Close();
            pr.Show();
        }
    }
}
