using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for Configurer.xaml
    /// </summary>
    public partial class Configurer : Window
    {
        private XmlTextReader xmlReader;
        private OpenFileDialog fdlg;
        public Configurer()
        {
            InitializeComponent();
            fdlg = new OpenFileDialog();
            fdlg.Title = "ScoutEye Configurer";
            fdlg.InitialDirectory = Directory.GetCurrentDirectory();
            fdlg.Filter = "XML Files (*.xml*)|*.xml*|All files (*.xml*)|*.xml*"; //Only allow xml files to be shown, which is the file used for configuration
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
        }

        #region EventHandlers
        private void LoadConfigFileBTN_Click(object sender, RoutedEventArgs e)
        {
            fdlg.ShowDialog();
            string filePath = fdlg.FileName;
            xmlReader = new XmlTextReader(filePath);
            SelectedFilePathLB.Content = filePath;
            xmlReader.Read();

            A0labelTB.Text = xmlReader.Value.ToString();
        }
        #endregion
    }
}
