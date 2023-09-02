using System;
using System.IO;
using System.Media;
using System.Windows;
using IWshRuntimeLibrary;
using NLog;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pro pro;
        Configurer configuer;

        private SoundPlayer player;
        private string userName = "";
        private static readonly NLog.Logger _log_ = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "logs\\Mainlog.log" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            config.AddRule(LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            // Apply config           
            NLog.LogManager.Configuration = config;
            _log_.Debug("Start");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            userName = Environment.UserName;
            NameTB.Text = userName;
        }

        //<summary>
        //The user has picked the pro level of scouting
        //<summary>
        private void ScoutOption2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //If the user entered a valid name and match number
                if (NameTB.Text != string.Empty)
                {
                    try
                    {
                        SoundPlayer sndplayr = new SoundPlayer();
                        sndplayr.Play();
                    }
                    catch (Exception ex)
                    {
                        _log_.Error(ex.ToString());
                    }
                    pro = new Pro(NameTB.Text);
                    pro.Show();
                    this.Close();
                }
                else
                {
                    //Something was missing
                    MessageBox.Show("Name field found to be missing of invalid.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region EventHandlers
        private void contactBTN_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://scout-eye.com/documentation");
        }

        private void helpBTN_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://scout-eye.com/documentation");
        }
        private void configureBTN_Click(object sender, RoutedEventArgs e)
        {
            configuer = new Configurer();
            configuer.Show();
        }
        #endregion

        private void NameTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void createShortcutBTN_Click(object sender, RoutedEventArgs e)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = (string)shell.SpecialFolders.Item(ref shDesktop) + @"\ScoutEye.lnk";
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.Description = "ScoutEye link";
            shortcut.Hotkey = "Ctrl+Shift+Q";
            shortcut.TargetPath = Directory.GetCurrentDirectory() + @"\ScoutEye.exe";
            shortcut.Save();
        }
    }
}
