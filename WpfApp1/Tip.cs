using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp1
{
    public class Tip
    {

        private int _id;
        private string _ime;
        private string _opis;
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

        private string slika;

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

        public Tip(string id, string ime, string opis, string slika)
        {
            this.Id = id;
            this.Ime = ime;
            this.Opis = opis;
            this._slika = slika;
        }

    }
}
