using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace OrgTimer
{
    public partial class OrgTimerForm : Form
    {
        enum TimerState
        {
            Working,
            Chilling,
            Stopped
        }
        int _currentIntervalTimeInSecs;
        private readonly int _chillIntervalInSecs;
        private readonly int _workIntervalInSecs;
        private readonly string _timeFormat;
        TimerState _timerState;

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
            string timeLeft = TimeSpan.FromSeconds(--_currentIntervalTimeInSecs).ToString(_timeFormat);
            ActionButton.Text = _timerState.ToString() + " " + timeLeft;
            if (_currentIntervalTimeInSecs == 0)
            {
                ActionButton.BackColor = Color.Red;
            }
            JobTimer.Start();
        }

        private void OrgTimerNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
