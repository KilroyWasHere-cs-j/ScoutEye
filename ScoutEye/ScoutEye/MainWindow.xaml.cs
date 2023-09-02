using System;
using System.IO;
using System.Media;
using System.Windows;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Pro pro;
        Am am;
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

        //<summary>
        //The user has picked the amateur level of scouting
        //<summary>
        private void ScoutOption1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the amateur window and closes the current window
                if (NameTB.Text != string.Empty)
                {
                    //Might need different sound
                    try
                    {
                        player.Play();
                    }
                    catch
                    {

                    }
                    am = new Am(NameTB.Text);
                    am.Show();
                    this.Close();
                }
                else
                {
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
    }
}
