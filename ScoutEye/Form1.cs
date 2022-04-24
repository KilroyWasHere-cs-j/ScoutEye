using IronBarCode;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Timers;

namespace ScoutEye
{
    public partial class Form1 : Form
    {
        private Logger logger;
        private Stopwatch stopwatch;
        private Sheets sheets;
        private bool stopWatchStarted = false;
        private int matchNumber = 0;
        private int teamNumber = 5687;
        private string teamName = "Outliers";
        private string scoutName;
        private string output;
#pragma warning disable IDE0051
        private readonly string theLink = "http://www.youtube.com/watch?v=oHg5SJYRHA0";
#pragma warning restore IDE0051

        public Form1()
        {
            InitializeComponent();
            logger = new Logger();
            stopwatch = new Stopwatch();
            sheets = new Sheets();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setupComboBoxes();
            logger.Log("Form loaded");
            TeamNumberLB.Text = "Team number: " + teamNumber.ToString();
            MatchNumberLB.Text = "Match number: " + matchNumber.ToString();
            stopWatchUpdater.Enabled = true;
        }

        private void CompileData()
        {
            output = matchNumber + ":" + teamNumber + ":" + teamName + ":" + AutoCB.Text + ":" + TeleopCB.Text + ":" + EndgameCB.Text + ":" + DefenceCB.Text + ":" + PointScoredTB.Text + ":" + NotesTB.Text;
            sheets.StoreData(output);
        }

        #region QR
        private void GenerateQRCode(string data)
        {
            var QRCode = QRCodeWriter.CreateQrCode(data, 260, QRCodeWriter.QrErrorCorrectionLevel.Medium);
            QRCodePB.Image = QRCode.ToBitmap();
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
            AutoCB.SelectedIndex = 0;
            TeleopCB.SelectedIndex = 0;
            EndgameCB.SelectedIndex = 0;
            DefenceCB.SelectedIndex = 0;
            PointScoredTB.Text = "0";
            NotesTB.Text = "Match Notes";
            logger.Log("Match entered");
        }

        //<summary>
        //Enters the data into the system
        //It also clears the UI after it's done
        //<summary>
        private void EnterData()
        {
            if (AutoCB.SelectedIndex != 0 && TeleopCB.SelectedIndex != 0 && EndgameCB.SelectedIndex != 0 && DefenceCB.SelectedIndex != 0 && NameTB.Text != String.Empty)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to enter this match", "Enter match", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    scoutName = NameTB.Text;
                    CompileData();
                    GenerateQRCode(output);
                    matchNumber++;
                    updateUI();
                }
                else if (result == DialogResult.No)
                {
                    logger.Log("Match entry canceled");
                }
            }
            else
            {
                MessageBox.Show("Not all fields changed");
            }
        }

        //<summary>
        //Sets all the data in the combo boxes
        //<summary>
        private void setupComboBoxes()
        {
            //Fill the combo boxes
            AutoCB.Items.Add("Empty");
            AutoCB.Items.Add("Not seen");
            AutoCB.Items.Add("Low");
            AutoCB.Items.Add("Mid");
            AutoCB.Items.Add("High");

            TeleopCB.Items.Add("Empty");
            TeleopCB.Items.Add("Not seen");
            TeleopCB.Items.Add("Low");
            TeleopCB.Items.Add("Mid");
            TeleopCB.Items.Add("High");

            EndgameCB.Items.Add("Empty");
            EndgameCB.Items.Add("Not seen");
            EndgameCB.Items.Add("Low");
            EndgameCB.Items.Add("Mid");
            EndgameCB.Items.Add("High");

            DefenceCB.Items.Add("Empty");
            DefenceCB.Items.Add("Not seen");
            DefenceCB.Items.Add("Low");
            DefenceCB.Items.Add("Mid");
            DefenceCB.Items.Add("High");

            //Set the combo boxes to base setting
            AutoCB.SelectedIndex = 0;
            TeleopCB.SelectedIndex = 0;
            EndgameCB.SelectedIndex = 0;
            DefenceCB.SelectedIndex = 0;

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
                AutoCB.SelectedIndex = 0;
                TeleopCB.SelectedIndex = 0;
                EndgameCB.SelectedIndex = 0;
                DefenceCB.SelectedIndex = 0;
                PointScoredTB.Text = "0";
                NotesTB.Text = "Match Notes";
                logger.Log("Match reset");
            }
            else if (result == DialogResult.No)
            {
                logger.Log("Match reset canceled");
            }
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
            enterTip.ShowAlways = true;
            enterTip.SetToolTip(EnterBTN, "Click to enter match data");
            resetTip.ShowAlways = true;
            resetTip.SetToolTip(ResetBTN, "Click to clear the match data");
            notesTip.ShowAlways = true;
            notesTip.SetToolTip(NotesTB, "Type in notes about the match");
            autoTip.ShowAlways = true;
            autoTip.SetToolTip(AutoCB, "Auto score");
            teleopTip.ShowAlways = true;
            teleopTip.SetToolTip(TeleopCB, "Teleop score");
            endgameTip.ShowAlways = true;
            endgameTip.SetToolTip(EndgameCB, "End game score");
            defenceTip.ShowAlways = true;
            defenceTip.SetToolTip(DefenceCB, "Defence score");
            pointsTip.ShowAlways = true;
            pointsTip.SetToolTip(PointScoredTB, "The total points scored during the match");
            matchData.ShowAlways = true;
            matchData.SetToolTip(MatchDataPlanel, "You can't change anything here, so you should move along");
        }
        #endregion

        #region Buttons
        private void EnterBTN_Click(object sender, EventArgs e)
        {
            EnterData();
        }

        private void DebugBTN_Click(object sender, EventArgs e)
        {
            AutoCB.SelectedIndex = 4;
            TeleopCB.SelectedIndex = 4;
            EndgameCB.SelectedIndex = 4;
            DefenceCB.SelectedIndex = 4;
            PointScoredTB.Text = "40";

            NotesTB.Text = "Random text";
        }

        private void ResetBTN_Click(object sender, EventArgs e)
        {
            Reset();
        }
        #endregion

        #region EventHandlers
        private void timer1_Tick(object sender, EventArgs e)
        {
            StopwatchLB.Text = "Stopwatch: " + stopwatch.Elapsed.ToString();
        }


        private void StartTimerBTN_Click(object sender, EventArgs e)
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
            }
        }
        #endregion

        #region RandomShitIShouldRemove
        private void MatchDataPlanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #endregion
    }
}