using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QRCoder;

namespace ScoutEye
{
    public partial class Form1 : Form
    {
        private Logger logger;
        private Stopwatch stopwatch;
        private Sheets sheets;
        private QRCodeGenerator qrGenerator;
        private StreamReader configReader;
        private string APPNAME = "ScoutEye";
        private bool stopWatchStarted = false;
        private int matchNumber = 0;
        private int teamNumber = 5687;
        private string teamName = "Outliers";
        private string scoutName;
        private string output;
        private int clickCount = 0;
#pragma warning disable IDE0051
        private readonly string theLink = "http://www.youtube.com/watch?v=oHg5SJYRHA0";
#pragma warning restore IDE0051

        public Form1()
        {
            InitializeComponent();
            logger = new Logger();
            stopwatch = new Stopwatch();
            sheets = new Sheets();
            qrGenerator = new QRCodeGenerator();
            configReader = new StreamReader("Config.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setupComboBoxes();
            logger.Log("Form loaded");
            TeamNumberLB.Text = "Team number: " + teamNumber.ToString();
            MatchNumberLB.Text = "Match number: " + matchNumber.ToString();
            stopWatchUpdater.Enabled = true;
            LoadUI();
        }

        private void CompileData()
        {
            //Should be a function return
            output = matchNumber + ":" + teamNumber + ":" + teamName + ":" + Auto1TB.Text + ":" + Auto2TB.Text + ":" + Auto3TB.Text + ":" + Tele1TB.Text + ":" + Tele2TB.Text + ":" + Tele3TB.Text + ":" + StopwatchLB.Text;        
            sheets.StoreData(output);
        }

        #region QR
        private void GenerateQRCode(string data)
        {
            try
            {
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(5);
                QRCodePB.Image = qrCodeImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region UI

        #region UIFunctions
        //<summary>
        //Updates the UI
        //<summary>
        private void updateUI()
        {
            //Update the UI, reset the parameters back to base values
            logger.Log("UI updated");
            TeamNumberLB.Text = "Team number: " + teamNumber.ToString();
            MatchNumberLB.Text = "Match number: " + matchNumber.ToString();
            TeamNameLB.Text = "Team name: " + teamName.ToString();
            NotesTB.Text = "Match Notes";
            logger.Log("Match entered");
        }

        //<summary>
        //Load UI
        //<summary>
        public void LoadUI()
        {
            int cout = 1;
            foreach (string line in System.IO.File.ReadLines(@"Config.txt"))
            {
                int index = line.IndexOf('=');
                string sub = line.Substring(index + 1);
                switch (cout)
                {
                    case 1:
                        Auto1LB.Text = sub;
                        break;
                    case 2:
                        Auto2LB.Text = sub;
                        break;
                    case 3:
                        Auto3LB.Text = sub;
                        break;
                    case 4:
                        Tele1LB.Text = sub;
                        break;
                    case 5:
                        Tele2LB.Text = sub;
                        break;
                    case 6:
                        Tele3LB.Text = sub;
                        break;
                }
                cout++;
            }
        }

        //<summary>
        //Enters the data into the system
        //It also clears the UI after it's done
        //<summary>
        private void EnterData()
        {
            if(Auto1TB.Text != String.Empty && Auto2TB.Text != String.Empty && Auto3TB.Text != String.Empty && Tele1TB.Text != String.Empty && Tele2TB.Text != String.Empty && Tele3TB.Text != String.Empty && NameTB.Text != String.Empty)
            {
                scoutName = NameTB.Text;
                CompileData();
                GenerateQRCode(output);
                matchNumber++;
                updateUI();
                resetUI();
            }
            else
            {
                MessageBox.Show("Missing data");
            }
        }

        //<summary>
        //Sets all the data in the combo boxes
        //<summary>
        private void setupComboBoxes()
        {
            //Setup the tool tips
            ToolTips();
        }

        //<summary>
        //Resets the UI
        //Clears all
        //<summary>
        private void Reset()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the match? \n This action can not be undone", "Match clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                //Set the combo boxes to base setting
                NotesTB.Text = "Match Notes";
                logger.Log("Match reset");
            }
            else if (result == DialogResult.No)
            {
                logger.Log("Match reset canceled");
            }
        }

        //<summary>
        //Toggle the stopwatch on and off
        //<summary>

        public void ToggleStopwatch()
        {
            switch (stopWatchStarted)
            {
                case false:
                    stopwatch.Start();
                    stopWatchStarted = true;
                    break;
                case true:
                    stopwatch.Stop();
                    stopWatchStarted = false;
                    break;
            }
        }

        //<summary>
        //Resets the UI
        //<summary>
        public void resetUI()
        {
            Auto1TB.Text = String.Empty;
            Auto2TB.Text = String.Empty;
            Auto3TB.Text = String.Empty;
            Tele1TB.Text = String.Empty;
            Tele2TB.Text = String.Empty;
            Tele3TB.Text = String.Empty;
            stopwatch.Stop();
            stopwatch.Reset();
            ClickCounterLB.Text = String.Empty;
        }

        //<summary>
        //Exits the application asks the user if they want to exit the app
        //<summary>
        public void exit()
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if(DialogResult.Yes == result)
            {
                Environment.Exit(0);
            }
        }

