using System;
using System.Threading;
using System.Windows.Forms;

namespace OrgTimer
{
    static class Program
    {
        static readonly Mutex SingleInstanceMutex = new Mutex(false, "18a6d808-bd0b-4e86-85d0-76da809e9289");
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (SingleInstanceMutex.WaitOne(TimeSpan.Zero, true))
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new OrgTimerForm());
                }
                finally
                {
                    SingleInstanceMutex.ReleaseMutex();
                }
            }
            else
            {
                MessageBox.Show(@"OrgTimer is already running. In case it's not visible, it might be running in the notification area of the taskbar.");
            }
        }
    }
}
