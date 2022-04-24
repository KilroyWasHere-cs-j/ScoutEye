using System;
using System.IO;
using System.Windows.Forms;

namespace ScoutEye
{
    public class Logger
    {
        private StreamReader reader;
        private StreamWriter writer;
        private string path = "Log.txt";

        public Logger()
        {
            Log("ScoutEye Started");
        }


        public void Log(string log)
        {
            try
            {
                reader = new StreamReader(path);
                string fileContent = reader.ReadToEnd();
                reader.Close();
                writer = new StreamWriter(path);
                writer.Write(fileContent);
                writer.Write(DateTime.Now + ">>" + log + "\n");
                writer.Flush();
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}