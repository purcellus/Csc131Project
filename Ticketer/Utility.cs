using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Ticketer
{
    public class Utility
    {
        public static bool TextHasNoData(TextBox textBox)
        {
            return textBox.Text == null || textBox.Text.Trim() == "";
        }
    }
}
