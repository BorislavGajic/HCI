using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp1
{
    public class SaveLoad
    {
        private string pathEtiketa = null;
        private string pathResursa = null;
        private string pathTipova = null;
        public SaveLoad()
        {

            pathEtiketa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "etikete.txt");
            pathResursa = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resursi.txt");
            pathTipova = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tipovi.txt");

            ucitajTipove();
            ucitajEtikete();
            ucitajResurse();
        }

        public void save()
        {

            using (StreamWriter writer = File.CreateText(pathEtiketa))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, MainWindow.instanca.Etikete);
                writer.Close();
            }

            using (StreamWriter writer = File.CreateText(pathResursa))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, MainWindow.instanca.Resursi);
                writer.Close();
            }


            using (StreamWriter writer = File.CreateText(pathTipova))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, MainWindow.instanca.Tipovi);
                writer.Close();
            }


        }

        public void ucitajResurse()
        {


            if (File.Exists(pathResursa))
            {

                using (StreamReader reader = File.OpenText(pathResursa))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    MainWindow.instanca.Resursi = (Dictionary<string, KlasaPolja>)serializer.Deserialize(reader, typeof(Dictionary<string, KlasaPolja>));
                }

            }
            else
            {
                MainWindow.instanca.Resursi = new Dictionary<string, KlasaPolja>();
            }



        }

        public void ucitajTipove()
        {
            if (File.Exists(pathTipova))
            {

                using (StreamReader reader = File.OpenText(pathTipova))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    MainWindow.instanca.Tipovi = (List<Tip>)serializer.Deserialize(reader, typeof(List<Tip>));
                }
            }
            else
            {
                MainWindow.instanca.Tipovi = new List<Tip>();
            }


        }

        public void ucitajEtikete()
        {

            if (File.Exists(pathEtiketa))
            {

                using (StreamReader reader = File.OpenText(pathEtiketa))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    MainWindow.instanca.Etikete = (List<Etiketa>)serializer.Deserialize(reader, typeof(List<Etiketa>));
                }
            }
            else
            {
                MainWindow.instanca.Etikete = new List<Etiketa>();
            }


        }
    }
}
