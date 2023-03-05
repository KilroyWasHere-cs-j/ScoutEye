using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

namespace ScoutEye
{
    /// <summary>
    /// Interaction logic for Configurer.xaml
    /// </summary>
    public partial class Configurer : Window
    {
        private XmlDocument xml;
        private OpenFileDialog fdlg;
        private string versionNumb;
        private string appName = "ScoutEye";
        private string defaultComboValue = "Empty";
        public Configurer()
        {
            InitializeComponent();
            fdlg = new OpenFileDialog();
            xml = new XmlDocument();
            fdlg.Title = "ScoutEye Configurer";
            fdlg.InitialDirectory = Directory.GetCurrentDirectory();
            fdlg.Filter = "XML Files (*.xml*)|*.xml*|All files (*.xml*)|*.xml*"; //Only allow xml files to be shown, which is the file used for configuration
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
        }

        private bool isTrue(string s)
        {
            return s.Contains("true");
        }
        private void clear()
        {
            try
            {
                foreach (UIElement element in Grid.Children)
                {
                    if (element is TextBox)
                    {
                        TextBox tb = (TextBox)element;
                        tb.Text = string.Empty;
                    }
                    else if (element is CheckBox)
                    {
                        CheckBox rb = (CheckBox)element;
                        rb.IsChecked = true;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadConfig()
        {
            // Promt user to select path to settings
            fdlg.ShowDialog();
            string filePath = fdlg.FileName;
            // Update UI
            SelectedFilePathLB.Content = filePath;
            // Get all the nodes in the settings document
            try
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                xml.Load(filePath);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                XmlNodeList nodeList = xml.DocumentElement.SelectNodes("/settings");
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                //Maybe add an iterator
                try
                {
                    foreach (XmlNode node in nodeList)
                    {
                        VersionTB.Content = node.SelectSingleNode("AppVersion").InnerText;
                        versionNumb = node.SelectSingleNode("AppVersion").InnerText;
                        DefaultValueLB.Text = node.SelectSingleNode("DefaultComboValue").InnerText;
                        DefaultClickCountLB.Text = node.SelectSingleNode("ClickCounterLabel").InnerText;

                        A0labelTB.Text = node.SelectSingleNode("Auto0").InnerText;
                        A0contentsTB.Text = node.SelectSingleNode("Auto0Items").InnerText;
                        A0VisableCB.IsChecked = isTrue(node.SelectSingleNode("Auto0Hide").InnerText);

                        A1labelTB.Text = node.SelectSingleNode("Auto1").InnerText;
                        A1contentsTB.Text = node.SelectSingleNode("Auto1Items").InnerText;
                        A1VisableCB.IsChecked = isTrue(node.SelectSingleNode("Auto1Hide").InnerText);

                        A2labelTB.Text = node.SelectSingleNode("Auto2").InnerText;
                        A2contentsTB.Text = node.SelectSingleNode("Auto2Items").InnerText;
                        A2VisableCB.IsChecked = isTrue(node.SelectSingleNode("Auto2Hide").InnerText);

                        A3labelTB.Text = node.SelectSingleNode("Auto3").InnerText;
                        A3contentsTB.Text = node.SelectSingleNode("Auto3Items").InnerText;
                        A3VisableCB.IsChecked = isTrue(node.SelectSingleNode("Auto3Hide").InnerText);

                        T0labelTB.Text = node.SelectSingleNode("Teleop0").InnerText;
                        T0contentsTB.Text = node.SelectSingleNode("Teleop0Items").InnerText;
                        T0VisableCB.IsChecked = isTrue(node.SelectSingleNode("Teleop0Hide").InnerText);

                        T1labelTB.Text = node.SelectSingleNode("Teleop1").InnerText;
                        T1contentsTB.Text = node.SelectSingleNode("Teleop1Items").InnerText;
                        T1VisableCB.IsChecked = isTrue(node.SelectSingleNode("Teleop1Hide").InnerText);


                        T2labelTB.Text = node.SelectSingleNode("Teleop2").InnerText;
                        T2contentsTB.Text = node.SelectSingleNode("Teleop2Items").InnerText;
                        T2VisableCB.IsChecked = isTrue(node.SelectSingleNode("Teleop2Hide").InnerText);

                        T3labelTB.Text = node.SelectSingleNode("Teleop3").InnerText;
                        T3contentsTB.Text = node.SelectSingleNode("Teleop3Items").InnerText;
                        T3VisableCB.IsChecked = isTrue(node.SelectSingleNode("Teleop3Hide").InnerText);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Courtland {ex.ToString()}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception w)
            {
                MessageBox.Show(w.Message.ToString());
            }
        }

        private void setConfig(string filePath)
        {
            List<string> headers = new List<string>() { "Auto0", "Auto1", "Auto2", "Auto3", "Teleop0", "Teleop1", "Teleop2", "Teleop3" };
            // Proabably should be global
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("settings");
            xmlDoc.AppendChild(rootNode);

            XmlNode node = xmlDoc.CreateElement("AppName");
            node.InnerText = appName;
            rootNode.AppendChild(node);

            node = xmlDoc.CreateElement("AppVersion");
            node.InnerText = versionNumb;
            rootNode.AppendChild(node);

            node = xmlDoc.CreateElement("DefaultComboValue");
            node.InnerText = DefaultValueLB.Text;
            rootNode.AppendChild(node);

            node = xmlDoc.CreateElement("ClickCounterLabel");
            node.InnerText = DefaultClickCountLB.Text;
            rootNode.AppendChild(node);

            foreach (var head in headers)
            {
                switch (head)
                {
                    case "Auto0":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = A0labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = A0contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = A0VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Auto1":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = A1labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = A1contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = A1VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Auto2":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = A2labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = A2contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = A2VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Auto3":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = A3labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = A3contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = A3VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Teleop0":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = T0labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = T0contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = T0VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Teleop1":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = T1labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = T1contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = T1VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Teleop2":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = T2labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = T2contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = T2VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;

                    case "Teleop3":
                        node = xmlDoc.CreateElement(head);
                        node.InnerText = T3labelTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Items");
                        node.InnerText = T3contentsTB.Text;
                        rootNode.AppendChild(node);

                        node = xmlDoc.CreateElement(head + "Hide");
                        node.InnerText = T3VisableCB.IsChecked.ToString().ToLower();
                        rootNode.AppendChild(node);
                        break;
                }
            }

            xmlDoc.Save(filePath);
        }

        #region EventHandlers
        private void LoadConfigFileBTN_Click(object sender, RoutedEventArgs e)
        {
            LoadConfig();
        }

        private void SetConfigBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to submit this configuration?", "I like ice cream", MessageBoxButton.YesNo, MessageBoxImage.Hand);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    setConfig(SelectedFilePathLB.Content.ToString());
                    break;
                case MessageBoxResult.No:
                    //Need to put something here I'm not a fan of empty blocks
                    break;
            }
        }
        private void ClearBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear window?", "Clear?", MessageBoxButton.YesNo, MessageBoxImage.Hand);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    clear();
                    break;
                    case MessageBoxResult.No:
                    break;
            }
        }
        #endregion
    }
}
