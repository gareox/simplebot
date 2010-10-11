using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBot;
using SimpleBot.Misc;
using SimpleBot.ModuleHost;
using SimpleBot.ModuleHost.Constants;
using SimpleBot.ModuleHost.Objects;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;
using Thr = System.Threading;
using Wfrm = System.Windows.Forms;

namespace SimpleBot.ModuleHost.Modules
{
    public class Cavebot : Module
    {
        Dictionary<string, Timer> Timers = new Dictionary<string, Timer>();

        public int iterator = 0;
        public List<Waypoint> Waypoints = new List<Waypoint>();
        public Item Pick = Items.Tool.Pick;
        public Item Rope = Items.Tool.Rope;
        public Item Shovel = Items.Tool.Shovel;

        public Cavebot()
        {
        }

        public bool CaveRunning
        {
            get
            {
                return Timers.ContainsKey("caveTimer");
            }
            set
            {
                if (value)
                {
                    if (!Timers.ContainsKey("caveTimer"))
                    {
                        Timers.Add("caveTimer", new Timer(1000, false));
                        Timers["caveTimer"].Execute += new Timer.TimerExecution(caveTimer_Execute);
                        Timers["caveTimer"].Start();
                    }
                }
                else
                {
                    if (Timers.ContainsKey("caveTimer"))
                    {
                        Timers["caveTimer"].Stop();
                        Timers.Remove("caveTimer");
                    }
                }
            }
        }

        private bool PerformWaypoint(Waypoint wpt)
        {
            if (!Enabled)
                return false;

            if (wpt == null)
            {
                iterator++;
                return false;
            }

            if (Program.Player.Z != wpt.wLocation.Z)
                return true;

            switch (wpt.wType)
            {
                case Constants.WaypointType.Conditional:
                    return true;
                case Constants.WaypointType.DepositItem:
                    Container container = Program.Client.Inventory.GetContainers().FirstOrDefault(c => c.Name == "Depot Chest");
                    if (container == null)
                        return false;
                    if (!container.HasFreeSpace())
                        return false;
                    ItemLocation itLoc = new ItemLocation();
                    itLoc.Type = ItemLocationType.Container;
                    itLoc.ContainerId = (byte)container.Id;
                    List<Container> cont = Program.Client.Inventory.GetContainers().ToList();
                    cont.Remove(container);
                    foreach (Container c in cont)
                    {
                        foreach (Item i in c.GetItems())
                            if (i.Id == wpt.wItemID)
                                i.Move(itLoc);
                    }
                    return true;
                case Constants.WaypointType.GotoLabel:
                    iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName);
                    return true;
                case Constants.WaypointType.Label:
                    return true;
                case Constants.WaypointType.Ladder:
                    uint oldZ = Program.Player.Z;
                    Tile ladderTile = Program.Client.Map.GetTile(wpt.wLocation);
                    ladderTile.Items.FirstOrDefault(tItem => tItem.LensHelp == Tibia.Addresses.DatItem.Help.IsLadder).Use();
                    if (Program.Player.Z != oldZ)
                        return true;
                    else
                        return false;
                case Constants.WaypointType.Move:
                    if (Program.Player.Location != wpt.wLocation)
                    {
                        if (!Program.Player.IsWalking)
                            Program.Player.GoTo = wpt.wLocation;
                        return false;
                    }
                    return true;
                case Constants.WaypointType.ReachAndOpenDepot:
                    return true;
                case Constants.WaypointType.Rope:
                    oldZ = Program.Player.Z;
                    Tile ropeTile = Program.Client.Map.GetTile(wpt.wLocation);
                    Program.Client.Inventory.UseItemOnTile(Rope.Id, ropeTile);
                    if (Program.Player.Z != oldZ)
                        return true;
                    else
                        return false;
                case Constants.WaypointType.Say:
                    return true;
                case Constants.WaypointType.Shop:
                    if (wpt.wShopAction == Constants.ShopAction.Buy)
                        Tibia.Packets.Outgoing.ShopBuyPacket.Send(Program.Client, (ushort)wpt.wItemID, (byte)0, (byte)wpt.wAmount, false);
                    else if (wpt.wShopAction == Constants.ShopAction.BuyWithBPs)
                        Tibia.Packets.Outgoing.ShopBuyPacket.Send(Program.Client, (ushort)wpt.wItemID, (byte)0, (byte)wpt.wAmount, true);
                    else if (wpt.wShopAction == Constants.ShopAction.Sell)
                        Tibia.Packets.Outgoing.ShopSellPacket.Send(Program.Client, (ushort)wpt.wItemID, (byte)0, (byte)wpt.wAmount);
                    return true;
                case Constants.WaypointType.Shovel:
                    Tile shovelTile = Program.Client.Map.GetTile(wpt.wLocation);
                    Program.Client.Inventory.UseItemOnTile(Shovel.Id, shovelTile);
                    return true;
                case Constants.WaypointType.Sleep:
                    return true;
                case Constants.WaypointType.StackItems:
                    Program.Client.Inventory.StackItems();
                    return true;
            }
            return true;
        }

