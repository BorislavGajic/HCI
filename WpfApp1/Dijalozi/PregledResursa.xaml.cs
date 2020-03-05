using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PregledResursa.xaml
    /// </summary>
    public partial class PregledResursa : Window
    {
        private ObservableCollection<KlasaPolja> res;


        public ObservableCollection<KlasaPolja> Res
        {
            get { return res; }
            set { res = value; }
        }

        public PregledResursa()
        {

            Res = new ObservableCollection<KlasaPolja>();
            ucitajResurse();

            this.DataContext = this;
            InitializeComponent();
        }

        public void ucitajResurse()
        {
            foreach (KlasaPolja kp in MainWindow.instanca.Resursi.Values)
            {
                Res.Add(kp);
            }
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            System.ComponentModel.ICollectionView cv = CollectionViewSource.GetDefaultView(res);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    KlasaPolja kp = o as KlasaPolja;
                    string[] words = filter.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => kp.Id.ToUpper().Contains(word.ToUpper()));
                };

                dgrMain.ItemsSource = res;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            System.ComponentModel.ICollectionView cv = CollectionViewSource.GetDefaultView(res);
            if (filter == "")
                cv.Filter = null;
            else
            {
                cv.Filter = o =>
                {
                    KlasaPolja kp = o as KlasaPolja;
                    string[] words = filter.Split(' ');
                    if (words.Contains(""))
                        words = words.Where(word => word != "").ToArray();
                    return words.Any(word => kp.Ime.ToUpper().Contains(word.ToUpper()));
                };

                dgrMain.ItemsSource = res;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KlasaPolja kp = null;
            if (dgrMain.SelectedItem is KlasaPolja)
            {
                kp = (KlasaPolja)dgrMain.SelectedValue;
                Edit edit = new Edit(kp.Ime);
                edit.Show();

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            KlasaPolja kp = null;
            if (dgrMain.SelectedItem is KlasaPolja)
            {
                kp = (KlasaPolja)dgrMain.SelectedValue;
                MainWindow.instanca.Resursi.Remove(kp.Ime);
                MainWindow.instanca.refresh();
                res.Remove(kp);
                dgrMain.Items.Refresh();
                dgrMain.UpdateLayout();

            }
        }
    }
}
