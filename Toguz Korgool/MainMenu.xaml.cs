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
using System.IO;

namespace Toguz_Korgool_0._5
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            GameWindow win = new GameWindow();
            win.Show();
            this.Close();
        }
        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow win = new SettingsWindow();
            win.Show();
            this.Close();
        }
        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            Statistics win = new Statistics();
            win.Show();
            this.Close();
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Player1Name_Click(object sender, RoutedEventArgs e)
        {
            if (Player1Name.Text == "" || Player1Name.Text.Contains(","))
                MessageBox.Show("Invalid Name.", "Player 1 Name");
            else if (Player1Name.Text != Player._player2Name)
            {
                Player._player1Name = Player1Name.Text;
                MessageBox.Show("Name set.", "Player 1 Name");
            }
            else
                MessageBox.Show("This name is already used.", "Player 1 Name");
        }

        private void Player2Name_Click(object sender, RoutedEventArgs e)
        {
            if (Player2Name.Text == "" || Player2Name.Text.Contains(","))
                MessageBox.Show("Invalid Name.", "Player 2 Name");
            else if (Player2Name.Text != Player._player1Name)
            {
                Player._player2Name = Player2Name.Text;
                MessageBox.Show("Name set.", "Player 2 Name");
            }
            else
                MessageBox.Show("This name is already used.", "Player 2 Name");
        }
    }
}