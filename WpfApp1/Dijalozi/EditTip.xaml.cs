using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Win32;

namespace WpfApp1.Dijalozi
{
    /// <summary>
    /// Interaction logic for EditTip.xaml
    /// </summary>
    public partial class EditTip : Window
    {
        Tip tp;
        PregledTipa preg_tp;

        #region GetSet
        public string Id
        {
            get
            {
                return tp.Id;
            }
            set
            {
                tp.Id = value;
            }
        }
        public string Ime
        {
            get
            {
                return tp.Ime;
            }
            set
            {
                if (value != tp.Ime)
                {
                    tp.Ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public string Opis
        {
            get
            {
                return tp.Opis;
            }
            set
            {
                if (value != tp.Opis)
                {
                    tp.Opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        public string Slika
        {
            get { return tp.Slika; }
            set
            {
                if (value != tp.Slika)
                {
                    tp.Slika = value;
                    OnPropertyChanged("Slika");
                }
            }
        }
        #endregion

        #region PropertyChangedNotifier

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public EditTip(string naziv, PregledTipa preg_tp)
        {
            this.preg_tp = preg_tp;
            
            foreach (Tip tip in MainWindow.instanca.Tipovi)
            {
                if (tip.Ime.Equals(naziv))
                
                    tp = tip;
                    
                
            }
            InitializeComponent();
            if (Slika != null)
            {
                Ikonica.Source = new BitmapImage(new Uri(tp.Slika));
            }
            this.DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BindingExpression bindingId = txtId.GetBindingExpression(TextBox.TextProperty);
            bindingId.UpdateSource();
            BindingExpression bindingIme = txtIme.GetBindingExpression(TextBox.TextProperty);
            bindingIme.UpdateSource();
            BindingExpression bindingOpis = txtOpis.GetBindingExpression(TextBox.TextProperty);
            bindingOpis.UpdateSource();

            preg_tp.refresh();

            this.Close();
        }

        #region validacija
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool num = IsTextNumeric(e.Text);
            e.Handled = num;

        }



        private bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                BitmapImage img = new BitmapImage(new Uri(op.FileName));
                Ikonica.Source = img;
                Slika = op.FileName;

            }
        }
    }
}
