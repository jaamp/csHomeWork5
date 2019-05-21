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

namespace csHomeWork5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool player = true;
        bool winner = false;
        bool newGame = false;
        int numClicks = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UxNewGame_Click(object sender, RoutedEventArgs e)
        {
            UIElementCollection gridKid = uxGrid.Children;
            List<FrameworkElement> gridKids = gridKid.Cast<FrameworkElement>().ToList();
            List<Button> buttons = gridKids.OfType<Button>().ToList();
            for (var i = 0; i < 9; i++)
            {
                buttons[i].Content = "";
            }
            MessageBox.Show("Begin new game");
            player = true;
            winner = false;
            newGame = true;
            numClicks = 0;
        }

        private void UxExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Exit clicked, this window will now close.");
            (sender as Window).Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!newGame)
            {
                MessageBox.Show("Please start a New Game");
                return;
            }
            else
            {
                numClicks = numClicks + 1;
                if (player)
                {
                    (sender as Button).Content = "X";
                }
                else
                {
                    (sender as Button).Content = "O";
                }

                checkForWin();

                if (!winner)
                {
                    changePlayer();
                }
            }

        }

        private bool changePlayer()
        {
            if (player)
            {
                player = false;
                MessageBox.Show("'O's Turn");
                return player; ;
            }
            else
            {
                player = true;
                MessageBox.Show("'X's Turn");
                return player;
            }
        }

        private bool checkForWin()
        {
            UIElementCollection gridKid = uxGrid.Children;
            List<FrameworkElement> gridKids = gridKid.Cast<FrameworkElement>().ToList();
            List<Button> buttons = gridKids.OfType<Button>().ToList();
            string[] winCheck = new string[9];
            for (var i=0; i < 9; i++)
            {
                var winCK = buttons[i].Content;
                winCheck[i] = winCK.ToString();
            }
            if ((winCheck[0] == "O" && winCheck[1] == "O" && winCheck[2] == "O") || 
                    (winCheck[3] == "O" && winCheck[4] == "O" && winCheck[5] == "O") ||
                    (winCheck[6] == "O" && winCheck[7] == "O" && winCheck[8] == "O") ||
                    (winCheck[0] == "O" && winCheck[3] == "O" && winCheck[6] == "O") ||
                    (winCheck[1] == "O" && winCheck[4] == "O" && winCheck[7] == "O") ||
                    (winCheck[2] == "O" && winCheck[5] == "O" && winCheck[8] == "O") ||
                    (winCheck[0] == "O" && winCheck[4] == "O" && winCheck[8] == "O") ||
                    (winCheck[2] == "O" && winCheck[4] == "O" && winCheck[6] == "O")) {
                MessageBox.Show(" 'O' Wins");
                winner = true;
                newGame = false;
            }
            else if ((winCheck[0] == "X" && winCheck[1] == "X" && winCheck[2] == "X") ||
                        (winCheck[3] == "X" && winCheck[4] == "X" && winCheck[5] == "X") ||
                        (winCheck[6] == "X" && winCheck[7] == "X" && winCheck[8] == "X") ||
                        (winCheck[0] == "X" && winCheck[3] == "X" && winCheck[6] == "X") ||
                        (winCheck[1] == "X" && winCheck[4] == "X" && winCheck[7] == "X") ||
                        (winCheck[2] == "X" && winCheck[5] == "X" && winCheck[8] == "X") ||
                        (winCheck[0] == "X" && winCheck[4] == "X" && winCheck[8] == "X") ||
                        (winCheck[2] == "X" && winCheck[4] == "X" && winCheck[6] == "X")){
                MessageBox.Show(" 'X' Wins");
                winner = true;
                newGame = false;
            }
            else if (numClicks == 9) {
                MessageBox.Show("Tie Game No Winner");
                winner = true;
                newGame = false;
            }
            return winner;
        }
    }
}
 