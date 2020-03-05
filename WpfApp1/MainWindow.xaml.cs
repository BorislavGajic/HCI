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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Log;

namespace WpfApp1
{
    
    public partial class MainWindow : Window


       
    {
        private Dictionary<string, KlasaPolja> _resursi;
        public static MainWindow instanca;
        private string[] _freqPojavljivanjaa = { "Redak", "Cest", "Univerzalan" };
        private string[] _jedinicaMere = { "Merica", "Barel", "kg" , "Tona" };
        private List<Tip> _tipovi;
        private List<Etiketa> _etikete;
        private SaveLoad _saveLoadFile;

        private string korisnik;
        private BazaPodataka baza;



        private Point _startPoint = new Point();
        private Point _panelStartPoint = new Point();
        private TreeViewItem _treeViewItem;
        private Vector _vec;
        private string _imeSelektovanog;
        Point panelMousePos;
        private List<Image> imgList;
        private ToolTip tt;

        private bool pom = false;
        private int imgIndex;

       

        #region GetSet
        public string ImeSelektovanog
        {
            get
            {
                if (_imeSelektovanog != null)
                    return "Ime: " + _imeSelektovanog;
                else
                    return "";
            }
        }
        public string OpisSelektovanog
        {
            get
            {
                if (_imeSelektovanog != null)
                    return "Opis: " + Resursi[_imeSelektovanog].Opis;
                else
                    return "";
            }
        }

        public List<Tip> Tipovi
        {
            get
            {
                return _tipovi;
            }
            set
            {
                _tipovi = value;
            }
        }

        public SaveLoad SaveLoadFile
        {
            get
            {
                return _saveLoadFile;
            }
        }

