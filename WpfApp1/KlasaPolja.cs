using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
//using System.Windows.Media.Imaging;

namespace WpfApp1
{
     public class KlasaPolja
    {
        

        private int _id;
        private string _ime;
        private string _opis;
        private string _tip;
        private string _etiketa;
        private string _freqPojavljivanja;
        private bool _obnovljiv;
        private bool _strateskaVaznost;
        private bool _eksploatacija;
        private string _jedinicaMere;
        private int _cena;
        private DateTime _datum;

        private string _slika;

        private Point _position;

        // odradi sve za public

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
                _ime = value;
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
                _opis = value;
            }

        }

        

        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                _tip = value;
            }

        }

        public string Etiketa
        {
            get
            {
                return _etiketa;
            }
            set
            {
                _etiketa = value;
            }

        }

        public string FreqPojavljivanja
        {
            get
            {
                return _freqPojavljivanja;
            }
            set
            {
                _freqPojavljivanja = value;
            }

        }

        public string JedinicaMere
        {
            get
            {
                return _jedinicaMere;
            }
            set
            {
                _jedinicaMere = value;
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

        public bool Obnovljiv
        {
            get
            {
                return _obnovljiv;
            }
            set
            {
                this._obnovljiv = value;
            }
        }

        public bool StrateskaVaznost
        {
            get
            {
                return _strateskaVaznost;
            }
            set
            {
                this._strateskaVaznost = value;
            }
        }

        public bool Eksploatacija
        {
            get
            {
                return _eksploatacija;
            }
            set
            {
                this._eksploatacija = value;
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

        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }



        #endregion

        #region Konsturktori

        public KlasaPolja()
        {
            this._id = 000000;
            this._ime = null;
            this._opis = null;
            this._obnovljiv = false;
            this._strateskaVaznost = false;
            this._eksploatacija = false;
        }

        public KlasaPolja(int id,string ime,string opis, string freq, bool obnov, bool stratV, bool eksploat, string jedMere, int cena, DateTime datum , string slika ,string tip ,string etiketa )
        {
            this._id = id;
            this._ime = ime;
            this._opis = opis;
            this._freqPojavljivanja = freq;
            this._obnovljiv = obnov;
            this._strateskaVaznost = stratV;
            this._eksploatacija = eksploat;
            this._jedinicaMere = jedMere;
            this._cena = cena;
            this._datum = datum;
            this._slika = slika;
            this._tip = tip;
            this._etiketa = etiketa;
        }

        #endregion

    }
}
