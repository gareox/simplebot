using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBot.ModuleHost
{
    public class ModuleHost
    {
        public Modules.Extras Extras = new Modules.Extras();
        public Modules.Healing Healing = new Modules.Healing();
        public Modules.Cavebot Cavebot = new Modules.Cavebot();

        public ModuleHost(){ }
    }
}
