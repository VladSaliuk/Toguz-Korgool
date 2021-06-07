using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Toguz_Korgool_0._5
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();

            TimerTimeBox.Text = Convert.ToString(Settings.TimerTime);
            ToggleHoleCheckBox.IsChecked = Settings.AreToggledHoles;
            ToggleTimerCheckBox.IsChecked = Settings.IsToggledTImer;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(TimerTimeBox.Text, out int time))
                Settings.TimerTime = time;
            else
            {
                MessageBox.Show("Invalid time", "Error");
                return;
            }

            Settings.AreToggledHoles = ToggleHoleCheckBox.IsChecked.Value;
            Settings.IsToggledTImer = ToggleTimerCheckBox.IsChecked.Value;

            MainMenuWindow win = new MainMenuWindow();
            win.Show();
            this.Close();
        }
    }
}
