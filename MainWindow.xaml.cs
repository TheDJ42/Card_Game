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

        public MainWindow()
        {
            InitializeComponent();
            for ()
            Random r = new Random();
            //	Based on Java code from wikipedia:
            //	http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
            for (int n = deck.Length - 1; n > 0; --n)
            {
                int k = r.Next(0, deck.Length);
                int temp = deck[n];
                deck[n] = deck[k];
                deck[k] = temp;
            }
        }




    }
}
