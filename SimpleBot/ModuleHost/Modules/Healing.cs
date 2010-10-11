using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thr = System.Threading;
using Tibia;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;
using SimpleBot.Misc;
using SimpleBot.ModuleHost;
using SimpleBot.ModuleHost.Objects;

namespace SimpleBot.ModuleHost.Modules
{
    public class Healing : Module
    {
        /*This is a very simplified version of Healing Module
         Normally it should be created on thread,
         but for learning purposes I left it like that*/

        #region Definitions

        Dictionary<string, Timer> Timers = new Dictionary<string, Timer>();

        public List<HealInfo> HealingRules;
        public ushort PotionExhaustion = 700;
        public ushort SpellExhaustion = 1080;
        public ushort SpellPoisonMana = 30;

        #endregion

        public Healing()
        {
            HealingRules = new List<HealInfo>();

            Timers.Add("healer", new Timer(1000, false));
            Timers["healer"].Execute += new Timer.TimerExecution(healer_Execute);
            Timers["healer"].Start();
        }

        void healer_Execute()
        {
            if (Program.Player != null && Enabled)
            {
                foreach (HealInfo currentRule in HealingRules)
                {
                    int sleepTime = 0;
                    switch (currentRule.HealthActionType)
                    {
                        case Constants.ActionType.DoNothing:
                            break;
                        case Constants.ActionType.UseItem:
                            if (currentRule.HealthPercent > Program.Player.HPBar)
                            {
                                Program.Client.Inventory.UseItemOnSelf(currentRule.HealthItemId);
                                sleepTime = PotionExhaustion;
                            }
                            break;
                        case Constants.ActionType.Spell:
                            if (currentRule.HealthPercent > Program.Player.HPBar)
                            {
                                Program.Client.Console.Say(currentRule.HealthSpell);
                                sleepTime = SpellExhaustion;
                            }
                            break;
                    }
                    if (sleepTime != 0)
                        Thr.Thread.Sleep(sleepTime);
                    sleepTime = 0;
                    uint CurrentMana = (Program.Player.Mana * 100) / Program.Player.ManaMax;
                    switch (currentRule.ManaActionType)
                    {
                        case Constants.ActionType.DoNothing:
                            break;
                        case Constants.ActionType.UseItem:
                            if (currentRule.ManaPercent > CurrentMana)
                            {
                                Program.Client.Inventory.UseItemOnSelf(currentRule.ManaItemId);
                                sleepTime = PotionExhaustion;
                            }
                            break;
                        case Constants.ActionType.Spell:
                            if (currentRule.ManaPercent > CurrentMana)
                            {
                                Program.Client.Console.Say(currentRule.ManaSpell);
                                sleepTime = SpellExhaustion;
                            }
                            break;
                    }
                    if (sleepTime != 0)
                    {
                        Thr.Thread.Sleep(sleepTime);
                        break;
                    }
                }
            }
        }
    }
}
