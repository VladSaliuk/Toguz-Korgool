using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Toguz_Korgool_0._5
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        ScrollViewer scrollViewer = new ScrollViewer();
        Grid grid = new Grid();

        public static void WriteVictory(string victoriousPlayerName, string defeatedPlayerName)
        {
            try
            {
                using (var file = new System.IO.StreamWriter(@"statistics.txt", true))
                {
                    file.WriteLine(DateTime.Now + "," + victoriousPlayerName + "," + defeatedPlayerName);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Exception during writing to a file", ex);
            }

        }

        static void DisplayStats(Grid grid, SortType sortType = SortType.SortByDate)
        {
            var statList = new List<string[]>();
            using (var file = new System.IO.StreamReader(@"Statistics.txt", true))
            {
                while (!file.EndOfStream)
                {
                    statList.Add(file.ReadLine().Split(','));
                }
            }

            switch (sortType)
            {
                case SortType.SortByDate:
                    statList = statList.OrderBy(x => Convert.ToDateTime(x[0])).ToList();
                    break;
                case SortType.SortByDateReverse:
                    statList = statList.OrderByDescending(x => Convert.ToDateTime(x[0])).ToList();
                    break;
                case SortType.SortByWon:
                    statList = statList.OrderBy(x => x[1]).ToList();
                    break;
                case SortType.SortByWonReverse:
                    statList = statList.OrderByDescending(x => x[1]).ToList();
                    break;
                case SortType.SortByLost:
                    statList = statList.OrderBy(x => x[2]).ToList();
                    break;
                case SortType.SortByLostReverse:
                    statList = statList.OrderByDescending(x => x[2]).ToList();
                    break;
            }


            int rowNum = 0;
            foreach (var line in statList)
            {
                // Initializing the textblocks to put in the inner scrollViewer grid, putting them into 1 array, creating a new row
                var stat1 = new TextBlock() { VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Left, FontSize = 26, Margin = new Thickness() { Left = 3, Bottom = 0, Top = 0, Right = 0 } };
                var stat2 = new TextBlock() { VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Left, FontSize = 26, Margin = new Thickness() { Left = 3, Bottom = 0, Top = 0, Right = 0 } };
                var stat3 = new TextBlock() { VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Left, FontSize = 26, Margin = new Thickness() { Left = 3, Bottom = 0, Top = 0, Right = 0 } };

                TextBlock[] stats = new TextBlock[3] { stat1, stat2, stat3 };

                if (grid.RowDefinitions.Count <= rowNum)
                    grid.RowDefinitions.Add(new RowDefinition() { MaxHeight = 40, MinHeight = 40 });

                for (int i = 0; i < 3; i++)
                {
                    // Putting each textblock to their position in the grid after adding the stat to them
                    stats[i].Text = line[i];
                    stats[i].HorizontalAlignment = HorizontalAlignment.Stretch;

                    grid.Children.Add(stats[i]);
                    Grid.SetColumn(stats[i], i);
                    Grid.SetRow(stats[i], rowNum);

                    // Doing the same with borders
                    Border bord = new Border() { BorderThickness = new Thickness() { Bottom = 1, Left = 1, Right = 1, Top = 1 }, BorderBrush = new SolidColorBrush(Colors.Black) };

                    grid.Children.Add(bord);
                    Grid.SetColumn(bord, i);
                    Grid.SetRow(bord, rowNum);
                }
                rowNum++;
            }
        }

        public Statistics()
        {
            InitializeComponent();
            // Creating a new scrollviewer and a grid with 3 columns inside of it, opening the stats fil
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            scrollViewer.Content = grid;
            LayoutRoot.Children.Add(scrollViewer);
            Grid.SetColumn(scrollViewer, 1);
            Grid.SetRow(scrollViewer, 2);
            Grid.SetColumnSpan(scrollViewer, 3);

            DisplayStats(grid);
        }

        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            MainMenuWindow win = new MainMenuWindow();
            win.Show();
            this.Close();
        }
        private void WonButtonClick(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            DisplayStats(grid, SortType.SortByWon);

            WonButton.Click -= WonButtonClick;
            WonButton.Click += ReverseWonSort;
        }
        private void ReverseWonSort(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            DisplayStats(grid, SortType.SortByWonReverse);

            WonButton.Click -= ReverseWonSort;
            WonButton.Click += WonButtonClick;
        }
        private void LostButtonClick(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            DisplayStats(grid, SortType.SortByLost);

            LostButton.Click -= LostButtonClick;
            LostButton.Click += ReverseLostSort;
        }
        private void ReverseLostSort(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            DisplayStats(grid, SortType.SortByLostReverse);

            LostButton.Click -= ReverseLostSort;
            LostButton.Click += LostButtonClick;
        }
        private void DateButtonClick(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            DisplayStats(grid, SortType.SortByDateReverse);

            DateButton.Click -= DateButtonClick;
            DateButton.Click += DateSort;
        }
        private void DateSort(object sender, RoutedEventArgs e)
        {
            grid.Children.Clear();
            DisplayStats(grid, SortType.SortByDate);

            DateButton.Click -= DateSort;
            DateButton.Click += DateButtonClick;
        }
    }
}
