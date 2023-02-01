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
        private XmlDocument xml;
        private OpenFileDialog fdlg;
        public Configurer()
        {
            InitializeComponent();
            fdlg = new OpenFileDialog();
            xml = new XmlDocument();
            fdlg.Title = "ScoutEye Configurer";
            fdlg.InitialDirectory = Directory.GetCurrentDirectory();
            fdlg.Filter = "XML Files (*.xml*)|*.xml*|All files (*.xml*)|*.xml*"; //Only allow xml files to be shown, which is the file used for configuration
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
        }

        private bool isTrue(string s)
        {
            return s.Contains("false");
        }

        #region EventHandlers
        private void LoadConfigFileBTN_Click(object sender, RoutedEventArgs e)
        {
            // Promt user to select path to settings
            fdlg.ShowDialog();
            string filePath = fdlg.FileName;
            // Update UI
            SelectedFilePathLB.Content = filePath;
            // Get all the nodes in the settings document
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                xml.Load(filePath);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/settings");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                //Maybe add an iterator
                try
                {
                    foreach (XmlNode node in nodeList)
                    {
                        VersionTB.Content = node.SelectSingleNode("AppVersion").InnerText;
                        A0labelTB.Text = node.SelectSingleNode("Auto0").InnerText;
                        A0contentsTB.Text = node.SelectSingleNode("Auto0Items").InnerText;
                        A0VisableRB.IsChecked = isTrue(node.SelectSingleNode("Auto0Hide").InnerText);

                        A1labelTB.Text = node.SelectSingleNode("Auto1").InnerText;
                        A1contentsTB.Text = node.SelectSingleNode("Auto1Items").InnerText;
                        A1VisableRB.IsChecked = isTrue(node.SelectSingleNode("Auto1Hide").InnerText);

                        A2labelTB.Text = node.SelectSingleNode("Auto2").InnerText;
                        A2contentsTB.Text = node.SelectSingleNode("Auto2Items").InnerText;
                        A2VisableRB.IsChecked = isTrue(node.SelectSingleNode("Auto2Hide").InnerText);

                        A3labelTB.Text = node.SelectSingleNode("Auto3").InnerText;
                        A3contentsTB.Text = node.SelectSingleNode("Auto3Items").InnerText;
                        A3VisableRB.IsChecked = isTrue(node.SelectSingleNode("Auto3Hide").InnerText);

                        T0labelTB.Text = node.SelectSingleNode("Teleop0").InnerText;
                        T0contentsTB.Text = node.SelectSingleNode("Teleop0Items").InnerText;
                        T0VisableRB.IsChecked = isTrue(node.SelectSingleNode("Teleop0Hide").InnerText);

                        T1labelTB.Text = node.SelectSingleNode("Teleop1").InnerText;
                        T1contentsTB.Text = node.SelectSingleNode("Teleop1Items").InnerText;
                        T1VisableRB.IsChecked = isTrue(node.SelectSingleNode("Teleop1Hide").InnerText);


                        T2labelTB.Text = node.SelectSingleNode("Teleop2").InnerText;
                        T2contentsTB.Text = node.SelectSingleNode("Teleop2Items").InnerText;
                        T2VisableRB.IsChecked = isTrue(node.SelectSingleNode("Teleop2Hide").InnerText);

                        T3labelTB.Text = node.SelectSingleNode("Teleop3").InnerText;
                        T3contentsTB.Text = node.SelectSingleNode("Teleop3Items").InnerText;
                        T3VisableRB.IsChecked = isTrue(node.SelectSingleNode("Teleop3Hide").InnerText);
                    }
                }
                catch
                {
                    MessageBox.Show($"{filePath} could not be opened", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception w)
            {
                MessageBox.Show(w.Message.ToString());
            }
        }
        #endregion
    }
}
