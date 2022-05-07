using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            pro = new Pro();
            am = new Am();
        }

        private void ScoutOption2_Click(object sender, RoutedEventArgs e)
        {
            //Open the professional window and closes the current window
            if(NameTB.Text != "Name")
            {
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
