using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Etiketa
    {
        private int _id;
        private System.Drawing.Color _boja;
        private string _opis;
        private string sss;

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

        public string Sss
        {
            get
            {
                return sss;
            }
            set
            {
                sss = value;
            }
        }
        public System.Drawing.Color Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                _boja = value;
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
        #endregion

        public Etiketa(string Id, string Boja, string Opis)
        {
            this.Id = Id;
            this.sss = Boja;
            this.Opis = Opis;
        }
    }
}
