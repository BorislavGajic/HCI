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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
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
            private get { return lozinka; }
            set
            {
                if (lozinka != value)
                {
                    lozinka = value;
                    OnPropertyChanged("Lozinka");
                }
            }
        }

        #endregion

        public Login()
        {
            baza = new BazaPodataka(5);
            this.DataContext = this;
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void prijava_Click(object sender, RoutedEventArgs e)
        {
            bool nePostoji = false;
            korisnici = baza.Korisnici;
            foreach (Korisnik k in korisnici)
            {
                if (k.KorisnickoIme.Equals(korisnickoIme))
                {
                    if (k.Lozinka.Equals(lozinka))
                    {
                        var s = new MainWindow(korisnickoIme);
                        s.Show();
                        this.Close();
                        nePostoji = true;

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Pogrešna lozinka!", "Greška!");
                        nePostoji = true;
                    }
                }
            }
            if (nePostoji == false)
            {
                System.Windows.MessageBox.Show("Nepostojeće korisničko ime! ", "Greška!");
            }
        }

        private void registracija_Click(object sender, RoutedEventArgs e)
        {
            var s = new Registracija();

            this.Close();
            s.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, @"./../../HCI_help.chm");
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Lozinka = passwordBox.Password;
        }
    }
}
