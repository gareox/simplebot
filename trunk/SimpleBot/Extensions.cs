using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleBot.Misc
{
    public static class Extensions
    {
        public static void ShowFormAtTop(this Form f)
        {
            if (!f.Visible)
                f.Show();
            f.TopMost = true;
            f.TopMost = false;
        }
    }
}
