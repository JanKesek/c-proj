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


namespace WpfApp2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            List<int[]> clickedButtons = new List<int[]>();
            //List<object> allButtons = new List<object>();
            for (int j=0;j<10;j++)
            {
                Siatka.ColumnDefinitions.Add(new ColumnDefinition());
                Siatka.RowDefinitions.Add(new RowDefinition());
                for (int i=0;i<10;i++)
                {

                    Button b = new Button();
                    int v = i, w = j;
                    //int[] currentCoordinate = { i, j };
                    b.Click += new RoutedEventHandler((s, e) => DoSom(v, w, s, e));
                    b.Click += new RoutedEventHandler((s, e) => button1_Click(clickedButtons, v,w,s,e));
                    //allButtons.Add(b);
                    b.Background = Brushes.White;
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Siatka.Children.Add(b);
                }
            }
            Start.Click += new RoutedEventHandler((s, e) => startFunction(clickedButtons, s, e));
           // Grid.SetColumn(start, 11);
           // Grid.SetRow(start, 5);
            //Start.Children.Add(start);
        }
        private List<int[]> button1_Click(List<int[]> clickedButtons, int i, int j, object sender, EventArgs e)
        {
            //sender.Background = Brushes.Blue;
            Button btn = sender as Button;
            int[] coordinates = new int[]{ i, j };
            if (btn.Background == Brushes.Red)
            {
                btn.Background = Brushes.White;
                clickedButtons.Remove(coordinates);
            }
            else
            {
                //btn.Background = btn.Background == Brushes.Red ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Red;
                btn.Background = Brushes.Red;
                clickedButtons.Add(coordinates);

            }
           
            return clickedButtons;
            
        }

        private List<int[]> startFunction(List<int[]> clickedButtons, object s, EventArgs e)
        {
            List<int[]> buttonsToKill = new List<int[]>();
            foreach (int[] i in clickedButtons)
            {
                if (countLivingNeighboors(clickedButtons, i) != 2 || countLivingNeighboors(clickedButtons, i) != 3)
                    buttonsToKill.Add(i);
            }


            return killButtons(buttonsToKill, clickedButtons);
        }

        private bool checkIfAlive(List<int[]> clickedButtons, int i, int j)
        {
            int[] item = { i, j };
            if (clickedButtons.Contains(item))
            {
                //object sender = allButtons.ElementAt(i + 8*j);
                //Button b = sender as Button;
                //if (b.Background == Brushes.Red) 
                return true;
            }
            else
            {
                return false;
            };
        }

        private void DoSom(int j, int i, object s, EventArgs e)
        {
            (s as Button).Content = $"{i}. {j}";
        }
        
        private int countLivingNeighboors(List<int[]> clickedButtons, int[] xy)
        {

            //int indxInList = xy[0]+ 10*xy[1];
            int i = xy[0];
            int j = xy[1];
            bool[] statesOfNeighbors = new bool[8];
           
            if (i - 1 >= 0) statesOfNeighbors[0]  = checkIfAlive(clickedButtons, i - 1, j);
            if (i + 1 <= 9) statesOfNeighbors[1] =checkIfAlive(clickedButtons,  i + 1, j);
            if (j - 1 >= 0) statesOfNeighbors[2] =checkIfAlive(clickedButtons,  i, j-1);
            if (j + 1 <= 9) statesOfNeighbors[3]= checkIfAlive(clickedButtons, i, j+1);
            if (i - 1 >= 0 && j -1 >=0) statesOfNeighbors[4] =checkIfAlive(clickedButtons, i - 1, j-1);
            if (i + 1 <= 9 && j +1 <=9) statesOfNeighbors[5]= checkIfAlive(clickedButtons,  i + 1, j+1);
            if (i + 1 <= 0 && j -1 >=0) statesOfNeighbors[6] =checkIfAlive(clickedButtons,  i +1, j - 1);
            if (i - 1 >= 9 && j +1 <=9) statesOfNeighbors[7] =checkIfAlive(clickedButtons,  i -1, j + 1);

            return statesOfNeighbors.Count(c => c);

        }
        


        private List<int[]> killButtons(List<int[]> buttonsToKill, List<int[]> clickedButtons)
        {
            foreach (int[] i in buttonsToKill)
            {
                //object sender = allButtons.ElementAt(i[0] + 10 * i[1]);
                //Button b = sender as Button;
                //b.Background = Brushes.White;
                //ZMIEN TA LINIE - WYMIEN OBIEKT BEDACY int[] = {i,j} na zgaszony button z allButtons wyzej^
                clickedButtons.Remove(i);
            }
            return clickedButtons;
        }
    }

}
