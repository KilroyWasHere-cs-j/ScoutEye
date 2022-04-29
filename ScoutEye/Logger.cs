using System;
using System.IO;
using System.Text;
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
            //Write to log file
            //Try catch is to prevent us from writing to the log file when it's already open
            try
            {
                string fileContent = File.ReadAllText(path, Encoding.UTF8);
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