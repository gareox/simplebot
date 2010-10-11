using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinForm = System.Windows.Forms;
using Thr = System.Threading;
using Tibia;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;

namespace SimpleBot
{
    public class EventClass
    {
        public delegate void LoginHandler(DateTime time); 
        public event LoginHandler PlayerLoggedIn;
        public event LoginHandler PlayerLoggedOut;

        public EventClass()
        {
            Timer statusTimer = new Timer(100, false);
            statusTimer.Execute += new Timer.TimerExecution(statusTimer_Execute);
            statusTimer.Start();
        }

        void statusTimer_Execute()
        {
            if (Program.Client.LoggedIn && Program.Player == null)
                PlayerLoggedIn.Invoke(DateTime.Now);
            if (!Program.Client.LoggedIn && Program.Player != null)
                PlayerLoggedOut.Invoke(DateTime.Now);
        }
    }
}
