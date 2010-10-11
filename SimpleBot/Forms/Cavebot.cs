using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Thr = System.Threading;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;
using SimpleBot.ModuleHost.Constants;
using SimpleBot.ModuleHost.Objects;

namespace SimpleBot.Forms
{
    public partial class Cavebot : Form
    {
        #region Definitions & Load
        private ConditionalCheckType condCheckType = ConditionalCheckType.Equals;
        private ConditionalVarType condVarType = ConditionalVarType.Cap;
        private SayType sayType = SayType.Default;
        private int xDiff = 0;
        private int yDiff = 0;

        public bool DontChangeIterator = false;

        public Cavebot()
        {
            InitializeComponent();
        }

        private void Cavebot_Load(object sender, EventArgs e)
        {
            uxWptSayTypes.SelectedIndex = 0;
            uxConditionalCheckType.SelectedIndex = 0;
            uxConditionalVarType.SelectedIndex = 0;
            uxWaypointDiffType.SelectedIndex = 0;
            this.FormClosing += delegate(object sender2, FormClosingEventArgs fcea)
            {
                fcea.Cancel = true;
                this.Hide();
            };

            uxConditionalItemID.TextChanged += new EventHandler(CheckNumbers);
            uxWptDepositItemID.TextChanged += new EventHandler(CheckNumbers);
            uxWptSleepTime1.TextChanged += new EventHandler(CheckNumbers);
            uxWptSleepTime2.TextChanged += new EventHandler(CheckNumbers);
        }

        /// <summary>
        /// Checks TextBox if all characters all digits
        /// Thanks to Wronq
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckNumbers(object sender, EventArgs e)
        {
            TextBox txtBox = (TextBox)sender;
            string txt = txtBox.Text;
            int Out;
            for (int i = 0; i < txt.Length; i++)
            {
                if (!Int32.TryParse(txt[i].ToString(), out Out))
                    txt = txt.Replace(txt[i].ToString(), "");
            }
            txtBox.Text = txt;
            txtBox.SelectionStart = txt.Length;
        }

        #endregion

        #region Types Changing

        private void uxWaypointDiffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (uxWaypointDiffType.SelectedIndex)
            {
                case 0: xDiff = 0; yDiff = 0; break;
                case 1: xDiff = 0; yDiff = -1; break;
                case 2: xDiff = -1; yDiff = -1; break;
                case 3: xDiff = 1; yDiff = -1; break;
                case 4: xDiff = -1; yDiff = 0; break;
                case 5: xDiff = 1; yDiff = 0; break;
                case 6: xDiff = 0; yDiff = 1; break;
                case 7: xDiff = -1; yDiff = 1; break;
                case 8: xDiff = 1; yDiff = 1; break;
            }
        }

