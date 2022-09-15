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
                if (NameTB.Text != string.Empty && CurrentMatchNumberTB.Text != string.Empty)
                {
                    player.Play();
                    pro = new Pro(NameTB.Text, Int32.Parse(CurrentMatchNumberTB.Text));
                    pro.Show();
                    this.Close();
                }
                else
                {
                    //Something was missing
                    MessageBox.Show("Please enter your name.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch
            {
                //What ever the user entered was not a real number
                MessageBox.Show("Hey, so that's not a real number. Examples of numbers are like; 1, 2, 3, 4", "Did you really think that would work?", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void ScoutOption1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Open the amateur window and closes the current window
                if (NameTB.Text != "Name")
                {
                    //Might need different sound
                    player.Play();
                    am = new Am(NameTB.Text, Int32.Parse(CurrentMatchNumberTB.Text));
                    am.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please enter your name.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
                }
            }
            catch
            {
                //What ever the user entered was not a real number
                MessageBox.Show("Hey, so that's not a real number. Examples of numbers are like; 1, 2, 3, 4", "Did you really think that would work?", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
