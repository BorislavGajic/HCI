using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1.Log
{

    public class BazaPodataka
    {
        private ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>();
        private ObservableCollection<KlasaPolja> klasapolja = new ObservableCollection<KlasaPolja>();
        private ObservableCollection<Tip> tipovi = new ObservableCollection<Tip>();
        private ObservableCollection<Etiketa> etikete = new ObservableCollection<Etiketa>();

        private string pathKorisnika = null;
        private string pathEtiketa = null;
        private string pathResurs = null;
        private string pathTipova = null;
       

        private string korisnik = null;

        public BazaPodataka(int k)
        {
            pathKorisnika = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "korisnici.txt");
            ucitajKorisnike();
        }

        public BazaPodataka(string k)
        {
            korisnik = k;
            pathKorisnika = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "korisnici.txt");
            pathEtiketa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k + "etikete.txt");
            pathResurs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k + "resursi.txt");
            pathTipova = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, k + "tipovi.txt");

            ucitajEtikete();
            ucitajResurse();
            ucitajTipove();

            ucitajKorisnike();

            sacuvajResurs();


        }

        public void ucitajKorisnike()
        {
            if (File.Exists(pathKorisnika))
            {

                using (StreamReader reader = File.OpenText(pathKorisnika))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    korisnici = (ObservableCollection<Korisnik>)serializer.Deserialize(reader, typeof(ObservableCollection<Korisnik>));
                }
            }
            else
            {
                korisnici = new ObservableCollection<Korisnik>();
            }


        }

        public void sacuvajKorisnike()
        {
            using (StreamWriter writer = File.CreateText(pathKorisnika))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, korisnici);
                writer.Close();
            }


        }

        public ObservableCollection<Korisnik> Korisnici
        {
            get { return korisnici; }
            set { korisnici = value; }
        }

        public void ucitajEtikete()
        {

            if (File.Exists(pathEtiketa))
            {

                using (StreamReader reader = File.OpenText(pathEtiketa))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    etikete = (ObservableCollection<Etiketa>)serializer.Deserialize(reader, typeof(ObservableCollection<Etiketa>));
                }
            }
            else
            {
                etikete = new ObservableCollection<Etiketa>();
            }


        }


        public void ucitajResurse()
        {


            if (File.Exists(pathResurs))
            {

                using (StreamReader reader = File.OpenText(pathResurs))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    klasapolja = (ObservableCollection<KlasaPolja>)serializer.Deserialize(reader, typeof(ObservableCollection<KlasaPolja>));
                }

            }
            else
            {
                klasapolja = new ObservableCollection<KlasaPolja>();
            }



        }


        public void ucitajTipove()
        {
            if (File.Exists(pathTipova))
            {

                using (StreamReader reader = File.OpenText(pathTipova))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    tipovi = (ObservableCollection<Tip>)serializer.Deserialize(reader, typeof(ObservableCollection<Tip>));
                }
            }
            else
            {
                tipovi = new ObservableCollection<Tip>();
            }


        }

        public void save()
        {

            using (StreamWriter writer = File.CreateText(pathEtiketa))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, etikete);
                writer.Close();
            }

            using (StreamWriter writer = File.CreateText(pathResurs))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, klasapolja);
                writer.Close();
            }


            using (StreamWriter writer = File.CreateText(pathTipova))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, tipovi);
                writer.Close();
            }


        }


        public void sacuvajResurs()
        {
            using (StreamWriter writer = File.CreateText(pathResurs))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, klasapolja);
                writer.Close();
            }


        }



        public void sacuvajEtiketu()
        {
            using (StreamWriter writer = File.CreateText(pathEtiketa))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, etikete);
                writer.Close();
            }


        }



        public void sacuvajTip()
        {
            using (StreamWriter writer = File.CreateText(pathTipova))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, tipovi);
                writer.Close();
            }


        }



        public bool novResurs(KlasaPolja kp)
        {
            foreach (KlasaPolja m1 in klasapolja)
            {
                if (m1.Id == kp.Id)
                {

                    return false;
                }
            }
            klasapolja.Add(kp);
            sacuvajResurs();

            return true;
        }


        public bool novaEtiketa(Etiketa e)
        {
            foreach (Etiketa e1 in etikete)
            {
                if (e1.Id == e.Id)
                {

                    return false;
                }
            }
            etikete.Add(e);
            sacuvajEtiketu();
            return true;

        }

        public bool novTip(Tip t)
        {

            foreach (Tip t1 in tipovi)
            {
                if (t1.Id == t.Id)
                {

                    return false;
                }
            }
            tipovi.Add(t);
            sacuvajTip();
            return true;

        }

        public bool brisanjeResursa(KlasaPolja m)
        {

            foreach (KlasaPolja l1 in klasapolja)
            {
                if (l1.Id == m.Id)
                {
                    klasapolja.Remove(m);
                    sacuvajResurs();

                    return true;
                }
            }

            return false;
        }



        public bool brisanjeEtikete(Etiketa e)
        {

            foreach (Etiketa e1 in etikete)
            {
                if (e1.Id == e.Id)
                {
                    etikete.Remove(e);
                    sacuvajEtiketu();
                    return true;
                }
            }

            return false;
        }


        public bool brisanjeTipa(Tip t)
        {

            foreach (Tip t1 in tipovi)
            {
                if (t1.Id == t.Id)
                {
                    tipovi.Remove(t);
                    sacuvajTip();
                    return true;
                }
            }

            return false;
        }
        

        public ObservableCollection<KlasaPolja> Resursi
        {
            get { return klasapolja; }
            set { klasapolja = value; }
        }

        public ObservableCollection<Tip> Tipovi
        {
            get { return tipovi; }
            set { tipovi = value; }
        }

        public ObservableCollection<Etiketa> Etikete
        {

            get { return etikete; }
            set { etikete = value; }
        }
    }


}
