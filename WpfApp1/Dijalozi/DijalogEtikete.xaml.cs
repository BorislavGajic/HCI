using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1.Dijalozi
{
    /// <summary>
    /// Interaction logic for DijalogEtikete.xaml
    /// </summary>
    public partial class DijalogEtikete : Window
    {
        private string _id;
        private System.Drawing.Color boja;
        private string _opis;
        public string sss;

        #region GetSet
        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public System.Drawing.Color Boja
        {
            get
            {
                return boja;
            }
            set
            {

                boja = value;

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

        public DijalogEtikete()
        {
            InitializeComponent();
            cmbColors.ItemsSource = typeof(Colors).GetProperties();
            this.DataContext = this;

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (!valid())
            {
                return;
            }

            MainWindow.instanca.addEtiketa(new Etiketa(_id, sss, _opis));
            
            this.Close();
        }

        private void cmbColors_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            System.Windows.Media.Color selectedColor = (System.Windows.Media.Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            boja = System.Drawing.Color.FromArgb(selectedColor.A, selectedColor.R, selectedColor.G, selectedColor.B);
             sss = cmbColors.SelectedItem.ToString();
            
            string[] s1 = sss.Split(' ');
            sss = s1[1];
            

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
            if (Opis == null || Opis.Equals("") )
            {
                System.Windows.MessageBox.Show("Opis mora biti unet!");
                return false;
            }
            if (sss == null || sss.Equals(""))
            {
                System.Windows.MessageBox.Show("Morate izabrati boju!");
                return false;
            }

            return true;
        }
        #endregion
    }
}
