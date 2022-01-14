using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

namespace ZiekmeldingSysteem.Classes
{
    public static class FileHandler<T>
    {
        #region JSON
        public static void SaveToJSON(T toSave, string filePath)
        {
            Console.WriteLine("Saving File...");

            try
            {
                string jsonstring = JsonConvert.SerializeObject(toSave);
                File.WriteAllText(filePath, jsonstring);

                Console.WriteLine("File saved succesfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File could not be saved!\n" + ex);
            }

        }

        public static T LoadFromJSON(string filePath)
        {
            Console.WriteLine("Loading File...");

            string json = null;

            try
            {
                json = File.ReadAllText(filePath);
                Console.WriteLine("File loaded succesfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("File could not be loaded!\n" + ex);
            }

            return JsonConvert.DeserializeObject<T>(json);
        }
        #endregion JSON

        #region XML
        public static void SaveToXml(T toSave, string filePath)
        {
            XmlSerializer writer = new XmlSerializer(typeof(T));
            FileStream file = File.Create(filePath);

            try
            {
                writer.Serialize(file, toSave);
            }
            catch (Exception ex)
            {
                Console.WriteLine("XML Save Error: " + ex);
                throw;
            }
            finally
            {
                file.Close();
            }
        }

        public static T ReadFromXml(string filePath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(T));
                StreamReader file = new StreamReader(filePath);

                return (T)reader.Deserialize(file);
            }
            catch (Exception ex)
            {
                Console.WriteLine("XML Read Error: " + ex);

                return default(T);
            }
        }
        #endregion XML
    }
}
