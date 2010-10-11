using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Tibia;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;
using SimpleBot.Misc;
using System.Reflection;
using SimpleBot.ModuleHost.Constants;
using SimpleBot.ModuleHost.Objects;

namespace SimpleBot
{
    public partial class Main : Form
    {
        #region Definitions

        private Client Client = Program.Client;
        private Player Player = Program.Player;
        private int oldTabID = 0;

        public Forms.Healing Healing;
        public Forms.Extras Extras;
        public Forms.Cavebot Cavebot;

        #endregion

        #region Main & Load

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
            this.FormClosing += new FormClosingEventHandler(Main_FormClosing);
            settingsTab.Selected += new TabControlEventHandler(settingsTab_Selected);

            Healing = new Forms.Healing();
            Extras = new Forms.Extras();
            Cavebot = new Forms.Cavebot();

            Program.EventClass.PlayerLoggedIn += new SimpleBot.EventClass.LoginHandler(EventClass_PlayerLoggedIn);
            Program.EventClass.PlayerLoggedOut += new SimpleBot.EventClass.LoginHandler(EventClass_PlayerLoggedOut);

            Tibia.KeyboardHook.Enable();
            Tibia.KeyboardHook.Add(Keys.F12, ShowHideBotHotkey);

            Client.Process.ProcessorAffinity = (IntPtr)1;

            Program.ModuleHost = new ModuleHost.ModuleHost();
        }

        #endregion

        #region Form Events

        void settingsTab_Selected(object sender, TabControlEventArgs e)
        {
            uxLoadSettings.Text = uxLoadSettings.Text.Replace((oldTabID + 1).ToString(), (e.TabPageIndex + 1).ToString());
            uxSaveSettings.Text = uxSaveSettings.Text.Replace((oldTabID + 1).ToString(), (e.TabPageIndex + 1).ToString());
            uxClearSettings.Text = uxClearSettings.Text.Replace((oldTabID + 1).ToString(), (e.TabPageIndex + 1).ToString());
            oldTabID = e.TabPageIndex;
        }

        bool ShowHideBotHotkey()
        {
            if (Client.Window.IsActive)
            {
                this.ShowFormAtTop();
                if (Client.Window.Title == "Tibia - Press F12 to show the bot")
                    Client.Window.Title = "Tibia";
                return false;
            }
            return true;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Client.Window.Title = "Tibia - Press F12 to show the bot";
            e.Cancel = true;
        }

        #endregion

        #region Log In/Off Events

        void EventClass_PlayerLoggedIn(DateTime dateTime)
        {
            Program.Player = Client.GetPlayer();
            Player = Program.Player;
        }

        void EventClass_PlayerLoggedOut(DateTime dateTime)
        {
            Program.Player = null;
            Player = Program.Player;
        }

        #endregion

        #region Open Forms

        private void uxShowHealing_Click(object sender, EventArgs e)
        {
            Healing.ShowFormAtTop();
        }

        private void uxShowExtras_Click(object sender, EventArgs e)
        {
            Extras.ShowFormAtTop();
        }

        private void uxShowCavebot_Click(object sender, EventArgs e)
        {
            Cavebot.ShowFormAtTop();
        }

        #endregion

        #region Load & Save

        private void uxLoadSettings_Click(object sender, EventArgs e)
        {
            string filePath = string.Format(Program.StartupPath + "Setting-{0}.bs", (oldTabID + 1).ToString());
            if (!File.Exists(filePath))
            {
                MessageBox.Show(string.Format("Setting #{0} doesn't exist", (oldTabID + 1).ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BinaryReader br = new BinaryReader(new StreamReader(filePath).BaseStream);

            #region Healing

            Program.ModuleHost.Healing.HealingRules.Clear();
            int Count = br.ReadInt32();
            for (int i = 0; i < Count; i++)
                Program.ModuleHost.Healing.HealingRules.Add(new ModuleHost.Objects.HealInfo(br.ReadUInt32(), br.ReadUInt32(), br.ReadString(),
                    (ActionType)br.ReadInt32(), br.ReadUInt32(), br.ReadUInt32(), br.ReadString(), (ActionType)br.ReadInt32()));
            Healing.refreshList();

            #endregion

            #region Extras

            Extras.uxCheckEatFood.Checked = br.ReadBoolean();
            Extras.uxCheckFramerateControl.Checked = br.ReadBoolean();
            Extras.uxCheckFullLight.Checked = br.ReadBoolean();
            Extras.uxCheckXRay.Checked = br.ReadBoolean();

            #endregion

            br.Close();
        }

        private void uxSaveSettings_Click(object sender, EventArgs e)
        {
            string filePath = string.Format(Program.StartupPath + "Setting-{0}.bs", (oldTabID + 1).ToString());
            BinaryWriter bw = new BinaryWriter(new StreamWriter(filePath).BaseStream);

            #region Healing

            bw.Write(Program.ModuleHost.Healing.HealingRules.Count);
            foreach (HealInfo currentRule in Program.ModuleHost.Healing.HealingRules)
            {
                bw.Write(currentRule.HealthPercent);
                bw.Write(currentRule.HealthItemId);
                bw.Write(currentRule.HealthSpell);
                bw.Write((int)currentRule.HealthActionType);
                bw.Write(currentRule.ManaPercent);
                bw.Write(currentRule.ManaItemId);
                bw.Write(currentRule.ManaSpell);
                bw.Write((int)currentRule.ManaActionType);
            }

            #endregion

            #region Extras

            bw.Write(Extras.uxCheckEatFood.Checked);
            bw.Write(Extras.uxCheckFramerateControl.Checked);
            bw.Write(Extras.uxCheckFullLight.Checked);
            bw.Write(Extras.uxCheckXRay.Checked);

            #endregion

            bw.Close();
        }

        private void uxClearSettings_Click(object sender, EventArgs e)
        {
            string filePath = string.Format(Program.StartupPath + "Setting-{0}.bs", (oldTabID + 1).ToString());
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        #endregion
    }
}
