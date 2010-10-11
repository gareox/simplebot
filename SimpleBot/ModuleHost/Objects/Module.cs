using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleBot.ModuleHost.Objects
{
    public partial class Module : ModuleInterface
    {
        public bool Enabled = true;

        public virtual void Enable()
        {
            Enabled = true;
        }

        public virtual void Disable()
        {
            Enabled = false;
        }
    }
}
