using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for Pro.xaml
    /// </summary>
    public partial class Pro : Window
    {
        private XmlDocument xml;
        public Pro()
        {
            InitializeComponent();
            xml = new XmlDocument();
            LoadUIFromSettings();
        }

        //<summary>
        //Convert bitmap image to a image source so that the image box will show it
        //<summary>
        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        //<summary>
        //Load app settings from a xml file
        //<summary>
        private void LoadUIFromSettings()
        {
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                xml.Load("Settings.xml");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/settings");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                foreach (XmlNode node in nodeList)
                {
                    VersionLB.Content = node.SelectSingleNode("AppVersion").InnerText;
                    Auto0LB.Content = node.SelectSingleNode("Auto0").InnerText;
                    Auto1LB.Content = node.SelectSingleNode("Auto1").InnerText;
                    Auto2LB.Content = node.SelectSingleNode("Auto2").InnerText;
                    Teleop0LB.Content = node.SelectSingleNode("Teleop0").InnerText;
                    Teleop1LB.Content = node.SelectSingleNode("Teleop1").InnerText;
                    Teleop2LB.Content = node.SelectSingleNode("Teleop2").InnerText;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                //logger.Log("App loaded from settings");
            }
            catch (Exception ex)
            {
               // logger.Log("Could not load settings. " + ex.Message);
                MessageBox.Show("Could not load settings. Failed with exception. " + ex.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }

        #region EventHandlers
        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ResetBTN_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
