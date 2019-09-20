using System.Drawing;

namespace OrgTimer
{
    internal class TimerStateDetails
    {
        public int IntervalInSeconds { get; set; }
        public Color Colour { get; set; }

        public TimerStateDetails(int intervalInSeconds, Color colour)
        {
            this.IntervalInSeconds = intervalInSeconds;
            this.Colour = colour == null ? Color.SeaShell: colour;
        }
    }
}