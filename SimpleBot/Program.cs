using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Tibia;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;

namespace SimpleBot
{
    static class Program
    {
        public static Player Player = null;
        public static Client Client = new Client(Process.GetCurrentProcess());
        public static ModuleHost.ModuleHost ModuleHost;
        public static EventClass EventClass = new EventClass();
        public static string StartupPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath.Replace("SimpleBot.dll", "");
        public static Main MainForm = null;

        public static int EntryPoint(string Argument)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm = new Main();
            Application.Run(MainForm);
            return 0;
        }
    }
}
