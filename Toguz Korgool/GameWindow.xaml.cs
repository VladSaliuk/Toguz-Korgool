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
using System.Timers;
using System.Windows.Threading;


namespace Toguz_Korgool_0._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public readonly Hole[] Holes = new Hole[18];
        public readonly Player[] Players = new Player[2];
        public readonly Button[] Buttons = new Button[18];
        DispatcherTimer[] Timers = new DispatcherTimer[2];
        RulesProvider rulesProvider = new RulesProvider();


        public Button[] InitializeButtonArray()
        {
            Button[] result = new Button[18];

            result[0] = Button1;
            result[1] = Button2;
            result[2] = Button3;
            result[3] = Button4;
            result[4] = Button5;
            result[5] = Button6;
            result[6] = Button7;
            result[7] = Button8;
            result[8] = Button9;
            result[9] = Button10;
            result[10] = Button11;
            result[11] = Button12;
            result[12] = Button13;
            result[13] = Button14;
            result[14] = Button15;
            result[15] = Button16;
            result[16] = Button17;
            result[17] = Button18;

            return result;
        }
        public Hole[] InitializeHoleArray()
        {
            Hole Hole1 = new Hole(Label1);
            Hole Hole2 = new Hole(Label2);
            Hole Hole3 = new Hole(Label3);
            Hole Hole4 = new Hole(Label4);
            Hole Hole5 = new Hole(Label5);
            Hole Hole6 = new Hole(Label6);
            Hole Hole7 = new Hole(Label7);
            Hole Hole8 = new Hole(Label8);
            Hole Hole9 = new Hole(Label9);
            Hole Hole10 = new Hole(Label10);
            Hole Hole11 = new Hole(Label11);
            Hole Hole12 = new Hole(Label12);
            Hole Hole13 = new Hole(Label13);
            Hole Hole14 = new Hole(Label14);
            Hole Hole15 = new Hole(Label15);
            Hole Hole16 = new Hole(Label16);
            Hole Hole17 = new Hole(Label17);
            Hole Hole18 = new Hole(Label18);

            Hole[] result = {
                Hole1, Hole2, Hole3, Hole4, Hole5,
                Hole6, Hole7, Hole8, Hole9, Hole10,
                Hole11, Hole12, Hole13, Hole14, Hole15,
                Hole16, Hole17, Hole18 };

            return result;
        }

        public void Turn(int index)
        {
            int startingPlayerNum = Holes[index].Player;
            int otherPlayer = 1 - startingPlayerNum;

            rulesProvider.CheckIfAllHolesAreEmpty(startingPlayerNum);

            rulesProvider.SpreadBalls(ref index);
            int currentHolePlayerNum = Holes[index].Player;
            rulesProvider.ManageLastHole(currentHolePlayerNum, startingPlayerNum, index);

            rulesProvider.CollectAceBalls();

            if (rulesProvider.CheckAndManageWin() == false)
            {
                rulesProvider.EnableRightButtons(startingPlayerNum); // Disables the buttons of the starting player, enables for the next/
                Timers[otherPlayer].Stop();
                Timers[startingPlayerNum].Start();
                return;
            }
        }

        public GameWindow()
        {
            InitializeComponent();

            Holes = InitializeHoleArray();
            Buttons = InitializeButtonArray();
            rulesProvider.Create(ref Holes, ref Players, ref Buttons, ref Timers);

            Settings.ToggleHoles(this);
            Settings.ToggleTimer(this);

            Timer1.Text = $"{Settings.TimerTime / 60}:{Settings.TimerTime % 60:00}";
            Timer2.Text = $"{Settings.TimerTime / 60}:{Settings.TimerTime % 60:00}";

            Timers[0] = new DispatcherTimer();
            Timers[1] = new DispatcherTimer();

            Timers[0].Interval = new TimeSpan(0, 0, 1);
            Timers[1].Interval = new TimeSpan(0, 0, 1);

            Timers[0].Tick += new EventHandler(Timer1_Tick);
            Timers[1].Tick += new EventHandler(Timer2_Tick);

            Players[0] = new Player(1, Score1, Player._player1Name);
            Players[1] = new Player(2, Score2, Player._player2Name);
        }

        private void Button1_Click(object sender, RoutedEventArgs e) => Turn(0);
        private void Button2_Click(object sender, RoutedEventArgs e) => Turn(1);
        private void Button3_Click(object sender, RoutedEventArgs e) => Turn(2);
        private void Button4_Click(object sender, RoutedEventArgs e) => Turn(3);
        private void Button5_Click(object sender, RoutedEventArgs e) => Turn(4);
        private void Button6_Click(object sender, RoutedEventArgs e) => Turn(5);
        private void Button7_Click(object sender, RoutedEventArgs e) => Turn(6);
        private void Button8_Click(object sender, RoutedEventArgs e) => Turn(7);
        private void Button9_Click(object sender, RoutedEventArgs e) => Turn(8);
        private void Button10_Click(object sender, RoutedEventArgs e) => Turn(9);
        private void Button11_Click(object sender, RoutedEventArgs e) => Turn(10);
        private void Button12_Click(object sender, RoutedEventArgs e) => Turn(11);
        private void Button13_Click(object sender, RoutedEventArgs e) => Turn(12);
        private void Button14_Click(object sender, RoutedEventArgs e) => Turn(13);
        private void Button15_Click(object sender, RoutedEventArgs e) => Turn(14);
        private void Button16_Click(object sender, RoutedEventArgs e) => Turn(15);
        private void Button17_Click(object sender, RoutedEventArgs e) => Turn(16);
        private void Button18_Click(object sender, RoutedEventArgs e) => Turn(17);

        private void Timer1_Tick(object sender, EventArgs e) => rulesProvider.ManageTimer(0, Timer1);
        private void Timer2_Tick(object sender, EventArgs e) => rulesProvider.ManageTimer(1, Timer2);
    }
}