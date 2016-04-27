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

namespace Card_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[] deck = new int[20];
        Random r = new Random();
        int cardStatus = 0;
        bool comPare;
        int score = 0;

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 1; i <= 19; i++)
            {
                deck[i] = deck[i - 1] + 1;
            }
            Shuffle();
            Score.Text = "Score: " + Convert.ToString(score);
        }


        private void Shuffle()
        {
            for (int x = 1000; x > 0; x--)
            {
                //	Based on Java code from wikipedia:
                //	http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
                for (int n = deck.Length - 1; n > 0; --n)
                {
                    int k = r.Next(0, deck.Length);
                    int temp = deck[n];
                    deck[n] = deck[k];
                    deck[k] = temp;
                    card.Content = Convert.ToString(deck[0]);

                }
            }
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            cardStatus++;
            status.Text = "Card " + Convert.ToString(cardStatus) + " of 20";
        }

        private void ComPare()
        {
            if (comPare == true)
            {
                score++;
                Score.Text = "Score: " + Convert.ToString(score);

            }
            else
            {
                score--;
                Score.Text = "Score: " + Convert.ToString(score);

                if (score < 0)
                {
                    score = 0;
                    Score.Text = "Score: " + Convert.ToString(score);

                }
            }

        }
        private void EndGame()
        {
            if (cardStatus == 20)
            {
                higher.IsEnabled = false;
                lower.IsEnabled = false;
                status.Text = "The Game is now over. Loser.";
            }
        }

        private void higher_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(card.Content) < deck[cardStatus])
            {
                comPare = true;
                ComPare();
            }
            else
            {
                comPare = false;
                ComPare();
            }

            card.Content = Convert.ToString(deck[cardStatus]);
            UpdateStatus();
            EndGame();



        }

        private void lower_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(card.Content) > deck[cardStatus])
            {
                comPare = true;
                ComPare();
            }
            else
            {
                comPare = false;
                ComPare();
            }

            card.Content = Convert.ToString(deck[cardStatus]);
            UpdateStatus();
            EndGame();
        }
    }
}