        public List<Etiketa> Etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                _etikete = value;
            }
        }

        public string Korinik
        {
            private set
            {
                korisnik = value;
            }
            get
            {
                return korisnik;
            }
        }
        #endregion


        public MainWindow(string k)

             
        {
            this.korisnik = k;

            //etikete = new ObservableCollection<Etiketa>();
            //tip = new Tip();
           // m = new Manifestacija();
            baza = new BazaPodataka(korisnik);

            instanca = this;
            _saveLoadFile = new SaveLoad();
            imgList = new List<Image>();
            InitializeComponent();
            this.DataContext = this;
            Stablo.ItemsSource = Resursi;
            loadImgMap();

           /* System.Windows.Forms.MessageBoxManager.OK = "U redu";
            System.Windows.Forms.MessageBoxManager.Yes = "Da";
            System.Windows.Forms.MessageBoxManager.No = "Ne";
            System.Windows.Forms.MessageBoxManager.Cancel = "Odustani";*/

           // System.Windows.Forms.MessageBoxManager.Register();

        }

        #region GetSet2
        public Dictionary<string, KlasaPolja> Resursi
        {
            get
            {
                return _resursi;
            }
            set
            {
                _resursi = value;
            }
        }

        public string[] FreqPojavljivanjaa
        {
            get
            {
                return _freqPojavljivanjaa;
            }
        }

        public string[] JedinicaMeree
        {
            get
            {
                return _jedinicaMere;
            }
        }

        public void addResurs(KlasaPolja kp)
        {
            Resursi.Add(kp.Ime, kp); 
        }

        public void addTip(Tip tp)
        {
            _tipovi.Add(tp);
        }

        public void addEtiketa(Etiketa et)
        {
            _etikete.Add(et);
        }

        #endregion



        public void refresh()
        {
            Stablo.Items.Refresh();
            Stablo.UpdateLayout();
        }
        private void TreeViewItem_OnItemSelected(object sender, RoutedEventArgs e)
        {
            //Stablo.Tag = e.OriginalSource;
            TreeViewItem tvi = e.OriginalSource as TreeViewItem;
            _treeViewItem = tvi;
            string str = tvi.Header.ToString();
            string[] str2 = str.Split(',');
            _imeSelektovanog = str2[0].TrimStart('[');

            if (_imeSelektovanog != null)
            {
                
            }
        }





        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Dijalozi.DodajKorisnikaTool dkt = new Dijalozi.DodajKorisnikaTool();
            dkt.ShowDialog();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Dijalozi.PregledResursaTool dt = new Dijalozi.PregledResursaTool();
            dt.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Da li zelite da obrisete " + _imeSelektovanog + "?", "Obrisi spomenik", MessageBoxButton.YesNo))
            {

                case MessageBoxResult.Yes:
                    Resursi.Remove(_imeSelektovanog);
                    foreach (Image img in imgList)
                    {
                        if (img.Name == _imeSelektovanog)
                        {
                            imgPanel.Children.Remove(img);
                        }
                    }
                    this.refresh();
                    break;
                case MessageBoxResult.No:
                    return;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            Dijalozi.Edit dEd = new Dijalozi.Edit(_imeSelektovanog);
            dEd.ShowDialog();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            _saveLoadFile.save();
            //this.Hide();
            e.Cancel = false;
        }

        private void Stablo_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem SelectedItem = Stablo.SelectedItem as TreeViewItem;

            Stablo.ContextMenu = Stablo.Resources["SpomenikContext"] as System.Windows.Controls.ContextMenu;

        }

        #region DragAndDrop

        private void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }
        private void TreeView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint - mousePos;

            
            

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                // Find the data behind the ListViewItem
                KlasaPolja spomenik = _resursi[_imeSelektovanog];
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", spomenik);
                DragDrop.DoDragDrop(_treeViewItem, dragData, DragDropEffects.Move);
            }
        }

        private void Panel_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Panel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Point p = e.GetPosition(this.imgPanel);
                KlasaPolja res = e.Data.GetData("myFormat") as KlasaPolja;
                foreach (Image image in imgList)
                {
                    if (image.Name.Equals(res.Ime))
                    {
                        System.Windows.MessageBox.Show("Spomenik vec postoji na mapi!");
                        return;
                    }
                        
                }

                Image img = new Image();
                BitmapImage bitImage = new BitmapImage(new Uri(res.Slika, UriKind.Absolute));
                img.Source = bitImage;
                try
                {
                    img.Name = res.Ime;
                } catch (Exception)
                {
                    System.Windows.MessageBox.Show("Ime resursa ne moze poceti brojem jer biblioteka slike to ne dozvoljava!");
                }
                
                img.Width = 32;
                img.Height = 32;

                res.Position = new Point(p.X, p.Y);

                WrapPanel wp = new WrapPanel();
                wp.Orientation = Orientation.Vertical;

                TextBox Id = new TextBox();
                Id.IsEnabled = false;
                Id.Text = "Id: " + res.Id;
                wp.Children.Add(Id);

                TextBox naziv = new TextBox();
                naziv.IsEnabled = false;
                naziv.Text = "Ime: " + res.Ime;
                wp.Children.Add(naziv);


                TextBox tip = new TextBox();
                tip.IsEnabled = false;
                tip.Text = "Tip: " + res.Tip;
                wp.Children.Add(tip);

                tt = new ToolTip();
                tt.Content = wp;
                img.ToolTip = tt;
                img.MouseMove += Panel_MouseMove;

                imgList.Add(img);
                imgPanel.Children.Add(img);
                Canvas.SetLeft(img, p.X - 16);
                Canvas.SetTop(img, p.Y - 16);
            }
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            panelMousePos = e.GetPosition(imgPanel);
            _vec = panelMousePos - _panelStartPoint;
        }
        private void Panel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _panelStartPoint = e.GetPosition(imgPanel);

            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 1)
            {

                foreach (KlasaPolja kp in _resursi.Values)
                {
                    if (_panelStartPoint.X < kp.Position.X + 16 && _panelStartPoint.X > kp.Position.X - 16 && _panelStartPoint.Y < kp.Position.Y + 16 && _panelStartPoint.Y > kp.Position.Y - 16)
                    {
                        _imeSelektovanog = kp.Ime;
                        pom = true;
                        for (imgIndex = 0; imgIndex < imgList.Count(); imgIndex++)
                        {
                            Image img = imgList[imgIndex];
                            if (img.Name.Equals(_imeSelektovanog))
                            {
                                imgPanel.Children.Remove(img);
                                break;
                            }
                        }

                        break;
                    }
                }
            }

            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {

                foreach (KlasaPolja kp in _resursi.Values)
                {
                    if (_panelStartPoint.X < kp.Position.X + 16 && _panelStartPoint.X > kp.Position.X - 16 && _panelStartPoint.Y < kp.Position.Y + 16 && _panelStartPoint.Y > kp.Position.Y - 16)
                    {
                        Dijalozi.Edit edit = new Dijalozi.Edit(kp.Ime);
                        edit.Show();
                        break;
                    }
                }
            }
        }

        private void Panel_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _panelStartPoint = e.GetPosition(imgPanel);
            foreach (KlasaPolja kp in _resursi.Values)
            {
                if (_panelStartPoint.X < kp.Position.X + 16 && _panelStartPoint.X > kp.Position.X - 16 && _panelStartPoint.Y < kp.Position.Y + 16 && _panelStartPoint.Y > kp.Position.Y - 16)
                {
                    _imeSelektovanog = kp.Ime;
                    ContextMenu cm = new ContextMenu();

                    MenuItem item1 = new MenuItem();
                    item1.Header = "Ukloni";
                    item1.Click += MenuItem_Click_3;
                    MenuItem item2 = new MenuItem();
                    item2.Header = "Izmeni spomenik";
                    item2.Click += Button_Click_1;
                    MenuItem item3 = new MenuItem();
                    item3.Header = "Obrisi spomenik";
                    item3.Click += MenuItem_Click_1;
                    cm.Items.Add(item1);
                    cm.Items.Add(item2);
                    cm.Items.Add(item3);

                    //cm.Items.Add(new MenuItem("Obrisi spomenik", MenuItem_Click_1));
                    imgPanel.ContextMenu = cm;
                    e.Handled = true;
                    break;
                }
                else
                {
                    imgPanel.ContextMenu = null;
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Da li zelite da obrisete " + _imeSelektovanog + "?", "Obrisi spomenik", MessageBoxButton.YesNo))
            {

                case MessageBoxResult.Yes:
                    Resursi.Remove(_imeSelektovanog);
                    foreach (Image img in imgList)
                    {
                        if (img.Name.Equals(_imeSelektovanog))
                        {
                            imgPanel.Children.Remove(img);
                            imgList.Remove(img);
                            break;
                        }
                    }
                    this.refresh();
                    break;
                case MessageBoxResult.No:
                    return;
                    break;
            }

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            foreach (Image img in imgList)
            {
                if (img.Name == _imeSelektovanog)
                {
                    imgPanel.Children.Remove(img);
                    imgList.Remove(img);
                    break;
                }
            }
        }

        private void ImgPanel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(imgPanel);
            if (pom)
            {
                foreach (KlasaPolja kp in _resursi.Values)
                {
                    if (((pos.X > (kp.Position.X - 16) && (pos.X < (kp.Position.X))) || (pos.X < (kp.Position.X + 16) && (pos.X > (kp.Position.X)))) &&
                        ((pos.Y > (kp.Position.Y - 16) && (pos.Y < (kp.Position.Y))) || (pos.Y < (kp.Position.Y + 16) && (pos.Y > (kp.Position.Y)))))
                    {
                        KlasaPolja res = _resursi[_imeSelektovanog];
                        imgPanel.Children.Add(imgList[imgIndex]);
                        Canvas.SetLeft(imgList[imgIndex], res.Position.X - 16);
                        Canvas.SetTop(imgList[imgIndex], res.Position.Y - 16);
                        pom = false;
                        return;
                    }
                }

                
                Image img = imgList[imgIndex];
                imgPanel.Children.Add(img);
                Canvas.SetLeft(img, pos.X - 16);
                Canvas.SetTop(img, pos.Y - 16);
                pom = false;
                _resursi[_imeSelektovanog].Position = pos;
            }
        }
        #endregion

        public void loadImgMap()
        {
            foreach (KlasaPolja kp in _resursi.Values)
            {
                if (kp.Position != null)
                {
                    Image img = new Image();
                    img.Source = new BitmapImage(new Uri(kp.Slika, UriKind.Absolute));
                    img.Name = kp.Ime;
                    img.Width = 32;
                    img.Height = 32;

                    WrapPanel wp = new WrapPanel();
                    wp.Orientation = Orientation.Vertical;

                    TextBox Id = new TextBox();
                    Id.IsEnabled = false;
                    Id.Text = "Id: " + kp.Id;
                    wp.Children.Add(Id);

                    TextBox naziv = new TextBox();
                    naziv.IsEnabled = false;
                    naziv.Text = "Ime: " + kp.Ime;
                    wp.Children.Add(naziv);


                    TextBox tip = new TextBox();
                    tip.IsEnabled = false;
                    tip.Text = "Tip: " + kp.Tip;
                    wp.Children.Add(tip);

                    ToolTip tt = new ToolTip();
                    tt.Content = wp;
                    img.ToolTip = tt;
                    img.MouseMove += Panel_MouseMove;

                    imgList.Add(img);
                    imgPanel.Children.Add(img);
                    Canvas.SetLeft(img, kp.Position.X - 16);
                    Canvas.SetTop(img, kp.Position.Y - 16);
                }
               
            }
        }

        private void DraggedImageMouseMove(object sender, MouseEventArgs e)
        {
            /*System.Windows.Point mousePos = e.GetPosition(null);
            Vector diff = _panelStartPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
               (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
               Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {


                KlasaPolja selektovana = (KlasaPolja)Stablo.SelectedValue;

                if (selektovana != null)
                {
                    Image img = sender as Image;
                    imgPanel.Children.Remove(img);
                    DataObject dragData = new DataObject("myFormat", selektovana);
                    DragDrop.DoDragDrop(img, dragData, DragDropEffects.Move);

                }

            }*/

        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Help.ShowHelp(null, @"./../../HCI_help.chm");

            /* FrameworkElement source = e.Source as FrameworkElement;

             if (source != null)

             {

                 string helpString = Help.HelpProvider.GetHelpString(source);

                 if (helpString != null)

                 {

                     System.Windows.Forms.Help.ShowHelp(null, @"HCI_help.chm", System.Windows.Forms.HelpNavigator.KeywordIndex, helpString);


                 }

             } */
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _saveLoadFile.save();
            Visibility = Visibility.Collapsed;
            
            Login log = new Login();
            log.ShowDialog();
        }
    }
}
