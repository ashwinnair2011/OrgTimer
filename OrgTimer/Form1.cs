using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrgTimer
{
    public partial class Form1 : Form
    {
        enum TimerState
        {
            Working,
            Chilling,
            Stopped
        }
        const int WorkIntervalInSecs = 600;
        const int ChillIntervalInSecs = 120;
        int _currentIntervalTimeInSecs;
        TimerState _timerState;

        public Form1()
        {
            InitializeComponent();
            _timerState = TimerState.Stopped;
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
                    _currentIntervalTimeInSecs = WorkIntervalInSecs;
                    JobTimer.Start();
                    break;
                case TimerState.Working:
                    //start timer for 2 minutes
                    _timerState = TimerState.Chilling;
                    _currentIntervalTimeInSecs = ChillIntervalInSecs;
                    break;
            }
        }

        private void JobTimer_Tick(object sender, EventArgs e)
        {
            JobTimer.Stop();
            string timeLeft = TimeSpan.FromSeconds(--_currentIntervalTimeInSecs).ToString(@"mm\:ss");
            ActionButton.Text = _timerState.ToString() + " " + timeLeft;
            if (_currentIntervalTimeInSecs == 0)
            {
                _timerState = TimerState.Stopped;
                ActionButton.BackColor = Color.Red;
                return;
            }
            JobTimer.Start();
        }

        private void OrgTimerNotify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
