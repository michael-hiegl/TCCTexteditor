using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TCCTexteditor
{
    class Filewriter
    {
        //Instazvariable
        private string _DateiPfad; //Pfad + Name + Endung

        //Konstruktoren
        /// <summary>
        /// Standardkonstruktor der Klasse
        /// </summary>
        public Filewriter()
        {

        }

        /// <summary>
        /// Konstruktor der Klasse
        /// </summary>
        /// <param name="DateiName">Name der zu erstellenden Datei</param>
        public Filewriter(string DateiName)
        {
            this._DateiPfad = Environment.CurrentDirectory + "\\" + DateiName + ".txt";
        }

        /// <summary>
        /// Konstruktor der Klasse
        /// </summary>
        /// <param name="DateiName">Name der zu erstellenden Datei</param>
        /// <param name="DateiEndung">Dateiendung bspw. *.txt</param>
        public Filewriter(string DateiName, string DateiEndung)
        {
            this._DateiPfad = Environment.CurrentDirectory + "\\" + DateiName + DateiEndung;
        }

        /// <summary>
        /// Konstruktor der Klasse
        /// </summary>
        /// <param name="DateiPfad">Komplette Pfadangabe bspw. c:\\users\\vogl\\Desktop</param>
        /// <param name="DateiName">Name der zu erstellenden Datei</param>
        /// <param name="DateiEndung">Dateiendung bspw. *.txt</param>
        public Filewriter(string DateiPfad, string DateiName, string DateiEndung)
        {
            this._DateiPfad = DateiPfad + DateiName + DateiEndung;
        }

        /// <summary>
        /// Eigenschaft beinhaltet den kompletten Pfad inkl. Dateiname und Dateiendung
        /// </summary>
        public string DateiPfad
        {
            set { _DateiPfad = value; }
            get { return _DateiPfad; }
        }


        /// <summary>
        /// Methode zum Schreiben von Daten in eine Datei
        /// </summary>
        /// <param name="Data">Datenstring mit den Daten die in ein File geschrieben werden sollen</param>
        /// <returns>Fehlernachricht</returns>
        public string WriteDataFile(string Data)
        {
            try
            {               
                StreamWriter MyFileWriter = File.CreateText(DateiPfad);
                Data = Data.Replace("\n", "\r\n"); //ersetzt \n durch \r+\n
                MyFileWriter.Write(Data);
                MyFileWriter.Close();

                return "no Error";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Methode zum lesen einer Datei
        /// </summary>
        /// <returns>Datenstring der gelesenen Datei bzw. Fehlermeldung</returns>
        public string ReadDataFile()
        {
            string ReadData = null;

            if (File.Exists(DateiPfad))
            {
                try
                {
                    StreamReader MyStreamReader = new StreamReader(DateiPfad);
                    ReadData = MyStreamReader.ReadToEnd();
                    MyStreamReader.Close();
                    return ReadData;
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                return "Datei existiert nicht";
            }
        }


        /// <summary>
        /// Methode um Daten an eine bestehende Textdatei anzuhängen
        /// </summary>
        /// <param name="Data">Datenstring mit den Daten die in ein File geschrieben werden sollen</param>
        /// <returns>Fehlernachricht</returns>
        public string AppendData(string Data)
        {
            try
            {
                StreamWriter MyFileWriter = new StreamWriter(DateiPfad,true);
                Data = Data.Replace("\n", "\r\n"); //ersetzt \n durch \r+\n
                MyFileWriter.Write(Data);
                MyFileWriter.Close();

                return "no Error";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Löscht eine bestehende Datei
        /// </summary>
        /// <returns>Fehlernachricht</returns>
        public string DeleteDataFile()
        {
            if (File.Exists(DateiPfad)) //Überprüft ob eine Datei existiert
            {
                try
                {
                    File.Delete(DateiPfad);                  
                    return "Detei wurde gelöscht";
                }

                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else 
            {
                return "Detei existiert nicht";
            }

        }



    }
}
