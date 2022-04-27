using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            reader = new StreamReader(cvsPath);
            string fileContent = reader.ReadToEnd();
            MessageBox.Show(fileContent);
            reader.Close();
            writer = new StreamWriter(cvsPath);
            writer.Write(fileContent);
            writer.Write("\n");
            writer.Write(data);
            writer.Flush();
            writer.Close();
        }
    }
}
