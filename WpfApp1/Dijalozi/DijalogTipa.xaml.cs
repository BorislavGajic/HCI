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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp1.Dijalozi
{
    /// <summary>
    /// Interaction logic for Tip.xaml
    /// </summary>
    /// 
   
    public partial class DijalogTipa : Window
    {
        private Tip tip;
        private string _ime;
        private string _opis;
        private int _id;
        private string _slika;

        #region GetSet
        public string Id
        {
            get
            {
                return _id.ToString();
            }
            set
            {
                if (value == "") { }
                else if (int.Parse(value) != _id)
                {
                    _id = int.Parse(value);
                    OnPropertyChanged("Id");
                }
            }
        }
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public string Slika
        {
            get
            {
                return _slika;
            }
            set
            {
                _slika = value;
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

        public DijalogTipa()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(op.FileName));
                _slika = op.FileName;
            }
        }

        

        


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!valid())
            {
                return;
            }

            tip = new Tip(Id, Ime, Opis, Slika);
            MainWindow.instanca.addTip(tip);
            
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

        private bool valid()
        {
            if (Id == null || Id.Equals("0"))
            {
                System.Windows.MessageBox.Show("Id mora biti unet!");
                return false;
            }
            if (Ime == null || Ime.Equals(""))
            {
                System.Windows.MessageBox.Show("Ime mora biti uneto!");
                return false;
            }
            if (Opis == null || Opis.Equals(""))
            {
                System.Windows.MessageBox.Show("Opis mora biti unet!");
                return false;
            }

            if (Slika == null)
            {
                System.Windows.MessageBox.Show("Slika mora biti uneta!");
                return false;
            }

            return true;
        }
        #endregion
    }

}

