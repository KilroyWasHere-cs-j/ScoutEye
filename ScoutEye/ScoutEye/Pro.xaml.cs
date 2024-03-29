﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using QRCoder;
using NLog;
using System.Media;

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
        private bool stopwatchEnabled = false;
        private int clickCount = 0, matchNumber = 0;
        private string name = "", scoutingLevel = "Win", comboDefault = "0";
        private static readonly NLog.Logger _log_ = NLog.LogManager.GetCurrentClassLogger();
        private string versionNumber = "0.0";

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
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "logs/Prolog.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
            _log_.Debug("Start");
    }

        //<summary>
        //Enter match
        //<summary>
        private void EnterMatch()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to enter this match? This action cannot be undone.", "Just checking in.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes && TeamNumberTB.Text != String.Empty && MatchNumberChangerTB.Text != String.Empty && AllianceCB.Text != "0")
            {
                try
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.garand);
                    player.Play();
                }
                catch (Exception ex)
                {
                    _log_.Error(ex);
                }
                //This should be fixed there has got to be a better way to do this. Let's be real I'm never going to fix it...
                string compiledDataForLogging = name + "~" + scoutingLevel + "~" + matchNumber.ToString() + "~" + AllianceCB.Text + "~" + TeamNumberTB.Text.ToString() + "~" + Auto0.Text + "~" + Auto1.Text + "~" + Auto2.Text + "~" + Auto3.Text + "~" + Auto4.Text + "~" + Auto5.Text + "~" + Teleop0.Text + "~" + Teleop1.Text + "~" + Teleop2.Text + "~" + Teleop3.Text + "~" + Teleop4.Text + "~" + Teleop5.Text + "~" + RobotDiedCB.IsChecked.ToString() + "~" + FieldFaultCB.IsChecked.ToString() + "~" + stopwatch.Elapsed.ToString() + "~" + clickCount.ToString() + "~" + SpeedCB.Text + "~" + GiveDefenseCB.Text + "~" + TakeDefenseCB.Text + "~" + versionNumber;
                string compiledData = name + "\t" + scoutingLevel + "\t" + matchNumber.ToString() + "\t" + AllianceCB.Text + "\t" + TeamNumberTB.Text.ToString() + "\t" + Auto0.Text + "\t" + Auto1.Text + "\t" + Auto2.Text + "\t" + Auto3.Text + "\t" + Auto4.Text + "\t" + Auto5.Text + "\t" + Teleop0.Text + "\t" + Teleop1.Text + "\t" + Teleop2.Text + "\t" + Teleop3.Text + "\t" + Teleop4.Text + "\t" + Teleop5.Text + "\t" + RobotDiedCB.IsChecked.ToString() + "\t" + FieldFaultCB.IsChecked.ToString() + "\t" + stopwatch.Elapsed.ToString() + "\t" + clickCount.ToString() + "\t" + SpeedCB.Text + "\t" + GiveDefenseCB.Text + "\t" + TakeDefenseCB.Text + "\t" + versionNumber;
                QRCodeDisplayPB.Source = BitmapToImageSource(GenerateQRCode(compiledData));
                LogMatchData(compiledDataForLogging);
                NextMatch();
                _log_.Debug("Match entered");
            }
            else
            {
                MessageBox.Show("When entering data it helps to completely fill out the form. Try again.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
                _log_.Error("Missing fields -> enter match");
            }
        }

        //<summary>
        //Moves to the next match
        //<summary>
        private void NextMatch()
        {
            matchNumber = Int32.Parse(MatchNumberChangerTB.Text);
            matchNumber++;
            MatchNumberChangerTB.Text = matchNumber.ToString();
            ResetMatch();
            _log_.Debug("NextMatch");
        }

        //<summary>
        //Resets all the match data
        //<summary>
        private void ResetMatch()
        {
            TeamNumberTB.Text = String.Empty;
            stopwatch.Stop();
            stopwatch.Reset();
            clickCount = 0;
            foreach (UIElement element in Grid.Children)
            {
                // Reset all combo boxes except the alliance combo box
                if (element is ComboBox)
                {
                    ComboBox cb = (ComboBox)element;
                    if (cb.Text.Contains("Red") || cb.Text.Contains("Blue"))
                    {
                        // Simply don't do anything
                    }
                    else
                    {
                        cb.SelectedIndex = 0;
                    }
                }
                if (element is CheckBox)
                {
                    CheckBox cb = (CheckBox)element;
                    cb.IsChecked = false;
                }
            }
            _log_.Debug("Match Reset");
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
            _log_.Debug("QR Code made");
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
            DateTime dateTime = DateTime.UtcNow.Date;
            File.WriteAllLines(Directory.GetCurrentDirectory() + "/logs/MatchDataLog.txt", text);
            _log_.Debug("Match data logged");
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
            int[] values = Enumerable.Range(0, 500 - 0).ToArray(); // Make this it's own function for lazy evel
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                xml.Load("configs/SettingsProfessional.xml");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/settings");

                foreach(XmlNode node in nodeList)
                {
                    comboDefault = node.SelectSingleNode("DefaultComboValue").InnerText;
                    ClickCounterCountLB.Content = node.SelectSingleNode("ClickCounterLabel").InnerText;
                }
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

                AllianceCB.Items.Add("Red");
                AllianceCB.Items.Add("Blue");

                SpeedCB.Items.Add("Slow");
                SpeedCB.Items.Add("Medium");
                SpeedCB.Items.Add("Fast");

                
                for(int i = 1; i < 6; i++)
                {
                    GiveDefenseCB.Items.Add(i.ToString());
                }

                for (int i = 1; i < 6; i++)
                {
                    TakeDefenseCB.Items.Add(i.ToString());
                }

                foreach (XmlNode node in nodeList)
                {
                    VersionLB.Content = node.SelectSingleNode("AppVersion").InnerText;
                    versionNumber = node.SelectSingleNode("AppVersion").InnerText;
                    Auto0LB.Content = node.SelectSingleNode("Auto0").InnerText;
                    Auto1LB.Content = node.SelectSingleNode("Auto1").InnerText;
                    Auto2LB.Content = node.SelectSingleNode("Auto2").InnerText;
                    Auto3LB.Content = node.SelectSingleNode("Auto3").InnerText;
                    Auto4LB.Content = node.SelectSingleNode("Auto4").InnerText;
                    Auto5LB.Content = node.SelectSingleNode("Auto5").InnerText;
                    Teleop0LB.Content = node.SelectSingleNode("Teleop0").InnerText;
                    Teleop1LB.Content = node.SelectSingleNode("Teleop1").InnerText;
                    Teleop2LB.Content = node.SelectSingleNode("Teleop2").InnerText;
                    Teleop3LB.Content = node.SelectSingleNode("Teleop3").InnerText;
                    Teleop4LB.Content = node.SelectSingleNode("Teleop4").InnerText;
                    Teleop5LB.Content = node.SelectSingleNode("Teleop5").InnerText;



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
                    foreach (string item in node.SelectSingleNode("Auto4Items").InnerText.Split(',').ToList())
                    {
                        if (node.SelectSingleNode("Auto4Hide").InnerText == "true")
                        {
                            Auto4.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Auto4.IsEditable = true;
                                    Auto4.Items.Add(num);
                                }
                            }
                            else
                            {
                                Auto4.IsEditable = false;
                                Auto4.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Auto5Items").InnerText.Split(',').ToList())
                    {
                        if (node.SelectSingleNode("Auto5Hide").InnerText == "true")
                        {
                            Auto5.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Auto5.IsEditable = true;
                                    Auto5.Items.Add(num);
                                }
                            }
                            else
                            {
                                Auto5.IsEditable = false;
                                Auto5.Items.Add(item);
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
                    foreach (string item in node.SelectSingleNode("Teleop4Items").InnerText.Split(',').ToList())
                    {
                        if (node.SelectSingleNode("Teleop4Hide").InnerText == "true")
                        {
                            Teleop4.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Teleop4.IsEditable = true;
                                    Teleop4.Items.Add(num);
                                }
                            }
                            else
                            {
                                Teleop4.IsEditable = false;
                                Teleop4.Items.Add(item);
                            }
                        }
                    }
                    foreach (string item in node.SelectSingleNode("Teleop5Items").InnerText.Split(',').ToList())
                    {
                        if (node.SelectSingleNode("Teleop5Hide").InnerText == "true")
                        {
                            Teleop5.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            if (item == "NumFill")
                            {
                                foreach (int num in values)
                                {
                                    Teleop5.IsEditable = true;
                                    Teleop5.Items.Add(num);
                                }
                            }
                            else
                            {
                                Teleop5.IsEditable = false;
                                Teleop5.Items.Add(item);
                            }
                        }
                    }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                }
                _log_.Info("UI Loaded");
            }
            catch (Exception ex)
            {
                _log_.Info("Could not load settings. " + ex.Message.ToString());
                MessageBox.Show($"Granny Smith {ex.ToString()}", "Fatal error", MessageBoxButton.OK, MessageBoxImage.Error);
                _log_.Fatal("Granny Smith");
                _log_.Fatal(ex);
                Environment.Exit(0);
            }
        }

        #region ClickCounter
        public void increaseClickCounter()
        {
            clickCount++;
            ClickCounterCountCountLB.Content = clickCount.ToString();
        }

        public void decreaseClickCounter()
        {
            clickCount--;
            ClickCounterCountCountLB.Content = clickCount.ToString();
        }
        #endregion

        #region EventHandlers
        private void dt_Tick(object sender, EventArgs e)
        {
            StopwatchLB.Content = "Stopwatch: " + stopwatch.Elapsed.TotalSeconds.ToString() + "ms";
            ClickCounterCountCountLB.Content = clickCount.ToString();
        }

        private void EnterBTN_Click(object sender, RoutedEventArgs e)
        {
            stopwatch.Stop();
            EnterMatch();
        }

        private void ResetBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to reset this match? This action cannot be undone.", "Just checking in.", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    try
                    {
                        SoundPlayer player = new SoundPlayer(Properties.Resources.brrrr);
                        player.Play();
                    }
                    catch (Exception ex)
                    {
                        _log_.Error(ex);
                    }
                    stopwatch.Stop();
                    ResetMatch();
                    break;
                case MessageBoxResult.No:
                    break;
            }
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

        private void TeamNumberTB_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(TeamNumberTB.Text, "[^0-9]"))
            {
                TeamNumberTB.Text = TeamNumberTB.Text.Remove(TeamNumberTB.Text.Length - 1);
                MessageBox.Show("Please enter only numbers.");
            }
        }
        private void MatchNumberChangerTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(MatchNumberChangerTB.Text, "[^0-9]"))
            {
                MatchNumberChangerTB.Text = MatchNumberChangerTB.Text.Remove(MatchNumberChangerTB.Text.Length - 1);
                MessageBox.Show("Please enter only numbers.");
            }
        }
        #endregion
    }
}