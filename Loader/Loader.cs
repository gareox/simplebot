using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tibia;
using Tibia.Util;

namespace Loader
{
    public partial class Loader : Form
    {
        #region Adresses
        public static uint BList_StepCreatures = 0xA8;
        public static uint BList_MaxCreatures = 250;
        public static uint BList_Start = 0x637CE0; //8.62
        public static uint BList_End = BList_Start + (BList_StepCreatures * BList_MaxCreatures);

        public static uint Status = 0x7BFC84; //8.62

        public static uint Id = 0x637C4C + 12; // 8.62
        #endregion

        public List<Client> clientList = new List<Client>();
        public Loader()
        {
            InitializeComponent();
        }

        List<Client> GetClients()
        {
            List<Client> Clients = new List<Client>();
            foreach (Process process in Process.GetProcesses())
            {
                StringBuilder classname = new StringBuilder();
                WinApi.GetClassName(process.MainWindowHandle, classname, 12);

                if (classname.ToString().Equals("TibiaClient", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (process.MainModule.FileVersionInfo.FileVersion == "8.62")
                    {
                        bool loggedIn = false;
                        string playerName = "";
                        if (Memory.ReadInt32(process.Handle, Status) == 8)
                        {
                            loggedIn = true;
                            int playerId = Memory.ReadInt32(process.Handle, Id);
                            for (int i = 0; i < BList_MaxCreatures; i++)
                                if (Memory.ReadInt32(process.Handle, BList_Start + (BList_StepCreatures * i)) == playerId)
                                    playerName = Memory.ReadString(process.Handle, BList_Start + (BList_StepCreatures * i) + 4);
                        }
                        Clients.Add(new Client(process.Handle, process.Id, "8.62", loggedIn, playerName));
                    }
                }
            }
            return Clients;
        }

        void RefreshList()
        {
            uxClientList.Items.Clear();
            foreach (Client client in clientList)
            {
                if (client.LoggedIn)
                    uxClientList.Items.Add("[PID:" + client.PID + "] " + client.PlayerName);
                else
                    uxClientList.Items.Add("[PID:" + client.PID + "] Offline");
            }
            if (uxClientList.Items.Count > 0)
                uxClientList.SelectedIndex = 0;
        }

        public bool Inject(Client client)
        {
            string filePath = Application.StartupPath + @"\Starter.dll";
            IntPtr remoteAddress = WinApi.VirtualAllocEx(
                    client.Handle, IntPtr.Zero, (uint)filePath.Length,
                    WinApi.AllocationType.Commit | WinApi.AllocationType.Reserve, WinApi.MemoryProtection.ReadWrite);

            // Write the filename to the client's memory
            Memory.WriteStringNoEncoding(client.Handle, remoteAddress.ToInt32(), filePath);

            // Start the remote thread, first loading our library
            IntPtr thread = WinApi.CreateRemoteThread(
                client.Handle, IntPtr.Zero, 0,
                WinApi.GetProcAddress(WinApi.GetModuleHandle("Kernel32"), "LoadLibraryA"),
                remoteAddress, 0, IntPtr.Zero);

            // Free the memory used for the filename
            WinApi.VirtualFreeEx(client.Handle, remoteAddress, (uint)filePath.Length, WinApi.AllocationType.Release);

            return thread.ToInt32() > 0 && remoteAddress.ToInt32() > 0;
        }

        private void uxRefresh_Click(object sender, EventArgs e)
        {
            clientList = GetClients();
            RefreshList();
        }

        private void uxChoose_Click(object sender, EventArgs e)
        {
            if (uxClientList.SelectedIndex > -1)
            {
                if (!Inject(clientList[uxClientList.SelectedIndex]))
                {
                    MessageBox.Show("Error occured \nchoose another client", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
                else
                    Environment.Exit(0);
            }
        }

        private void uxCancel_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Loader_Load(object sender, EventArgs e)
        {
            clientList = GetClients();
            RefreshList();
        }
    }
}