        private void caveTimer_Execute()
        {
            if (!Enabled || Program.Player == null || !CaveRunning || Waypoints.Count == 0)
                return;

            if (Program.Player.IsWalking)
                return;

            if (iterator >= Waypoints.Count)
                iterator = 0;

            Waypoint wpt = Waypoints[iterator];
            if (wpt == null)
            {
                iterator++;
                Program.MainForm.Cavebot.DontChangeIterator = true;
                try { Program.MainForm.Cavebot.uxWaypointsList.SelectedIndex = iterator; }
                catch { Program.MainForm.Cavebot.uxWaypointsList.SelectedIndex = 0; }
                Program.MainForm.Cavebot.DontChangeIterator = false;
                return;
            }

            if (wpt.wType == WaypointType.Sleep)
            {
                Thr.Thread.Sleep(new Random().Next(wpt.wSleepTime1, wpt.wSleepTime2));
            }
            else if (wpt.wType == WaypointType.Conditional)
            {
                #region Conditionals

                #region HP
                if (wpt.wCondVarType == ConditionalVarType.HP)
                {
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (Program.Player.Health >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (Program.Player.Health > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (Program.Player.Health != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (Program.Player.Health == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (Program.Player.Health <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (Program.Player.Health >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region MP
                if (wpt.wCondVarType == ConditionalVarType.MP)
                {
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (Program.Player.Mana >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (Program.Player.Mana > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (Program.Player.Mana != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (Program.Player.Mana == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (Program.Player.Mana <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (Program.Player.Mana >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region Cap
                if (wpt.wCondVarType == ConditionalVarType.Cap)
                {
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (Program.Player.CapacityVisible >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (Program.Player.CapacityVisible > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (Program.Player.CapacityVisible != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (Program.Player.CapacityVisible == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (Program.Player.CapacityVisible <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (Program.Player.CapacityVisible >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region Lvl
                if (wpt.wCondVarType == ConditionalVarType.Level)
                {
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (Program.Player.Level >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (Program.Player.Level > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (Program.Player.Level != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (Program.Player.Level == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (Program.Player.Level <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (Program.Player.Level >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region MLvl
                if (wpt.wCondVarType == ConditionalVarType.MLevel)
                {
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (Program.Player.MagicLevel >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (Program.Player.MagicLevel > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (Program.Player.MagicLevel != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (Program.Player.MagicLevel == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (Program.Player.MagicLevel <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (Program.Player.MagicLevel >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region CountItems
                if (wpt.wCondVarType == ConditionalVarType.CountItems)
                {
                    int itemCount = Program.Client.Inventory.CountItems(wpt.wItemID);
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (itemCount >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (itemCount > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (itemCount != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (itemCount == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (itemCount <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (itemCount >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region Exp
                if (wpt.wCondVarType == ConditionalVarType.Exp)
                {
                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (Program.Player.Experience >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (Program.Player.Experience > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (Program.Player.Experience != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (Program.Player.Experience == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (Program.Player.Experience <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (Program.Player.Experience >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #region ExpLeft
                if (wpt.wCondVarType == ConditionalVarType.ExpLeft)
                {
                    long expForLevel = Tibia.Calculate.ExpForLevel((int)Program.Player.Level + 1);
                    long expLeft = expForLevel - Program.Player.Experience;

                    if (wpt.wCondCheckType == ConditionalCheckType.BiggerorEquals)
                    {
                        if (expLeft >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Bigger)
                    {
                        if (expLeft > wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Differs)
                    {
                        if (expLeft != wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.Equals)
                    {
                        if (expLeft == wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType == ConditionalCheckType.SmallerorEquals)
                    {
                        if (expLeft <= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                    else if (wpt.wCondCheckType < ConditionalCheckType.Smaller)
                    {
                        if (expLeft >= wpt.wCondOutput)
                            iterator = Waypoints.FindIndex(w => w.wLabelName == wpt.wLabelName && w.wType == WaypointType.Label);
                    }
                }
                #endregion

                #endregion
            }
            else if (wpt.wType == WaypointType.Say)
            {
                if (wpt.wSayType == Constants.SayType.Default)
                    Program.Client.Console.Say(wpt.wTextToSay);
                else if (wpt.wSayType == Constants.SayType.NPC)
                    Program.Client.Console.Say(ChatMessage.CreateNormalMessage(wpt.wTextToSay, SpeechType.PrivatePlayerToNPC));
                else if (wpt.wSayType == Constants.SayType.Trade)
                    Program.Client.Console.Say(ChatMessage.CreateChannelMessage(wpt.wTextToSay, ChatChannel.Trade));
            }

            if (PerformWaypoint(wpt))
            {
                iterator++;
                Program.MainForm.Cavebot.DontChangeIterator = true;
                try { Program.MainForm.Cavebot.uxWaypointsList.SelectedIndex = iterator; }
                catch { Program.MainForm.Cavebot.uxWaypointsList.SelectedIndex = 0; }
                Program.MainForm.Cavebot.DontChangeIterator = false;
            }
        }
    }
}
