using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for DijalogKorisnika.xaml
    /// </summary>
    public partial class DijalogKorisnika : Window , INotifyPropertyChanged
    {
        public ObservableCollection<string> FreqPojavljivanja
        {
            get;
            set;
        }

        public ObservableCollection<string> JedinicaMere
        {
            get;
            set;
        }

        public ObservableCollection<string> Tip
        {
            get;
            set;
        }

        public ObservableCollection<string> Etiketa
        {
            get;
            set;
        }

        #region NotifyProperties

        private int _id;
        private string _ime;
        private string _opis;
        private string _tip;
        private string _etiketa;
        private string _freqPojavljivanja;
        private bool _obnovljiv =false;
        private bool _strateskaVaznost =false;
        private bool _eksploatacija =false;
        private string _jedinicaMere;
        private int _cena;
        private DateTime _datum;
        private string _porukaGreske;


        private string _slika;

        public string Id
        {
            get
            {
                return _id.ToString();
            }
            set
            {
                if (value == "")
                {
                    _porukaGreske = "Id je obavezno polje!";
                }
                else if (int.Parse(value) != _id)
                {
                    _id = int.Parse(value);
                    _porukaGreske = "";
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

        public string Cena
        {
            get
            {
                return _cena.ToString();
            }
            set
            {
                if (value == "") { }
                else if (int.Parse(value) != _cena)
                {
                    _cena = int.Parse(value);
                    OnPropertyChanged("Cena");
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

        public DateTime Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                _datum = value;
            }
        }

        public string PorukaGreske
        {
            get
            {
                return _porukaGreske;
            }
            set
            {
                _porukaGreske = value;
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

        public DijalogKorisnika()
        {
            this.comboFill();
            InitializeComponent();
            this.DataContext = this;


        }

        public void comboFill()
        {

            FreqPojavljivanja = new ObservableCollection<string>();
            for (int i = 0; i < MainWindow.instanca.FreqPojavljivanjaa.Length; i++)
            {
                FreqPojavljivanja.Add(MainWindow.instanca.FreqPojavljivanjaa[i]);
            }

            JedinicaMere = new ObservableCollection<string>();
            for (int i = 0; i < MainWindow.instanca.JedinicaMeree.Length; i++)
            {
                JedinicaMere.Add(MainWindow.instanca.JedinicaMeree[i]);
            }

            Tip = new ObservableCollection<string>();
            foreach (Tip tip in MainWindow.instanca.Tipovi)
            {
                Tip.Add(tip.Ime);
            }

            Etiketa = new ObservableCollection<string>();
            foreach (Etiketa et in MainWindow.instanca.Etikete)
            {
                Etiketa.Add(et.Sss);
            }

        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Ikonica.Source = new BitmapImage(new Uri(op.FileName));
                _slika = op.FileName;
                //Ikonica.Source = _image;
                // sp.Image = img;
            }
        }

       

        private void R4_Checked(object sender, RoutedEventArgs e)
        {
            if (r4.IsChecked ?? false)
            {
                _obnovljiv = true;
            }
        }

        private void R5_Checked(object sender, RoutedEventArgs e)
        {
            if (r5.IsChecked ?? false)
            {
                _obnovljiv=false;
            }
        }

        private void R6_Checked(object sender, RoutedEventArgs e)
        {
            if (r6.IsChecked ?? false)
            {
                _strateskaVaznost = true;
            }
        }

        private void R7_Checked(object sender, RoutedEventArgs e)
        {
            if (r7.IsChecked ?? false)
            {
                _strateskaVaznost = false;
            }
        }

        private void R8_Checked(object sender, RoutedEventArgs e)
        {
            if (r8.IsChecked ?? false)
            {
                _eksploatacija = true;
            }
        }

        private void R9_Checked(object sender, RoutedEventArgs e)
        {
            if (r9.IsChecked ?? false)
            {
                _eksploatacija = false;
            }
        }

        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (!valid())
            {
                return;
            }


            _freqPojavljivanja = FreqBox.SelectionBoxItem.ToString();
            _jedinicaMere = JediBox.SelectionBoxItem.ToString();
            _etiketa = Etiketa_box.SelectionBoxItem.ToString();
            _tip = TipBox.SelectionBoxItem.ToString();
            if (datumPicker.SelectedDate != null)
                _datum = (DateTime)datumPicker.SelectedDate;
            

            MainWindow.instanca.addResurs(new KlasaPolja(_id, Ime, Opis,_freqPojavljivanja,_obnovljiv,_strateskaVaznost,_eksploatacija,_jedinicaMere,_cena, _datum , _slika, _tip,_etiketa));
            MainWindow.instanca.refresh();

           

            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }


        #region validacija
        private void NumericOnly(System.Object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool num = IsTextNumeric(e.Text);
            if (!num)
            {
                _porukaGreske = "Id mora biti u numerickom formatu!";
            }
            else
            {
                _porukaGreske = "";
            }
            e.Handled = num;

        }



        private bool IsTextNumeric(string str)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("[^0-9]");
            return reg.IsMatch(str);

        }

        private bool valid()
        {
            if (Id == null || Id.Equals("0") || Id.Equals(""))
            {
                lblGreska.Content = "Oznaka mora biti unet!";
                return false;
            }
            if (Ime == null || Ime.Equals(""))
            {
                lblGreska.Content = "Ime mora biti uneto!";
                return false;
            }
            if (Opis == null || Ime.Equals(""))
            {
                lblGreska.Content = "Opis mora biti unet!";
                return false;
            }
            if (Cena == null || Ime.Equals("0") || Cena.Equals(""))
            {
                lblGreska.Content = "Cena mora biti uneta!";
                return false;
            }
            if (TipBox.SelectionBoxItem.ToString() == "")
            {
                lblGreska.Content = "Morate uneti tip spomenika!";
                return false;
            }

            if (Etiketa_box.SelectionBoxItem.ToString() == "")
            {
                lblGreska.Content = "Morate uneti etiketu spomenika!";
                return false;
            }

            if (JediBox.SelectionBoxItem.ToString() == "")
            {
                lblGreska.Content = "Morate uneti jedinicu!";
                return false;
            }
            if (FreqBox.SelectionBoxItem.ToString() == "")
            {
                lblGreska.Content = "Morate uneti frekvenciju pojavljivanja!";
                return false;
            }
            if (datumPicker.SelectedDate == null)
            {
                lblGreska.Content = "Morate uneti datum!";
                return false;
            }

            if (Slika == null)
            {
                lblGreska.Content = "Morate uneti sliku!";
                return false;
            }

            

            return true;
        }
        #endregion
    }

}
