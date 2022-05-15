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
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void ScoutOption2_Click(object sender, RoutedEventArgs e)
        {
            //Open the professional window and closes the current window
            if(NameTB.Text != string.Empty)
            {
                pro = new Pro(NameTB.Text);
                pro.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your name.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void ScoutOption1_Click(object sender, RoutedEventArgs e)
        {
            //Open the amateur window and closes the current window
            if (NameTB.Text != "Name")
            {
                am = new Am();
                am.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your name.", "Missing fields", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
