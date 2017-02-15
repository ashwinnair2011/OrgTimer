using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace OrgTimer
{
    public partial class OrgTimerForm : Form
    {
        private enum TimerState
        {
            Working,
            Chilling,
            Stopped
        }
        private int _currentIntervalTimeInSecs;
        private readonly int _chillIntervalInSecs;
        private readonly int _workIntervalInSecs;
        private readonly string _timeFormat;
        private bool _allowQuit = false;
        private TimerState _timerState;

        public OrgTimerForm()
        {
            InitializeComponent();
            _timerState = TimerState.Stopped;
            _workIntervalInSecs = Convert.ToInt32(ConfigurationManager.AppSettings["WorkIntervalInSecs"]);
            _chillIntervalInSecs = Convert.ToInt32(ConfigurationManager.AppSettings["ChillIntervalInSecs"]);
            _timeFormat = ConfigurationManager.AppSettings["TimeFormat"];
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            ActionButton.BackColor = Color.SeaShell;
            switch (_timerState)
            {
                case TimerState.Stopped:
                case TimerState.Chilling:
                    //start timer for 10 minutes
                    _timerState = TimerState.Working;
                    _currentIntervalTimeInSecs = _workIntervalInSecs;
                    JobTimer.Start();
                    break;
                case TimerState.Working:
                    //start timer for 2 minutes
                    _timerState = TimerState.Chilling;
                    _currentIntervalTimeInSecs = _chillIntervalInSecs;
                    break;
            }
        }

        private void JobTimer_Tick(object sender, EventArgs e)
        {
            JobTimer.Stop();
            var timeLeft = TimeSpan.FromSeconds(--_currentIntervalTimeInSecs).ToString(_timeFormat);
            ActionButton.Text = $@"{_timerState} {timeLeft}";
            if (_currentIntervalTimeInSecs == 0)
            {
                SwitchToAlarmMode();
            }
            JobTimer.Start();
        }

        private void SwitchToAlarmMode()
        {
            ActionButton.BackColor = Color.Red;
            if (IsWindowHidden()) ShowWindow();
        }


        private void OrgTimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allowQuit) return;
            HideWindow();
            OrgTimerNotify.ShowBalloonTip(2000, 
                "Org Timer Minimized", 
                "Org Timer will continue to run in the Notification area. Right click the notification icon to exit.", 
                ToolTipIcon.Info);
            e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowQuit = true;
            this.Close();
        }

        private void OrgTimerNotify_MouseDoubleClick(object sender, MouseEventArgs e) => ShowWindow();
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) => HideWindow();
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e) => ShowWindow();

        private void HideWindow() => this.WindowState = FormWindowState.Minimized;
        private void ShowWindow() => this.WindowState = FormWindowState.Normal;
        private bool IsWindowHidden() => this.WindowState == FormWindowState.Minimized;

    }
}
