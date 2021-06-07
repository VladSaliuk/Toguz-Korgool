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
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace Toguz_Korgool_0._5
{
    public class Player
    {
        public readonly int Num;
        public readonly string Name;
        private readonly TextBlock score;

        public static string _player1Name = "Player 1";
        public static string _player2Name = "Player 2";

        public Player(int inputNum, TextBlock inputScore, string inputName)
        {
            Num = inputNum;
            score = inputScore;
            Name = inputName;
            Score = 0;
        }

        public int Score
        {
            get => Convert.ToInt32(score.Text.Split(": ")[1]);
            set => score.Text = $"{Name}'s Score: {value}";
        }
        public Hole Ace { get; set; }

        public void Win(string defeatedPlayerName)
        {
            Statistics.WriteVictory(this.Name, defeatedPlayerName);
            score.Text = $"{Name} Won!";
        }

    }
}
