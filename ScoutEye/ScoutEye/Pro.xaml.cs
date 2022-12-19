using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using QRCoder;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for Pro.xaml
    /// </summary>
    public partial class Pro : Window
    {
        private XmlDocument xml; 
        private DispatcherTimer dt;
        private Stopwatch stopwatch;
        private SoundPlayer player;
        private bool stopwatchEnabled = false;
        private int clickCount = 0, matchNumber = 0;
        private string name = "", scoutingLevel = "Pro", comboDefault = "Please Select Option";

        public Pro(string scoutname)
        {
            InitializeComponent();
            xml = new XmlDocument();
            stopwatch = new Stopwatch();
            dt = new DispatcherTimer();
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dt.Start();
            LoadUIFromSettings();
            name = scoutname;
            ScoutNameLB.Content = "Scout Name: " + name;
            //Set the current match number so the scout can start at anypoint
            matchNumber = 0;
            MatchNumTB.Content = "Match Number: " + 0;
        }

        //<summary>
        //Enter match
        //<summary>
        private void EnterMatch()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to enter this match? This action cannot be undone.", "Just checking in.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && TeamNumberTB.Text != String.Empty && MatchNumberChangerTB.Text != String.Empty)
            {
                //This should be fixed
                string compiledDataForLogging = name + "," + scoutingLevel + "," + matchNumber.ToString() + "," + TeamNumberTB.Text.ToString() + "," + Auto0.Text + "," + Auto1.Text + "," + Auto2.Text + "," + Auto3.Text + "," + Teleop0.Text + "," + Teleop1.Text + "," + Teleop2.Text + "," + Teleop3.Text + "," + RobotDiedCB.IsChecked.ToString() + "," + FieldFaultCB.IsChecked.ToString() + "," + stopwatch.Elapsed.ToString() + "," + clickCount.ToString();
                string compiledData = name + "\t" + scoutingLevel + "\t" + matchNumber.ToString() + "\t" + TeamNumberTB.Text.ToString() + "\t" + Auto0.Text + "\t" + Auto1.Text + "\t" + Auto2.Text + "\t" + Auto3.Text + "\t" + Teleop0.Text + "\t" + Teleop1.Text + "\t" + Teleop2.Text + "\t" + Teleop3.Text + "\t" + RobotDiedCB.IsChecked.ToString() + "\t" + FieldFaultCB.IsChecked.ToString() + "\t" + stopwatch.Elapsed.ToString() + "\t" + clickCount.ToString();
                QRCodeDisplayPB.Source = BitmapToImageSource(GenerateQRCode(compiledData));
                LogMatchData(compiledDataForLogging);
                NextMatch();
            }
            else
            {
                MessageBox.Show("When entering data it helps to completely fill out the form. Try again.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        //<summary>
        //Moves to the next match
        //<summary>
        private void NextMatch()
        {
            matchNumber++;
            MatchNumberChangerTB.Text = matchNumber.ToString();
            MatchNumTB.Content = "Match number: " + matchNumber.ToString();
            ResetMatch();
        }

        //<summary>
        //Resets all the match data
        //<summary>
        private void ResetMatch()
        {
            TeamNumberTB.Text = String.Empty;
            stopwatch.Stop();
            stopwatch.Reset();
            ClickCounterCountLB.Content = "Click count: 0";
            clickCount = 0;
            foreach (UIElement element in Grid.Children)
            {
                if (element is ComboBox)
                {
                    ComboBox cb = (ComboBox)element;
                    cb.SelectedIndex = 0;
                }
                if (element is CheckBox)
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
        //Logs the match data to a textfile
        //<summary>
        private void LogMatchData(string matchData)
        {
            string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "/logs/MatchDataLog.txt");
            List<string> text = new List<string>(lines.ToList());
            text.Add(matchData);
            File.WriteAllLines(Directory.GetCurrentDirectory() + "/logs/MatchDataLog.txt", text);
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
                xml.Load("SettingsProfessional.xml");
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
                player = new SoundPlayer(Directory.GetCurrentDirectory() + "/wavs/xfiles.wav");
                player.Play();
                player.Dispose();
                MessageBox.Show("Could not load settings. Failed with exception. " + ex.Message, "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
        }

        #region ClickCounter
        public void increaseClickCounter()
        {
            clickCount++;
            ClickCounterCountLB.Content = "Click count " + clickCount.ToString();
        }

        public void decreaseClickCounter()
        {
            clickCount--;
            ClickCounterCountLB.Content = "Click count " + clickCount.ToString();
        }
        #endregion

        #region EventHandlers
        private void dt_Tick(object sender, EventArgs e)
        {
            MatchNumTB.Content = "Match Number: " + MatchNumberChangerTB.Text;
            TeamNumberLB.Content = "Team Number: " + TeamNumberTB.Text;
            StopwatchLB.Content = "Stopwatch: " + stopwatch.Elapsed.TotalSeconds.ToString() + "ms";
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            EnterMatch();
        }

        private void ResetBTN_Click(object sender, RoutedEventArgs e)
        {
            ResetMatch();
        }

        private void ToggleStopwatch()
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
        //Toggle the stopwatch on and off
        //<summary>
        private void ToggleStopwatch_Click(object sender, RoutedEventArgs e)
        {
            ToggleStopwatch();
        }

        private void TeamNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ResetClickCounterBTN_Click(object sender, RoutedEventArgs e)
        {
            clickCount = 0;
            ClickCounterCountLB.Content = "Click count " + clickCount.ToString();
        }

        private void TeamNumberTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {

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
            decreaseClickCounter();
        }

        //<summary>
        //Click counter down
        //<summary>
        private void ClickCounterUp_Click(object sender, RoutedEventArgs e)
        {
            increaseClickCounter();
        }

        public void Pro_Keypressed(object sender, KeyEventArgs e) {
            switch (e.Key)
            {
                case (Key.Up):
                    increaseClickCounter();
                    break;
                case (Key.Down):
                    decreaseClickCounter();
                    break;
                case (Key.Home):
                    EnterMatch();
                    break;
                case (Key.End):
                    ResetMatch();
                    break;
                case (Key.OemPeriod):
                    ToggleStopwatch();
                    break;
            }
        }
        #endregion
    }
}