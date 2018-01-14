using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

using System.Xml;

using System.Xml.Serialization;



namespace Laboratorium4

{

    class Program

    {

        static void Main(string[] args)

        {

           



                osobaAdres adres = new osobaAdres();

                adres.miejscowosc = "Gdañsk;

                adres.ulica = "Radarowa";

                adres.nrDomu = "161";

                adres.nrLokalu = "-";



                osoba os = new osoba();

                os.imie = "Mateusz";

                os.nazwisko = "Malek";

                os.pesel = 123456789101;

                os.adresy = new osobaAdres[1] { adres };



                Serializacja(os);

            SerializacjaXML(os);

            Deserializacja();

            

        }



         static void Serializacja(osoba os)

            {

                Stream StrumienPliku = File.Create("serializacja");

                BinaryFormatter serializer = new BinaryFormatter();

                serializer.Serialize(StrumienPliku, os);

                StrumienPliku.Close();

            }



        static void SerializacjaXML(osoba os)

        {

            Stream StrumienPliku = File.Create("serializacjaXML");

            XmlSerializer serializer = new XmlSerializer(typeof(osoba));

            serializer.Serialize(StrumienPliku, os);

            StrumienPliku.Close();

        }



        static void Deserializacja()

        {

            Stream StrumienPliku = File.Open("SerializacjaXML", FileMode.Open);

            XmlReader reader = XmlReader.Create(StrumienPliku);

            XmlSerializer serializer = new XmlSerializer(typeof(osoba));

            osoba o;

            o = (osoba)serializer.Deserialize(reader);

            StrumienPliku.Close();

        }



    }

}

