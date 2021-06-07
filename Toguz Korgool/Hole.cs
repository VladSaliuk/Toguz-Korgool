using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Toguz_Korgool_0._5
{
    public class Hole
    {
        public TextBlock label;
        public int Player;
        public bool isAce;

        public Hole(TextBlock inputLabel)
        {
            label = inputLabel;
            Player = Convert.ToInt32(label.Name.Replace("Label", "")) <= 9 ? 0 : 1;
            isAce = false;
        }

        public int Position => Convert.ToInt32(label.Name.Replace("Label", ""));

        public int Balls
        {
            get => Convert.ToInt32(label.Text);
            set => label.Text = value.ToString();
        }
    }
}
