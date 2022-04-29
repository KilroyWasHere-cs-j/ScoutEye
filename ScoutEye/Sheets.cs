using System;
using System.IO;
using System.Windows.Forms;

namespace ScoutEye
{
    public class Sheets
    {
        private StreamReader reader;
        private StreamWriter writer;
        private string cvsPath = "Data.csv";

        public Sheets()
        {

        }

        public void StoreData(string data)
        {
            //Write to data output log
            //Try catch is to handle writeing to the data output file whilst it's already open
            try
            {
                reader = new StreamReader(cvsPath);
                string fileContent = reader.ReadToEnd();
                //MessageBox.Show(fileContent);
                reader.Close();
                writer = new StreamWriter(cvsPath);
                writer.Write(fileContent);
                writer.Write("\n");
                writer.Write(data);
                writer.Flush();
                writer.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
