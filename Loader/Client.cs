using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Loader
{
    public class Client
    {
        public IntPtr Handle;
        public int PID;
        public string Version;
        public bool LoggedIn;
        public string PlayerName;

        public Client(IntPtr handle, int pid, string version, bool loggedin, string playername)
        {
            Handle = handle;
            PID = pid;
            Version = version;
            LoggedIn = loggedin;
            PlayerName = playername;
        }

        public Client GetClients(int pid)
        {
            return new Client((IntPtr)1, 1, "", false, "");
        }
    }
}
