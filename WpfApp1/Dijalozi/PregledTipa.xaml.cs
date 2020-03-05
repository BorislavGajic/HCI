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
    /// Interaction logic for PregledTipa.xaml
    /// </summary>
    public partial class PregledTipa : Window
    {
        private ObservableCollection<Tip> _tip;

        public ObservableCollection<Tip> Tip
        {
            get { return _tip; }
            set { _tip = value; }
        }

        public PregledTipa()
        {
            Tip = new ObservableCollection<Tip>();
            ucitajTipove();

            this.DataContext = this;
            InitializeComponent();
        }

        public void ucitajTipove()
        {
            foreach (Tip tp in MainWindow.instanca.Tipovi)
            {
                Tip.Add(tp);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tip tp = null;
            if (tableTip.SelectedItem is Tip)
            {
                tp = (Tip)tableTip.SelectedValue;
                MainWindow.instanca.Tipovi.Remove(tp);
                Tip.Remove(tp);
            }
            else
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Tip tp = null;
            if (tableTip.SelectedItem is Tip)
            {
                tp = (Tip)tableTip.SelectedValue;
                EditTip edit = new EditTip(tp.Ime, this);
                edit.Show();

            }
        }

        public void refresh()
        {
            Tip = null;
            Tip = new ObservableCollection<Tip>();
            this.ucitajTipove();
            tableTip.Items.Refresh();
            tableTip.UpdateLayout();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Windows.Controls.TextBox textbox = sender as System.Windows.Controls.TextBox;
            string filter = textbox.Text;
            System.ComponentModel.ICollectionView cv = CollectionViewSource.GetDefaultView(_tip);
            if (filter == "")
                cv.Filter = null;
            else
            {
                string[] words = filter.Split(' ');
                if (words.Contains(""))
                    words = words.Where(word => word != "").ToArray();
                cv.Filter = o =>
                {
                    Tip tip = o as Tip;
                    return words.Any(word => tip.Id.ToUpper().Contains(word.ToUpper()));
                };
                tableTip.ItemsSource = _tip;
            }
        }
    }
}
