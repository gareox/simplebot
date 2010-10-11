using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tibia.Constants;
using Tibia.Objects;
using SimpleBot.ModuleHost.Constants;
using SimpleBot.ModuleHost.Objects;

namespace SimpleBot.ModuleHost.Objects
{
    public class Waypoint
    {
        public WaypointType wType;
        public Location wLocation;
        public uint wItemID;
        public string wTextToSay;
        public SayType wSayType;
        public int wSleepTime1;
        public int wSleepTime2;
        public string wLabelName;
        public ShopAction wShopAction;
        public int wAmount;
        public ConditionalCheckType wCondCheckType;
        public ConditionalVarType wCondVarType;
        public int wCondOutput;

        public Waypoint(WaypointType Type)
        {
            wType = Type;
        }

        public Waypoint(WaypointType Type, Location Location)
        {
            wType = Type;
            wLocation = Location;
        }

        public Waypoint(WaypointType Type, uint ItemID)
        {
            wType = Type;
            wItemID = ItemID;
        }

        public Waypoint(WaypointType Type, SayType SayType, string TextToSay)
        {
            wType = Type;
            wSayType = SayType;
            wTextToSay = TextToSay;
        }

        public Waypoint(WaypointType Type, int SleepTime1, int SleepTime2)
        {
            wType = Type;
            wSleepTime1 = SleepTime1;
            wSleepTime2 = SleepTime2;
        }

        public Waypoint(WaypointType Type, string LabelName)
        {
            wType = Type;
            wLabelName = LabelName;
        }

        public Waypoint(WaypointType Type, ShopAction ShopAction, uint ItemID, int Amount)
        {
            wType = Type;
            wShopAction = ShopAction;
            wItemID = ItemID;
            wAmount = Amount;
        }

        public Waypoint(WaypointType Type, ConditionalVarType VarType, uint ItemID, ConditionalCheckType CheckType, int Output, string GoToLabel)
        {
            wType = Type;
            wCondVarType = VarType;
            wItemID = ItemID;
            wCondCheckType = CheckType;
            wCondOutput = Output;
            wLabelName = GoToLabel;
        }

        public override string ToString()
        {
            return "Type: " + wType.ToString();
        }
    }
}
