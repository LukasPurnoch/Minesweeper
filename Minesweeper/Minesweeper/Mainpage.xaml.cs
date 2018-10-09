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

namespace Minesweeper
{
    /// <summary>
    /// Interakční logika pro Mainpage.xaml
    /// </summary>
    public partial class Mainpage : Page
    {
        public int MineCounterNumber = 0;

        public int x = 0;
        public int y = 0;

        public int row = 0;
        public int column = 0;

        public Mainpage()
        {
            InitializeComponent();

            x = 6;
            y = 6;

            FieldGen(x, y);
            MineGeneration(3);
            NumberGen(x, y);
        }

        public void FieldGen(int x, int y)
        {
            for (int i = 0; i <= y; i++)     //Rows
            {
                for (int o = 0; o <= x; o++)     //Columns
                {
                    Button newBtn = new Button();
                    newBtn.Content = i + "-" + o;
                    newBtn.Name = "s";      //název podle označení pozice
                    newBtn.Click += new RoutedEventHandler(newBtn_BLIND_Click);

                    ColumnDefinition newCol = new ColumnDefinition();
                    newCol.Width = new GridLength(35, GridUnitType.Pixel);
                    PlayGrid.ColumnDefinitions.Add(newCol);

                    RowDefinition newRow = new RowDefinition();
                    newRow.Height = new GridLength(35, GridUnitType.Pixel);
                    PlayGrid.RowDefinitions.Add(newRow);

                    PlayGrid.Children.Add(newBtn);

                    Grid.SetColumn(newBtn, o);
                    Grid.SetRow(newBtn, i);
                }
            }
        }

        public void MineGeneration(int MineCount) //při tvorbě najít v elementech původního generování button se stejnou pozicí a předělat na minu
        {
            Random mine_pos = new Random();
            int MINE_pos_y;
            int MINE_pos_x;

            for (int i = 0; i <= MineCount; i++)
            {   
                MINE_pos_y = mine_pos.Next(0, x + 1);
                MINE_pos_x = mine_pos.Next(0, x + 1);

                foreach (UIElement ui in PlayGrid.Children)
                {
                    Grid.GetRow(ui) 
                }

                /*Button newBtnMine = new Button();
                newBtnMine.Content = "MINE";
                newBtnMine.Name = "Mine" + i.ToString();
                newBtnMine.Background = Brushes.Red;

                newBtnMine.Click += new RoutedEventHandler(newBtnMine_MINE_Click);

                PlayGrid.Children.Add(newBtnMine);

                Grid.SetColumn(newBtnMine, MINE_pos_x);
                Grid.SetRow(newBtnMine, MINE_pos_y);

                MineCounterNumber += 1;

                MineCounter.Content = MineCounterNumber.ToString();*/
            }
        }

        public void NumberGen(int x, int y)
        {
            foreach (UIElement ui in PlayGrid.Children)
            {
                for (int i = 0; i <= y; i++)    //Rows
                {
                    for (int o = 0; o <= x; o++)    //Columns
                    {
                        if (Grid.GetRow(ui) == i && Grid.GetColumn(ui) == o)   //Dynamicky kontrolovat pozice podle názvu
                        {
                            MineCounter.Content = i + "-" + o;
                        }
                    }
                }
            }   
        }   //Waiting till the minegen will be refactored

        private void newBtn_BLIND_Click(object sender, RoutedEventArgs e)
        {
            //MineCounter.Content = "BLANK";

            string content = (sender as Button).Name.ToString();

            MineCounter.Content = content;
        }

        private void newBtnMine_MINE_Click(object sender, RoutedEventArgs e)
        {
            MineCounter.Content = "MINE";
        }
    }
}
