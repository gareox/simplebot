using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tibia.Constants;
using Tibia.Objects;
using SimpleBot.ModuleHost.Constants;

namespace SimpleBot.ModuleHost.Objects
{
    public class HealInfo
    {
        public uint HealthPercent;
        public uint HealthItemId;
        public string HealthSpell;
        public ActionType HealthActionType;

        public uint ManaPercent;
        public uint ManaItemId;
        public string ManaSpell;
        public ActionType ManaActionType;
        
        public HealInfo(uint healthPercent, uint healthItemId, string healthSpell, ActionType healthActionType,
            uint manaPercent, uint manaItemId, string manaSpell, ActionType manaActionType)
        {
            HealthPercent = healthPercent;
            HealthItemId = healthItemId;
            HealthSpell = healthSpell;
            HealthActionType = healthActionType;

            ManaPercent = manaPercent;
            ManaItemId = manaItemId;
            ManaSpell = manaSpell;
            ManaActionType = manaActionType;
        }
    }
}
