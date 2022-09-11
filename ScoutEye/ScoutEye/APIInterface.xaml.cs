using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for APIInterface.xaml
    /// </summary>
    public partial class APIInterface : Window
    {
        private HttpClient client;
        public APIInterface()
        {
            InitializeComponent();
        }

        private void RunCommandBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Under construction");
        }

        private void OpenFileBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Work zone");
            Process.Start("notepad.exe", Directory.GetCurrentDirectory() + "/APIOutputLog.txt");
        }
    }
}