        //<summary>
        //Sets the click counter up
        //<summary>
        public void CountUp()
        {
            clickCount++;
            ClickCounterLB.Text = clickCount.ToString();
        }

        //<summary>
        //Set the click counter down
        //<summary>
        public void CountDown()
        {
            clickCount--;
            ClickCounterLB.Text = clickCount.ToString();
        }

        //<summary>
        //Sets up the UI's tooltips
        //<summary>
        private void ToolTips()
        {
            //Set up the ToolTips
            ToolTip enterTip = new ToolTip();
            ToolTip resetTip = new ToolTip();
            ToolTip notesTip = new ToolTip();
            ToolTip autoTip = new ToolTip();
            ToolTip teleopTip = new ToolTip();
            ToolTip endgameTip = new ToolTip();
            ToolTip defenceTip = new ToolTip();
            ToolTip pointsTip = new ToolTip();
            ToolTip matchData = new ToolTip();
            ToolTip stopwatchTip = new ToolTip();
            enterTip.ShowAlways = true;
            enterTip.SetToolTip(EnterBTN, "Click to enter match data");
            resetTip.ShowAlways = true;
            resetTip.SetToolTip(ResetBTN, "Click to clear the match data");
            notesTip.ShowAlways = true;
            notesTip.SetToolTip(NotesTB, "Type in notes about the match");
            autoTip.ShowAlways = true;
            matchData.ShowAlways = true;
            matchData.SetToolTip(MatchDataPlanel, "You can't change anything here, so you should move along");
            stopwatchTip.ShowAlways = true;
            stopwatchTip.SetToolTip(StartTimerBTN, "Toggle Stopwatch and off");
        }
        #endregion

        #region Buttons
        private void EnterBTN_Click(object sender, EventArgs e)
        {
            EnterData();
        }

        private void DebugBTN_Click(object sender, EventArgs e)
        {
            NameTB.Text = "Outliers";
            Auto1TB.Text = "NULL";
            Auto2TB.Text = "NULL";
            Auto3TB.Text = "NULL";
            Tele1TB.Text = "NULL";
            Tele2TB.Text = "NULL";
            Tele3TB.Text = "NULL";
            NotesTB.Text = "Random text";
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Minus_Click(object sender, EventArgs e)
        {
            CountDown();
        }
        #endregion

        #region EventHandlers
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //If the user clicks no don't exit the app
            var window = MessageBox.Show("Are you sure you want to close?", "Close app", MessageBoxButtons.YesNo);
            e.Cancel = (window == DialogResult.No);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            StopwatchLB.Text = "Stopwatch: " + stopwatch.Elapsed.ToString();
        }


        private void StartTimerBTN_Click(object sender, EventArgs e)
        {
            ToggleStopwatch();
        }

        private void PlusBTN_Click(object sender, EventArgs e)
        {
            CountUp();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Oemplus:
                    EnterData();
                    break;
                case Keys.OemMinus:
                    Reset();
                    break;
                case Keys.Space:
                    ToggleStopwatch();
                    break;
                case Keys.W:
                    CountUp();
                    break;
                case Keys.S:
                    CountDown();
                    break;
                case Keys.R:
                    stopwatch.Stop();
                    ClickCounterLB.Text = "0";
                    stopwatch.Reset();
                    StopwatchLB.Text = "0.0000";
                    clickCount = 0;
                    break;
                case Keys.Escape:
                    exit();
                    break;
            }
        }
        #endregion

        #region RandomShitIShouldRemove
        private void StopwatchLB_Click(object sender, EventArgs e)
        {

        }
        private void MatchDataPlanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #endregion
    }
}