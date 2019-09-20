using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using OrgTimer.Properties;

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
        private bool _showMinimizeBalloonTip;
        private TimerState _timerState;
        private bool _allowQuit;
        private bool _isPaused = true;

        public OrgTimerForm()
        {
            InitializeComponent();
            _timerState = TimerState.Stopped;
            _workIntervalInSecs = Convert.ToInt32(ConfigurationManager.AppSettings["WorkIntervalInSecs"]);
            _chillIntervalInSecs = Convert.ToInt32(ConfigurationManager.AppSettings["ChillIntervalInSecs"]);
            _timeFormat = ConfigurationManager.AppSettings["TimeFormat"];
            _showMinimizeBalloonTip = true;
        }

        private void Pause()
        {
            JobTimer.Stop();
            PlayPauseButton.BackgroundImage = Resources.playImage;
            ActionButton.Enabled = _isPaused;
            _isPaused = !_isPaused;
        }
        private void Play()
        {
            JobTimer.Start();
            PlayPauseButton.BackgroundImage = Resources.pauseImage;
            ActionButton.Enabled = _isPaused;
            _isPaused = !_isPaused;
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            ActionButton.BackColor = Color.SeaShell;
            switch (_timerState)
            {
                case TimerState.Stopped:
                    //start timer for _workIntervalInSecs
                    _timerState = TimerState.Working;
                    _currentIntervalTimeInSecs = _workIntervalInSecs;
                    PlayPauseButton.Visible = true;
                    Play();
                    break;
                case TimerState.Chilling:
                    //start timer for _workIntervalInSecs
                    _timerState = TimerState.Working;
                    _currentIntervalTimeInSecs = _workIntervalInSecs;
                    break;
                case TimerState.Working:
                    //start timer for _chillIntervalInSecs
                    _timerState = TimerState.Chilling;
                    _currentIntervalTimeInSecs = _chillIntervalInSecs;
                    break;
            }
        }

        //Timer ticks every second
        private void JobTimer_Tick(object sender, EventArgs e)
        {
            JobTimer.Stop();
            var timeLeft = TimeSpan.FromSeconds(--_currentIntervalTimeInSecs).ToString(_timeFormat);
            ActionButton.Text = $@"{_timerState} {timeLeft}"; //display time left
            if (_currentIntervalTimeInSecs == 0) //show alarm if required
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


        /// <summary>
        /// CLose form only if called via exitToolBarMenuItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrgTimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_allowQuit) return;
            HideWindow();
            e.Cancel = true;
            if (!_showMinimizeBalloonTip) return;
            _showMinimizeBalloonTip = false;
            ShowMinimizedBalloonTip();
        }

        private void ShowMinimizedBalloonTip()
        {
            OrgTimerNotify.ShowBalloonTip(2000,
                "Org Timer Minimized",
                "Org Timer is still running. Right click the notification icon in the taskbar to exit/restore.",
                ToolTipIcon.Info);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _allowQuit = true;
            this.Close();
        }

        private void OrgTimerNotify_MouseDoubleClick(object sender, MouseEventArgs e) => ShowWindow();
        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e) => HideWindow();
        private void restoreToolStripMenuItem_Click(object sender, EventArgs e) => ShowWindow();

        private void HideWindow() => this.Hide();
        private void ShowWindow() => this.Show();
        private bool IsWindowHidden() => true; //this.WindowState == FormWindowState.Minimized;

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            if (_isPaused)
                Play();
            else
                Pause();
        }
    }
}
