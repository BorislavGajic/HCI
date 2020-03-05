using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfApp1.Log
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        private string korisnickoIme;
        private string lozinka;
        private string lozinka2;
        private BazaPodataka baza;
        private ObservableCollection<Korisnik> korisnici;

        #region GetSet
        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                if (korisnickoIme != value)
                {
                    korisnickoIme = value;
                    OnPropertyChanged("korisnickoIme");
                }
            }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                if (lozinka != value)
                {
                    lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }

        public string Lozinka2
        {
            get { return lozinka2; }
            set
            {
                if (lozinka2 != value)
                {
                    lozinka2 = value;
                    OnPropertyChanged("Lozinka2");
                }
            }
        }
        #endregion

        public Registracija()
        {
            baza = new BazaPodataka(5);
            korisnici = baza.Korisnici;
            InitializeComponent();
            this.DataContext = this;
        }

        private void sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            bool postoji = false;
            foreach (Korisnik k in korisnici)
            {
                if (k.KorisnickoIme.Equals(korisnickoIme))
                {
                    postoji = true;
                    break;
                }
            }
            if (postoji == false)
            {
                if (korisnickoImeBox.Text.Equals("") || passwordBox.Text.Equals("") || passwordBox2.Text.Equals(""))
                {
                    System.Windows.MessageBox.Show("Niste popunili neophodna polja!", "Greška!");
                }
                else if (!passwordBox.Text.Equals(passwordBox2.Text))
                {
                    System.Windows.MessageBox.Show("Lozinke nisu iste!", "Greška!");

                }
                else
                {
                    Korisnik novi = new Korisnik(KorisnickoIme, lozinka);
                    baza.Korisnici.Add(novi);
                    baza.sacuvajKorisnike();

                    var s = new Login();
                    this.Close();
                    s.ShowDialog();


                }
            }
            else
            {
                System.Windows.MessageBox.Show("Uneto korisničko ime već postoji!", "Greška!");

            }
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            var s = new Login();
            this.Close();
            s.ShowDialog();
        }

        private void passwordBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordBox_Copy_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, @"./../../HCI_help.chm");
        }
    }
}
