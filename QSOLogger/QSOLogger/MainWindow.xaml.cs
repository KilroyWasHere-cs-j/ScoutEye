using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Windows;

namespace QSOLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> results;
        private SqlConnection cnn;
        private SqlCommand command;
        private SqlDataReader dataReader;
        private string QSOdata = string.Empty;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainWindow()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            InitializeComponent();
            results = new List<string>();
            modeCB.Items.Add("FM");
            modeCB.Items.Add("AM");
            modeCB.Items.Add("USB");
            modeCB.Items.Add("LSB");
            modeCB.Items.Add("PSK");
            modeCB.Items.Add("CW");
            OpenConnection();
        }

        private void fillBTN_Click(object sender, RoutedEventArgs e)
        {
            if(callTB.Text != String.Empty)
            {
                GetInfo(callTB.Text);
            }
            else
            {
                MessageBox.Show("Please fill in the call sign", "Missing data");
            }
        }

        private void logBTN_Click(object sender, RoutedEventArgs e)
        {
            if(nameTB.Text != String.Empty && callTB.Text != String.Empty && timeTB.Text != String.Empty && gridTB.Text != String.Empty && FreqTB.Text != String.Empty && modeCB.SelectedIndex != -1)
            {
                LogQSO();
            }
            else
            {
                MessageBox.Show("Missing data", "Missing vital QSO data"); 
            }
        }

        private void LogQSO()
        {
            FillQSO();
            RunCommand();
            MessageBox.Show("QSO Logged");
            ClearUI();
        }

        private void ClearUI()
        {
            callTB.Text = "";
            timeTB.Text = "";
            gridTB.Text = "";
            nameTB.Text = "";
            modeCB.SelectedIndex = -1;
            FreqTB.Text = "";
        }

        private void FillQSO()
        {
            //Fills out all the nessary QSO data into a string ready to be stored
            QSOdata += callTB.Text + " " + timeTB.Text + " " + gridTB.Text + " " + nameTB.Text + " " + modeCB.SelectedIndex.ToString() + " " + FreqTB.Text;
        }

        private async void GetInfo(string callSign)
        {
            //Gets the calls info from the web
            //https://api.hamdb.org/v1/kc1riz/csv/hamdb
            string request = "https://api.hamdb.org/v1/" + callSign + "/csv/hamdb";
            using var client = new HttpClient();
            var content = await client.GetStringAsync(request);
            results = content.Split(",").ToList();
            timeTB.Text = DateTime.Now.ToString();
            gridTB.Text = results[3];
            nameTB.Text = results[7] + " " + results[8] + " " + results[9];
        }

        #region SQL

        private void OpenConnection()
        {
            //Opens a connection with a SQL Server databasegr
            cnn = new SqlConnection("Data Source=DESKTOP-F0HHK8S\\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            cnn.Open();
        }

        private void CloseConnection()
        {
            cnn.Close();
        }

        private void RunCommand()
        {
            string qso = $"USE [QSOLogger] INSERT INTO [dbo].[QSOs] ([call],[time],[grid],[name],[mode],[frequency]) VALUES ('{callTB.Text}',  '{timeTB.Text}', '{gridTB.Text}', '{nameTB.Text}', '{modeCB.SelectedIndex.ToString()}', '{FreqTB.Text}');";
            command = new SqlCommand(qso, cnn);
            //Should be removed
            dataReader = command.ExecuteReader();
            dataReader.Close();
        }
        #endregion

        private void closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseConnection();
        }
    }
}