        private void uxWptSayTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            sayType = (SayType)uxWptSayTypes.SelectedIndex;
        }

        private void uxConditionalVarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            condVarType = (ConditionalVarType)uxConditionalVarType.SelectedIndex;
            uxConditionalItemIDLabel.Visible = condVarType == ConditionalVarType.CountItems;
            uxConditionalItemID.Visible = condVarType == ConditionalVarType.CountItems;
        }

        private void uxConditionalCheckType_SelectedIndexChanged(object sender, EventArgs e)
        {
            condCheckType = (ConditionalCheckType)uxConditionalCheckType.SelectedIndex;
        }

        #endregion

        #region Add Waypoints

        private void uxWptAddMove_Click(object sender, EventArgs e)
        {
            if (Program.Player == null)
                return;
            int X = Program.Player.Location.X;
            int Y = Program.Player.Location.Y;
            int Z = Program.Player.Location.Z;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Move, new Location(X + xDiff,
                Y + yDiff, Z)));
            refreshList();
        }

        private void uxWptAddRope_Click(object sender, EventArgs e)
        {
            if (Program.Player == null)
                return;
            int X = Program.Player.Location.X;
            int Y = Program.Player.Location.Y;
            int Z = Program.Player.Location.Z;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Rope, new Location(Z + xDiff,
                Y + yDiff, Z)));
            refreshList();
        }

        private void uxWptAddLadder_Click(object sender, EventArgs e)
        {
            if (Program.Player == null)
                return;
            int X = Program.Player.Location.X;
            int Y = Program.Player.Location.Y;
            int Z = Program.Player.Location.Z;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Ladder, new Location(Z + xDiff,
                Y + yDiff, Z)));
            refreshList();
        }

        private void uxWptAddShovel_Click(object sender, EventArgs e)
        {
            if (Program.Player == null)
                return;
            int X = Program.Player.Location.X;
            int Y = Program.Player.Location.Y;
            int Z = Program.Player.Location.Z;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Shovel, new Location(Z + xDiff,
                Y + yDiff, Z)));
            refreshList();
        }

        private void uxWptAddLabel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uxWptLabelName.Text))
                return;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Label, uxWptLabelName.Text));
            refreshList();
        }

        private void uxWptAddStackItems_Click(object sender, EventArgs e)
        {
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.StackItems));
            refreshList();
        }

        private void uxWptAddSay_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uxWptSayText.Text))
                return;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Say, sayType, uxWptSayText.Text));
            refreshList();
        }

        private void uxWptAddSleep_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(uxWptSleepTime1.Text) || string.IsNullOrEmpty(uxWptSleepTime2.Text))
                return;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Sleep, int.Parse(uxWptSleepTime1.Text),
                int.Parse(uxWptSleepTime2.Text)));
            refreshList();
        }

        private void uxWptAddDepositItem_Click(object sender, EventArgs e)
        {
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.DepositItem, uint.Parse(uxWptDepositItemID.Text)));
            refreshList();
        }

        private void uxWptListAddConditional_Click(object sender, EventArgs e)
        {
            uint ItemID = condVarType == ConditionalVarType.CountItems ? uint.Parse(uxConditionalItemID.Text) : (uint)0;
            Program.ModuleHost.Cavebot.Waypoints.Add(new Waypoint(WaypointType.Conditional, condVarType, ItemID, condCheckType,
                int.Parse(uxConditionalOutput.Text), uxConditionalLabelName.Text));
            refreshList();
        }

        #endregion

        private void uxCavebotEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Program.ModuleHost.Cavebot.CaveRunning = uxCavebotEnabled.Checked;
        }

        #region Waypoint List Events

        private void refreshList()
        {
            uxWaypointsList.Items.Clear();
            foreach (Waypoint wpt in Program.ModuleHost.Cavebot.Waypoints)
            {
                switch (wpt.wType)
                {
                    case WaypointType.Conditional:
                        string conditionalText = "";
                        if (wpt.wItemID != 0)
                            conditionalText = string.Format("if {0} {1} {2} {3} :{4}", varTypeToString(wpt.wCondVarType), wpt.wItemID,
                                checkTypeToString(wpt.wCondCheckType), wpt.wCondOutput, wpt.wLabelName);
                        else
                            conditionalText = string.Format("if {0} {1} {2} :{3}", varTypeToString(wpt.wCondVarType), 
                                checkTypeToString(wpt.wCondCheckType), wpt.wCondOutput, wpt.wLabelName);
                        uxWaypointsList.Items.Add(conditionalText);
                        break;
                    case WaypointType.DepositItem:
                        string depositText = string.Format("deposit {0}", wpt.wItemID);
                        uxWaypointsList.Items.Add(depositText);
                        break;
                    case WaypointType.GotoLabel:
                        string gotoLabelText = string.Format("gotolabel {0}", wpt.wLabelName);
                        uxWaypointsList.Items.Add(gotoLabelText);
                        break;
                    case WaypointType.Label:
                        string labelText = string.Format(":{0}", wpt.wLabelName);
                        uxWaypointsList.Items.Add(labelText);
                        break;
                    case WaypointType.Ladder:
                        string ladderText = string.Format("ladder {0},{1},{2}", wpt.wLocation.X, wpt.wLocation.Y, wpt.wLocation.Z);
                        uxWaypointsList.Items.Add(ladderText);
                        break;
                    case WaypointType.Move:
                        string moveText = string.Format("move {0},{1},{2}", wpt.wLocation.X, wpt.wLocation.Y, wpt.wLocation.Z);
                        uxWaypointsList.Items.Add(moveText);
                        break;
                    case WaypointType.ReachAndOpenDepot:
                        break;
                    case WaypointType.Rope:
                        string ropeText = string.Format("rope {0},{1},{2}", wpt.wLocation.X, wpt.wLocation.Y, wpt.wLocation.Z);
                        uxWaypointsList.Items.Add(ropeText);
                        break;
                    case WaypointType.Say:
                        string sayText = string.Format("say {0} {1}", wpt.wSayType.ToString().ToLower(), wpt.wTextToSay);
                        uxWaypointsList.Items.Add(sayText);
                        break;
                    case WaypointType.Shop:
                        string shopText = string.Format("shop {0} {1} {2}", wpt.wShopAction.ToString().ToLower(), wpt.wItemID, wpt.wAmount);
                        uxWaypointsList.Items.Add(shopText);
                        break;
                    case WaypointType.Shovel:
                        string shovelText = string.Format("shovel {0},{1},{2}", wpt.wLocation.X, wpt.wLocation.Y, wpt.wLocation.Z);
                        uxWaypointsList.Items.Add(shovelText);
                        break;
                    case WaypointType.Sleep:
                        string sleepText = string.Format("sleep {0}..{1}", wpt.wSleepTime1, wpt.wSleepTime2);
                        uxWaypointsList.Items.Add(sleepText);
                        break;
                    case WaypointType.StackItems:
                        string stackText = "stackitems";
                        uxWaypointsList.Items.Add(stackText);
                        break;
                }
            }
        }

        private void uxWaypointsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DontChangeIterator)
                return;
            else
                Program.ModuleHost.Cavebot.iterator = uxWaypointsList.SelectedIndex;
        }

        private void uxWptListClear_Click(object sender, EventArgs e)
        {
            Program.ModuleHost.Cavebot.Waypoints.Clear();
            refreshList();
        }

        private void uxWptListRemove_Click(object sender, EventArgs e)
        {
            int selectedIndex = uxWaypointsList.SelectedIndex;
            if (selectedIndex > -1)
                Program.ModuleHost.Cavebot.Waypoints.RemoveAt(selectedIndex);
            refreshList();
            if (Program.ModuleHost.Cavebot.Waypoints.Count > selectedIndex)
                uxWaypointsList.SelectedIndex = selectedIndex;
            else
                uxWaypointsList.SelectedIndex = Program.ModuleHost.Cavebot.Waypoints.Count - 1;
        }

        #endregion

        #region Enumerations Conversion

        private ConditionalVarType stringToVarType(string varTypeString)
        {
            switch (varTypeString)
            {
                case "cap":
                    return ConditionalVarType.Cap;
                case "countitems":
                    return ConditionalVarType.CountItems;
                case "exp":
                    return ConditionalVarType.Exp;
                case "expleft":
                    return ConditionalVarType.ExpLeft;
                case "hp":
                    return ConditionalVarType.HP;
                case "level":
                    return ConditionalVarType.HP;
                case "mlevel":
                    return ConditionalVarType.MLevel;
                case "mp":
                    return ConditionalVarType.MP;
                default:
                    return ConditionalVarType.Cap;
            }
            //return ConditionalVarType.Cap;
        }

        private string varTypeToString(ConditionalVarType varType)
        {
            return varType.ToString().ToLower();
        }

        private ConditionalCheckType stringToCheckType(string checkTypeString)
        {
            switch (checkTypeString)
            {
                case "==":
                    return ConditionalCheckType.Equals;
                case ">":
                    return ConditionalCheckType.Bigger;
                case ">=":
                    return ConditionalCheckType.BiggerorEquals;
                case "<":
                    return ConditionalCheckType.Smaller;
                case "<=":
                    return ConditionalCheckType.SmallerorEquals;
                case "!=":
                    return ConditionalCheckType.Differs;
                default:
                    return ConditionalCheckType.Equals;
            }
            //return ConditionalVarType.Cap;
        }

        private string checkTypeToString(ConditionalCheckType checkType)
        {
            switch (checkType)
            {
                case ConditionalCheckType.Equals:
                    return "==";
                case ConditionalCheckType.Bigger:
                    return ">";
                case ConditionalCheckType.BiggerorEquals:
                    return ">=";
                case ConditionalCheckType.Smaller:
                    return "<";
                case ConditionalCheckType.SmallerorEquals:
                    return "<=";
                case ConditionalCheckType.Differs:
                    return "!=";
                default:
                    return "==";
            }
        }

        #endregion

        private void uxWptListLoad_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader file = new StreamReader(openFile.FileName);

                string line;
                Waypoint currentWpt;
                while ((line = file.ReadLine()) != null)
                {
                    currentWpt = FromTextToWpt(line);
                    if (currentWpt != null)
                        Program.ModuleHost.Cavebot.Waypoints.Add(currentWpt);
                    else
                        MessageBox.Show(string.Format("Couldn't understand: {0}", line));
                }

                file.Close();
                refreshList();
            }
        }

        private void uxWptListSave_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                refreshList();
                System.IO.StreamWriter file = new System.IO.StreamWriter(saveFile.FileName);

                foreach (object item in uxWaypointsList.Items)
                    file.WriteLine(item.ToString());

                file.Close();
            }
        }

        private Waypoint FromTextToWpt(string waypointText)
        {
            if (waypointText.StartsWith("move "))
            {
                waypointText = waypointText.Replace("move ", "");
                string[] xyz = waypointText.Split(new char[] { ',' });
                Location loc = new Location(int.Parse(xyz[0]), int.Parse(xyz[1]), int.Parse(xyz[2]));
                return new Waypoint(WaypointType.Move, loc);
            }
            else if (waypointText.StartsWith("rope "))
            {
                waypointText = waypointText.Replace("rope ", "");
                string[] xyz = waypointText.Split(new char[] { ',' });
                Location loc = new Location(int.Parse(xyz[0]), int.Parse(xyz[1]), int.Parse(xyz[2]));
                return new Waypoint(WaypointType.Rope, loc);
            }
            else if (waypointText.StartsWith("shovel "))
            {
                waypointText = waypointText.Replace("shovel ", "");
                string[] xyz = waypointText.Split(new char[] { ',' });
                Location loc = new Location(int.Parse(xyz[0]), int.Parse(xyz[1]), int.Parse(xyz[2]));
                return new Waypoint(WaypointType.Shovel, loc);
            }
            else if (waypointText.StartsWith(":"))
            {
                waypointText = waypointText.Replace(":", "");
                return new Waypoint(WaypointType.Label, waypointText);
            }
            else if (waypointText == "stackitems")
                return new Waypoint(WaypointType.StackItems);
            else if (waypointText.StartsWith("say "))
            {
                waypointText = waypointText.Replace("say ", "");
                if (waypointText.StartsWith("default "))
                {
                    waypointText = waypointText.Replace("default ", "");
                    return new Waypoint(WaypointType.Say, SayType.Default, waypointText);
                }
                else if (waypointText.StartsWith("npc "))
                {
                    waypointText = waypointText.Replace("npc ", "");
                    return new Waypoint(WaypointType.Say, SayType.NPC, waypointText);
                }
                else
                {
                    waypointText = waypointText.Replace("trade ", "");
                    return new Waypoint(WaypointType.Say, SayType.Trade, waypointText);
                }
            }
            else if (waypointText.StartsWith("sleep "))
            {
                waypointText = waypointText.Replace("sleep ", "");
                waypointText = waypointText.Replace("..", " ");
                string[] sleepTimes = waypointText.Split(new char[] { ' ' });
                return new Waypoint(WaypointType.Sleep, int.Parse(sleepTimes[0]), int.Parse(sleepTimes[1]));
            }
            else if (waypointText.StartsWith("deposititem "))
            {
                waypointText = waypointText.Replace("deposititem ", "");
                return new Waypoint(WaypointType.DepositItem, uint.Parse(waypointText));
            }
            else if (waypointText.StartsWith("if "))
            {
                waypointText = waypointText.Replace("if ", "");
                if (waypointText.StartsWith("countitems "))
                {
                    string[] parameters = waypointText.Split(new char[] { ' ' });
                    return new Waypoint(WaypointType.Conditional, stringToVarType(parameters[0]), uint.Parse(parameters[1]),
                        stringToCheckType(parameters[2]), int.Parse(parameters[3]), parameters[4].Replace(":", ""));
                }
                else
                {
                    string[] parameters = waypointText.Split(new char[] { ' ' });
                    return new Waypoint(WaypointType.Conditional, stringToVarType(parameters[0]), 0,
                        stringToCheckType(parameters[1]), int.Parse(parameters[2]), parameters[3].Replace(":", ""));
                }
            }
            else
            {
                Waypoint nullWpt = null;
                return nullWpt;
            }
        }
    }
}
