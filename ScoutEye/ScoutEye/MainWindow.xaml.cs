using System;
using System.IO;
using System.Media;
using System.Windows;
using IWshRuntimeLibrary;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pro pro;
        Configurer configer;

        private SoundPlayer player;
        private string userName = "";

        public MainWindow()
        {
            InitializeComponent();
            player = new SoundPlayer(Directory.GetCurrentDirectory() + "/wavs/taco.wav");
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
                        player.Play();
                    }
                    catch
                    {

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
            configer = new Configurer();
            configer.Show();
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
            shortcut.Hotkey = "Ctrl+Shift+S";
            shortcut.TargetPath = Directory.GetCurrentDirectory() + @"\ScoutEye.exe";
            shortcut.Save();
        }
    }
}
