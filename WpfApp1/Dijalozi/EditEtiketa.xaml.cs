using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1.Dijalozi
{
    /// <summary>
    /// Interaction logic for EditEtiketa.xaml
    /// </summary>
    public partial class EditEtiketa : Window
    {
        Etiketa et;
        PregledEtiketa preg_et;

        #region GetSet
        public string Id
        {
            get
            {
                return et.Id;
            }
            set
            {
                et.Id = value;
            }
        }

        public System.Drawing.Color Boja
        {
            get
            {
                return et.Boja;
            }
            set
            {

                et.Boja = value;

            }
        }

        public string Opis
        {
            get
            {
                return et.Opis;
            }
            set
            {
                if (value != et.Opis)
                {
                    et.Opis = value;
                    OnPropertyChanged("Opis");
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

        public EditEtiketa(string Id, PregledEtiketa preg_et)
        {
            this.preg_et = preg_et;
            
            foreach (Etiketa etiketa in MainWindow.instanca.Etikete)
            {
                if (etiketa.Id.Equals(Id))
                    et = etiketa;
            }
            InitializeComponent();
            cmbColors.ItemsSource = typeof(Colors).GetProperties();

            

            this.DataContext = this;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BindingExpression bindingId = OznakaBox.GetBindingExpression(TextBox.TextProperty);
            bindingId.UpdateSource();
            BindingExpression bindingOpis = OpisBox.GetBindingExpression(TextBox.TextProperty);
            bindingOpis.UpdateSource();

            

            preg_et.refresh();

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

        private void cmbColors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Media.Color selectedColor = (System.Windows.Media.Color)(cmbColors.SelectedItem as PropertyInfo).GetValue(null, null);
            et.Boja = System.Drawing.Color.FromArgb(selectedColor.A, selectedColor.R, selectedColor.G, selectedColor.B);
            et.Sss = cmbColors.SelectedItem.ToString();

            string[] s1 = et.Sss.Split(' ');
            et.Sss = s1[1];
            
        }
    }
}
