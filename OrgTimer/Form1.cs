using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace OrgTimer
{
    public partial class Form1 : Form
    {
        enum TimerState
        {
            Working,
            Chilling,
            Stopped,
            Overtime
        }
        int _workIntervalInSecs;
        int _chillIntervalInSecs;
        int _currentIntervalTimeInSecs;
        TimerState _timerState;

        public Form1()
        {
            InitializeComponent();
            _timerState = TimerState.Stopped;
            _workIntervalInSecs = Convert.ToInt32(ConfigurationManager.AppSettings["WorkIntervalInSecs"]);
            _chillIntervalInSecs = Convert.ToInt32(ConfigurationManager.AppSettings["ChillIntervalInSecs"]);
        }

        private void ActionButton_Click(object sender, EventArgs e)
        {
            switch (_timerState)
            {
                case TimerState.Stopped:
                case TimerState.Chilling:
                    //start timer for 10 minutes
                    ActionButton.BackColor = Color.SeaShell;
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
            if (_timerState == TimerState.Overtime) {
            }
            else {
                string timeLeft = TimeSpan.FromSeconds(--_currentIntervalTimeInSecs).ToString(@"mm\:ss");
                ActionButton.Text = _timerState.ToString() + " " + timeLeft;
                if (_currentIntervalTimeInSecs == 0)
                {
                    ActionButton.BackColor = Color.Red;
                }
            }
            JobTimer.Start();
        }

        private void OrgTimerNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
