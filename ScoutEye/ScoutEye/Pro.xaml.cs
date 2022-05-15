using QRCoder;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for Pro.xaml
    /// </summary>
    public partial class Pro : Window
    {
        private XmlDocument xml;
        private string comboDefault = "Please Select Option";
        private int matchNumber = 0;
        private DispatcherTimer dt;
        private Stopwatch stopwatch;
        private bool stopwatchEnabled = false;
        private int clickCount = 0;

        public Pro(string scoutname, int currentMatchNumber)
        {
            InitializeComponent();
            xml = new XmlDocument();
            stopwatch = new Stopwatch();
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt.Start();
            LoadUIFromSettings();
            ScoutNameLB.Content = "Scout Name: " + scoutname;
            //Set the current match number so the scout can start at anypoint
            matchNumber = currentMatchNumber;
            MatchNumTB.Content = "Match Number: " + matchNumber.ToString();
        }

        //<summary>
        //Enter match
        //<summary>
        private void EnterMatch()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to enter this match? This action cannot be undone.", "Just checking in.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                string compiledData = Auto0.Text + "\t" + Auto1.Text + "\t" + Auto2.Text + "\t" + Auto3.Text + "\t" + Teleop0.Text + "\t" + Teleop1.Text + "\t" + Teleop2.Text + "\t" + Teleop3.Text + "\t" + RobotDiedCB.IsChecked.ToString() + "\t" + FieldFaultCB.IsChecked.ToString() + "\t" + stopwatch.Elapsed.ToString() + "\t" + clickCount.ToString();
                QRCodeDisplayPB.Source = BitmapToImageSource(GenerateQRCode(compiledData));
                NextMatch();
            }
        }

        //<summary>
        //Moves to the next match
        //<summary>
        private void NextMatch()
        {
            matchNumber++;
            MatchNumTB.Content = "Match number: " + matchNumber.ToString();
            ResetMatch();
        }

        //<summary>
        //Resets all the match data
        //<summary>
        private void ResetMatch()
        {
            foreach (UIElement element in Grid.Children)
            {
                if (element is ComboBox)
                {
                    ComboBox cb = (ComboBox)element;
                    cb.SelectedIndex = 0;
                }
                if(element is CheckBox)
                {
                    CheckBox cb = (CheckBox)element;
                    cb.IsChecked = false;
                }
            }
        }

        //<summary>
        //Generate a QR Code from a bit of text
        //<summary>
        private Bitmap GenerateQRCode(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            return qrCodeImage;
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
            int[] values = Enumerable.Range(0, 500 - 0).ToArray();
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                xml.Load("Settings.xml");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/settings");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                //Sets every combo box on the screen to say Empty
                foreach (UIElement element in Grid.Children)
                {
                    if (element is ComboBox)
                    {
                        ComboBox cb = (ComboBox)element;
                        cb.Items.Add(comboDefault);
                        cb.SelectedIndex = 0;
                    }
                }

                foreach (XmlNode node in nodeList)
                {
                    VersionLB.Content = node.SelectSingleNode("AppVersion").InnerText;
                    Auto0LB.Content = node.SelectSingleNode("Auto0").InnerText;
                    Auto1LB.Content = node.SelectSingleNode("Auto1").InnerText;
                    Auto2LB.Content = node.SelectSingleNode("Auto2").InnerText;
                    Auto3LB.Content = node.SelectSingleNode("Auto3").InnerText;
                    Teleop0LB.Content = node.SelectSingleNode("Teleop0").InnerText;
                    Teleop1LB.Content = node.SelectSingleNode("Teleop1").InnerText;
                    Teleop2LB.Content = node.SelectSingleNode("Teleop2").InnerText;
                    Teleop3LB.Content = node.SelectSingleNode("Teleop3").InnerText;

                    //Fill all drop down menus and decide if they get shown or stay hidden
                    foreach (string item in node.SelectSingleNode("Auto0Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Auto0Hide").InnerText == "true")
                        {
                            Auto0.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Auto0.IsEditable = true;
                                    Auto0.Items.Add(num);
                                }
                            }
                            else
                            {
                                Auto0.IsEditable = false;
                                Auto0.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Auto1Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Auto1Hide").InnerText == "true")
                        {
                            Auto1.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Auto1.IsEditable = true;
                                    Auto1.Items.Add(num);
                                }
                            }
                            else
                            {
                                Auto1.IsEditable = false;
                                Auto1.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Auto2Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Auto2Hide").InnerText == "true")
                        {
                            Auto2.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Auto2.IsEditable = true;
                                    Auto2.Items.Add(num);
                                }
                            }
                            else
                            {
                                Auto2.IsEditable = false;
                                Auto2.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Auto3Items").InnerText.Split(',').ToList())
                    {
                        if (node.SelectSingleNode("Auto3Hide").InnerText == "true")
                        {
                            Auto3.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Auto3.IsEditable = true;
                                    Auto3.Items.Add(num);
                                }
                            }
                            else
                            {
                                Auto3.IsEditable = false;
                                Auto3.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Teleop0Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Teleop0Hide").InnerText == "true")
                        {
                            Teleop0.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Teleop0.IsEditable = true;
                                    Teleop0.Items.Add(num);
                                }
                            }
                            else
                            {
                                Teleop0.IsEditable = false;
                                Teleop0.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Teleop1Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Teleop1Hide").InnerText == "true")
                        {
                            Teleop1.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Teleop1.IsEditable = true;
                                    Teleop1.Items.Add(num);
                                }
                            }
                            else
                            {
                                Teleop1.IsEditable = false;
                                Teleop1.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Teleop2Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Teleop2Hide").InnerText == "true")
                        {
                            Teleop2.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Teleop2.IsEditable = true;
                                    Teleop2.Items.Add(num);
                                }
                            }
                            else
                            {
                                Teleop2.IsEditable = false;
                                Teleop2.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Teleop3Items").InnerText.Split(',').ToList())
                    {
                        if(node.SelectSingleNode("Teleop3Hide").InnerText == "true")
                        {
                            Teleop3.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Teleop3.IsEditable = true;
                                    Teleop3.Items.Add(num);
                                }
                            }
                            else
                            {
                                Teleop3.IsEditable = false;
                                Teleop3.Items.Add(item);
                            }
                        }
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
            }
            catch (Exception ex)
            {
               // logger.Log("Could not load settings. " + ex.Message);
                MessageBox.Show("Could not load settings. Failed with exception. " + ex.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }

        #region EventHandlers
        private void dt_Tick(object sender, EventArgs e)
        {
            StopwatchLB.Content = "Stopwatch: " + stopwatch.Elapsed.TotalMilliseconds.ToString() + "ms";
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            EnterMatch();
        }

        private void ResetBTN_Click(object sender, RoutedEventArgs e)
        {
            ResetMatch();
        }

        //<summary>
        //Toggle the stopwatch on and off
        //<summary>
        private void ToggleStopwatch_Click(object sender, RoutedEventArgs e)
        {
            switch (stopwatchEnabled)
            {
                case true:
                    stopwatchEnabled = false;
                    stopwatch.Stop();
                    break;
                case false:
                    stopwatchEnabled = true;
                    stopwatch.Start();
                    break;
            }
        }

        //<summary>
        //Reset Stopwatch
        //<summary>
        private void ResetStopwatch_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            stopwatch.Reset();
        }
        
        //<summary>
        //Click counter up
        //<summary>
        private void ClickCounterDown_Click(object sender, RoutedEventArgs e)
        {
            clickCount--;
            ClickCounterCountLB.Content = "Click count " + clickCount.ToString();
        }

        //<summary>
        //Click counter down
        //<summary>
        private void ClickCounterUp_Click(object sender, RoutedEventArgs e)
        {
            clickCount++;
            ClickCounterCountLB.Content = "Click count " + clickCount.ToString();
        }
        #endregion
    }
}