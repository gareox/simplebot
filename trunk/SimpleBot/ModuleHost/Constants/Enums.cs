using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBot.ModuleHost.Constants
{
    #region Healing
    public enum ActionType
    {
        DoNothing,
        UseItem,
        Spell
    }
    #endregion

    #region Cavebot
    public enum ConditionalVarType
    {
        Cap,
        HP,
        MP,
        CountItems,
        Level,
        MLevel,
        Exp,
        ExpLeft
    }

    public enum ConditionalCheckType
    {
        Equals,
        Bigger,
        BiggerorEquals,
        Smaller,
        SmallerorEquals,
        Differs
    }

    public enum WaypointType
    {
        Conditional,
        DepositItem,
        GotoLabel,
        Label,
        Ladder,
        Move,
        ReachAndOpenDepot,
        Rope,
        Say,
        Shop,
        Shovel,
        Sleep,
        StackItems
    }

    public enum SayType
    {
        Default,
        NPC,
        Trade
    }

    public enum ShopAction
    {
        Buy,
        BuyWithBPs,
        Sell
    }
    #endregion
}
