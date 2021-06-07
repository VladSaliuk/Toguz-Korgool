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
    public class RulesProvider
    {
        private Hole[] _holes;
        private Player[] _players;
        private Button[] _buttons;
        private DispatcherTimer[] _timers;
        private int[] _timesInSeconds = { Settings.TimerTime, Settings.TimerTime };

        public void Create(ref Hole[] holes, ref Player[] players, ref Button[] buttons, ref DispatcherTimer[] timers)
        {
            _holes = holes;
            _players = players;
            _buttons = buttons;
            _timers = timers;
        }

        public void SpreadBalls(ref int index)
        {
            int hand;

            if (_holes[index].Balls == 1)
                hand = 1;
            else
                hand = _holes[index].Balls - 1;

            _holes[index].Balls -= hand;

            for (int ball = 0; ball < hand; ball++)
            {
                index++;
                if (index == 18)
                    index = 0;
                _holes[index].Balls++;
            }
        }

        public void CheckIfAllHolesAreEmpty(int startingPlayer)
        {
            var holesToCheck = startingPlayer == 0 ? _holes[0..9] : _holes[9..];

            if (holesToCheck.Max(x => x.Balls) == 0)
            {
                _players[1 - startingPlayer].Win(_players[1 - startingPlayer].Name);
                EnableRightButtons(3);
            }
        }

        public void CheckHolesForZeroes(int playerNum)
        {
            int limit = playerNum == 0 ? 9 : 18;

            for (int n = playerNum == 0 ? 0 : 9; n < limit; n++)
                if (_holes[n].Balls == 0)
                    _buttons[n].IsEnabled = false;
        }

        public void EnableRightButtons(int playerNum)
        {
            switch (playerNum)
            {
                case 0:
                    _buttons[0..9].Select(x => { x.IsEnabled = false; return x; }).ToArray();
                    _buttons[9..].Select(x => { x.IsEnabled = true; return x; }).ToArray();
                    CheckHolesForZeroes(1);
                    break;

                case 1:
                    _buttons[0..9].Select(x => { x.IsEnabled = true; return x; }).ToArray();
                    _buttons[9..].Select(x => { x.IsEnabled = false; return x; }).ToArray();
                    CheckHolesForZeroes(0);
                    break;

                case 3: // 3 means that some player won, disables all buttons
                    _buttons.Select(x => { x.IsEnabled = false; return x; }).ToArray();
                    break;
            }
        }

        public void CollectAceBalls()
        {
            for (int i = 0; i < 2; i++)
            {
                if (_players[i].Ace != null)
                {
                    _players[i].Score += _players[i].Ace.Balls;
                    _players[i].Ace.Balls = 0;
                }
            }
        }

        public void AceCheck(int StartingPlayerNum, int index)
        {
            int n = index >= 9 ? -9 : 9; // n is used to find the opposite hole, so for 17 its 8, and for 4 it's 13 
            bool isOppositeHoleNotAce = !_holes[index + n].isAce;

            if (_players[StartingPlayerNum].Ace == null
                && !_holes[index].isAce
                && isOppositeHoleNotAce
                && _holes[index].Balls == 3
                && _holes[index].Position % 9 != 0)
            {
                _players[StartingPlayerNum].Ace = _holes[index];
                _holes[index].isAce = true;
                _holes[index].label.Foreground = Brushes.Red;
            }
        }

        public void ManageLastHole(int currentHolePlayer, int startingPlayer, int index)
        {
            if (currentHolePlayer != startingPlayer)
            {
                if (_holes[index].Balls % 2 == 0)
                {
                    _players[startingPlayer].Score += _holes[index].Balls;
                    _holes[index].Balls = 0;
                }
                else
                    AceCheck(startingPlayer, index);
            }
        }

        public bool CheckAndManageWin()
        {
            for (int i = 0; i < 2; i++)
            {
                if (_players[i].Score >= 81)
                {
                    _players[i].Win(_players[1 - i].Name);
                    EnableRightButtons(3); // disable all buttons

                    _timers.Select(x => { x.Stop(); return x; }).ToArray();

                    return true;
                }
            }
            return false;
        }

        public void ManageTimer(int startingPlayerNum, TextBlock TimerBlock)
        {
            ref int curTimeInSeconds = ref _timesInSeconds[startingPlayerNum];

            if (curTimeInSeconds > 0)
                curTimeInSeconds--;

            if (curTimeInSeconds <= 180)
                TimerBlock.Foreground = Brushes.Red;

            TimerBlock.Text = $"{curTimeInSeconds / 60}:{curTimeInSeconds % 60:00}";

            if (curTimeInSeconds == 0)
            {
                _players[startingPlayerNum].Win(_players[1 - startingPlayerNum].Name);
                EnableRightButtons(3);
                _timers[startingPlayerNum].Stop();
            }
        }
    }
}
