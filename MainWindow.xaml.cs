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
            for (int j=0;j<10;j++)
            {
                Siatka.ColumnDefinitions.Add(new ColumnDefinition());
                Siatka.RowDefinitions.Add(new RowDefinition());
                for(int i=0;i<10;i++)
                {
                    Button b = new Button();
                    b.Click += new RoutedEventHandler((s, e) => DoSom(i, j, s));
                    b.Click += new RoutedEventHandler((s, e) => button1_Click(s,e));
                    b.Background = Brush.Blue;
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, j);
                    Siatka.Children.Add(b);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //sender.Background = Brushes.Blue;
            Button btn = sender as Button;
            btn.Background = btn.Background == Brushes.Red ? (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFDDDDDD")) : Brushes.Red;
        }
        private void DoSom(int j, int i, object s)
        {
            (s as Button).Content = $"{i}. {j}";
        }
    }

}
