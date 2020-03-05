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
using Microsoft.Win32;

namespace WpfApp1.Dijalozi
{
    /// <summary>
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private KlasaPolja kp;
        private string naziv;
        


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

        #region GetSet
        public string Id
        {
            get
            {
                if (kp == null)
                {
                    return "0";
                }
                return kp.Id;
            }
            set
            {
                kp.Id = value;
            }
        }

        public string Ime
        {
            get
            {
                return kp.Ime;
            }
            set
            {
                kp.Ime = value;
            }

        }
        public string Opis
        {
            get
            {
                return kp.Opis;
            }
            set
            {

                kp.Opis = value;
            }

        }

        public string Cena
        {
            get
            {
                if (kp == null)
                {
                    return "0";
                }
                return kp.Cena;
            }
            set
            {
                kp.Cena = value;
            }
        }

        public bool R4
        {
            get
            {
                return kp.Obnovljiv;
            }
            set
            {
                kp.Obnovljiv = value;
            }
        }
        public bool R5
        {
            get
            {
                return !kp.Obnovljiv;
            }
            set
            {
                kp.Obnovljiv = !value;
            }
        }

        public bool R6
        {
            get
            {
                return kp.StrateskaVaznost;
            }
            set
            {
                kp.StrateskaVaznost = value;
            }
        }
        public bool R7
        {
            get
            {
                return !kp.StrateskaVaznost;
            }
            set
            {
                kp.StrateskaVaznost = !value;
            }
        }

        public bool R8
        {
            get
            {
                return kp.Eksploatacija;
            }
            set
            {
                kp.Eksploatacija = value;
            }
        }
        public bool R9
        {
            get
            {
                return !kp.Eksploatacija;
            }
            set
            {
                kp.Eksploatacija = !value;
            }
        }

        public string Slika
        {
            get
            {
                return kp.Slika;
            }
            set
            {
                kp.Slika = value;
            }
        }

        


        #endregion

        public Edit()
        {
            comboFill();
            InitializeComponent();
            this.DataContext = this;
        }

        public Edit(string naziv)
        {
           
            this.naziv = naziv;
            InitializeComponent();
            kp = MainWindow.instanca.Resursi[naziv];
            comboFill();
            //Ikonica.Source = sp.Image;
            this.DataContext = this;
        }

        public void comboFill()
        {

            FreqPojavljivanja = new ObservableCollection<string>();
            for (int i = 0; i < MainWindow.instanca.FreqPojavljivanjaa.Length; i++)
            {
                FreqPojavljivanja.Add(MainWindow.instanca.FreqPojavljivanjaa[i]);
            }
            FreqBox.SelectedValue = kp.FreqPojavljivanja;

            JedinicaMere = new ObservableCollection<string>();
            for (int i = 0; i < MainWindow.instanca.JedinicaMeree.Length; i++)
            {
                JedinicaMere.Add(MainWindow.instanca.JedinicaMeree[i]);
            }
            JediBox.SelectedValue = kp.JedinicaMere;
            datumPicker.SelectedDate = kp.Datum;

            Tip = new ObservableCollection<string>();
            foreach (Tip tp in MainWindow.instanca.Tipovi)
            {
                Tip.Add(tp.Ime);
            }
            TipBox.SelectedValue = kp.Tip;

            Etiketa = new ObservableCollection<string>();
            foreach (Etiketa et in MainWindow.instanca.Etikete)
            {
                Etiketa.Add(et.Sss);
            }
            Etiketa_box.SelectedValue = kp.Etiketa;

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
                BitmapImage img = new BitmapImage(new Uri(op.FileName));
                Ikonica.Source = img;
                kp.Slika = op.FileName;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            BindingExpression bindingId = txtId.GetBindingExpression(TextBox.TextProperty);
            bindingId.UpdateSource();
            BindingExpression bindingIme = txtIme.GetBindingExpression(TextBox.TextProperty);
            bindingIme.UpdateSource();
            BindingExpression bindingOpis = txtOpis.GetBindingExpression(TextBox.TextProperty);
            bindingOpis.UpdateSource();

            if (!valid())
            {
                return;
            }

            kp.FreqPojavljivanja = FreqBox.SelectionBoxItem.ToString();
            kp.JedinicaMere = JediBox.SelectionBoxItem.ToString();
            kp.Tip = TipBox.SelectionBoxItem.ToString();
            kp.Etiketa = Etiketa_box.SelectionBoxItem.ToString();

            MainWindow.instanca.Resursi.Remove(naziv);
            MainWindow.instanca.Resursi.Add(kp.Ime, kp);
            MainWindow.instanca.refresh();
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
            if (Id == null || Id.Equals("0") || Id.Equals(""))
            {
                lblGreska.Content = "Oznaka mora biti unet!";
                return false;
            }
            if (Opis == null || Opis.Equals(""))
            {
                lblGreska.Content = "Opis mora biti unet!";
                return false;
            }
            
            if (Ime == null || Ime.Equals(""))
            {
                lblGreska.Content = "Ime mora biti uneto!";
                return false;
            }

            if (Cena == null || Cena.Equals("") || Cena.Equals("0"))
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
