using System; 
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml;
using QRCoder;

namespace ScoutingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private QRCodeGenerator generator;
        private Logger logger;
        private XmlDocument xml;
        private Stopwatch stopwatch;
        private Thread stopwatchThread = new Thread(UpdateUIStopwatch);
        private bool isStopWatchRunning = false;
        private int matchNumber = 0;
        private int teamNumber = 5687;
        private string teamName = "The Outliers";

        public MainWindow()
        {
            InitializeComponent();
            generator = new QRCodeGenerator();
            logger = new Logger();
            xml = new XmlDocument();
            stopwatch = new Stopwatch();
#pragma warning disable CS8622 //It's a stupid warning anyways
            Application.Current.MainWindow.Closing += new CancelEventHandler(MainWindow_Closing);
#pragma warning restore CS8622
            stopwatchThread.Start();
            LoadUIFromSettings();
        }
        
        //<summary>
        //Generate a QR Code from an input string
        //<summary>
        private void GenerateQRCode(string data)
        {
            try
            {
                QRCodeData qRCodeData = generator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qRCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);
                CodeDisplay.Source = BitmapToImageSource(qrCodeImage);
                logger.Log("QRCode generated");
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Failed to generate QR Code. Failed with this error: \n" + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);  
            }
        }

        //<summary>
        //Steps into the next match
        //<summary>
        private void NextMatch()
        {
            matchNumber++;
            MatchNumberLB.Content = "Match Number: " + matchNumber.ToString();
            ResetMatch();
        }

        //<summary>
        //Enter match data
        //<summary>
        private void EnterMatch()
        {
            //Ask the user if they really want to enter the match
            MessageBoxResult result = MessageBox.Show("Are you sure you want enter this match?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                //Make sure that the user really did enter the match data completely
                if(Auto0.Text != String.Empty && Auto1.Text != String.Empty && Auto2.Text != String.Empty && Teleop0.Text != String.Empty && Teleop1.Text != String.Empty && Teleop2.Text != String.Empty)
                {
                    //Create a QR Code with all the important data
                    GenerateQRCode(matchNumber.ToString() + "," + teamNumber.ToString() + "," + teamName + "," + Auto0.Text + "," + Auto1.Text + "," + Auto2.Text + "," + Teleop0.Text + "," + Teleop1.Text + "," + Teleop2.Text);
                    NextMatch();
                }
                else
                {
                    MessageBox.Show("Match data is not complete.", "Match enter error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //<summary>
        //Reset match data
        //<summary>
        private void ResetMatch()
        {
            TeamNumberTB.Text = String.Empty;
            TeamNameTB.Text = String.Empty;
            Auto0.Text = String.Empty;
            Auto1.Text = String.Empty;
            Auto2.Text = String.Empty;
            Teleop0.Text = String.Empty;
            Teleop1.Text = String.Empty;
            Teleop2.Text = String.Empty;
            logger.Log("Match Data Cleared");
        }

        private static void UpdateUIStopwatch(object? obj)
        {
            throw new NotImplementedException();
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
                    VersionNumberLB.Content = node.SelectSingleNode("AppVersion").InnerText;
                    Auto0LB.Content = node.SelectSingleNode("Auto0").InnerText;
                    Auto1LB.Content = node.SelectSingleNode("Auto1").InnerText;
                    Auto2LB.Content = node.SelectSingleNode("Auto2").InnerText;
                    Teleop0LB.Content = node.SelectSingleNode("Teleop0").InnerText;
                    Teleop1LB.Content = node.SelectSingleNode("Teleop1").InnerText;
                    Teleop2LB.Content = node.SelectSingleNode("Teleop2").InnerText;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                logger.Log("App loaded from settings");
            }
            catch (Exception ex)
            {
                logger.Log("Could not load settings. " + ex.Message);
                MessageBox.Show("Could not load settings. Failed with exception. " + ex.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }

        #region EventHandlers
        //<summary>
        //Ask the user if they really want to exit the app
        //<summary>
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question);
            e.Cancel = (result == MessageBoxResult.No);
        }

        //<summary>
        //When the enter button is pressed enter match data
        //Also check with user to insure that they really do want to enter and it wasn not an accident

        //<summary>
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            EnterMatch();
        }

        //<summary>
        //When the reset button is pressed reset all entered match data
        //Also check with user to insure that they really do want to reset and it wasn not an accident
        //<summary>
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reset match data? This action cannot be undone.", "Did you make a mistake?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ResetMatch();
            }
        }

        //<summary>
        //Toggles the stopwatch on and off
        //<summary>
        private void ToggleWatch_Click(object sender, RoutedEventArgs e)
        {
            switch (isStopWatchRunning)
            {
                case true:
                    stopwatch.Stop();
                    isStopWatchRunning = false;
                    break;
                case false:
                    stopwatch.Restart();
                    isStopWatchRunning = true;
                    break;
            }
        }
        
        //For debugging, auto fills in all nessary data
        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            ScoutNameTB.Text = "Gabe";
            TeamNameTB.Text = "Good team name";
            TeamNumberTB.Text = "296";
            Auto0.Text = "10";
            Auto1.Text = "0";
            Auto2.Text = "0";
            Teleop0.Text = "40";
            Teleop1.Text = "0";
            Teleop2.Text = "Traversal";
        }
        #endregion
    }
}