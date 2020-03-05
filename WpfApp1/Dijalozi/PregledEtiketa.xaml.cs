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
    /// Interaction logic for PregledEtiketa.xaml
    /// </summary>
    public partial class PregledEtiketa : Window
    {
        private ObservableCollection<Etiketa> _etik;


        public ObservableCollection<Etiketa> Etik
        {
            get { return _etik; }
            set { _etik = value; }
        }

        public PregledEtiketa()
        {
            Etik = new ObservableCollection<Etiketa>();
            ucitajEtikete();

            this.DataContext = this;
            InitializeComponent();
        }

        public void ucitajEtikete()
        {
            foreach (Etiketa et in MainWindow.instanca.Etikete)
            {
                Etik.Add(et);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Etiketa et = null;
            if (tableEtiketa.SelectedItem is Etiketa)
            {
                et = (Etiketa)tableEtiketa.SelectedValue;
                EditEtiketa edit = new EditEtiketa(et.Id, this);
                edit.Show();

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = null;
            if (tableEtiketa.SelectedItem is Etiketa)
            {
                et = (Etiketa)tableEtiketa.SelectedValue;
                MainWindow.instanca.Etikete.Remove(et);
                Etik.Remove(et);
            }
            else
            {
            }
        }

        public void refresh()
        {
            Etik = null;
            Etik = new ObservableCollection<Etiketa>();
            this.ucitajEtikete();
            tableEtiketa.Items.Refresh();
            tableEtiketa.UpdateLayout();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textbox = sender as TextBox;
            string filter = textbox.Text;
            System.ComponentModel.ICollectionView cv = CollectionViewSource.GetDefaultView(_etik);
            if (filter == "")
                cv.Filter = null;
            else
            {
                string[] words = filter.Split(' ');
                if (words.Contains(""))
                    words = words.Where(word => word != "").ToArray();
                cv.Filter = o =>
                {
                    Etiketa etiketa = o as Etiketa;
                    return words.Any(word => etiketa.Sss.ToUpper().Contains(word.ToUpper()));
                };

                tableEtiketa.ItemsSource = _etik;
            }
        }
    }
}
