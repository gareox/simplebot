using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleBot.ModuleHost;
using SimpleBot.ModuleHost.Objects;
using Tibia.Constants;
using Tibia.Objects;
using Tibia.Util;

namespace SimpleBot.ModuleHost.Modules
{
    public class Extras : Module
    {
        #region Definitions
        private bool xRay = false;
        private bool fullLight = false;
        private Dictionary<string, Timer> Timers = new Dictionary<string, Timer>();

        //List to store selected food Ids to eat
        public List<uint> foodList;
        #endregion

        public Extras()
        {
            Timers.Add("eatFood", new Timer(10000, false));
            Timers["eatFood"].Execute += new Timer.TimerExecution(eatFood_Execute);
            
            Timers.Add("framerateControl", new Timer(1000, false));
            Timers["framerateControl"].Execute += new Timer.TimerExecution(framerateControl_Execute);
        }

        #region Set Functions
        public bool XRay
        {
            get
            {
                return xRay;
            }
            set
            {
                xRay = value;

                if (value)
                    Program.Client.Map.NameSpyOn();
                else
                    Program.Client.Map.NameSpyOff();
            }
        }

        public bool FullLight
        {
            get
            {
                return fullLight;
            }
            set
            {
                fullLight = value;

                if (value)
                    Program.Client.Map.FullLightOn();
                else
                    Program.Client.Map.FullLightOff();
            }
        }

        public bool EatFood
        {
            get
            {
                return Timers["eatFood"].State == TimerState.Running;
            }
            set
            {
                if (value)
                    Timers["eatFood"].Start();
                else
                    Timers["eatFood"].Stop();
            }
        }

        public bool FramerateControl
        {
            get
            {
                return Timers["framerateControl"].State == TimerState.Running;
            }
            set
            {
                if (value)
                    Timers["framerateControl"].Start();
                else
                    Timers["framerateControl"].Stop();
            }
        }

        #endregion

        #region Timers
        void eatFood_Execute()
        {
            if (Program.Player != null)
            {
                Item i = Program.Client.Inventory.GetItems().FirstOrDefault(food => foodList.Contains(food.Id));
                if (i != null)
                    i.Use();
            }
        }

        void framerateControl_Execute()
        {
            double fpsLimit = 50;
            if (!Program.Client.Window.IsActive)
                fpsLimit = 10;
            if (Program.Client.Window.IsMinimized)
                fpsLimit = 0.5;
            if (Program.Client.Window.FPSLimit != fpsLimit)
                Program.Client.Window.FPSLimit = fpsLimit;
        }
        #endregion
    }
}
