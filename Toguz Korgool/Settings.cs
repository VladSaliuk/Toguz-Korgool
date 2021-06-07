using System;
using System.Collections.Generic;
using System.Text;

namespace Toguz_Korgool_0._5
{
    public static class Settings
    {
        public static int TimerTime = 1500;
        public static bool AreToggledHoles = true;
        public static bool IsToggledTImer = true;

        public static void ToggleHoles(GameWindow win)
        {
            if (!AreToggledHoles)
            {
                win.HoleText1.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText2.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText3.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText4.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText5.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText6.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText7.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText8.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText9.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText10.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText11.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText12.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText13.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText14.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText15.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText16.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText17.Visibility = System.Windows.Visibility.Hidden;
                win.HoleText18.Visibility = System.Windows.Visibility.Hidden;
            }
        }
        public static void ToggleTimer(GameWindow win)
        {
            if (!IsToggledTImer)
            {
                win.Timer1.Visibility = System.Windows.Visibility.Hidden;
                win.Timer2.Visibility = System.Windows.Visibility.Hidden;
                TimerTime = 9999999;
            }
        }
    }
}
