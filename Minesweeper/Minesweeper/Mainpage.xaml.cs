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
        public int x = 0;
        public int y = 0;

        public int row = 0;
        public int column = 0;

        public Mainpage()
        {
            InitializeComponent();

            x = 11;
            y = 11;

            FieldGen(x, y);
            MineGeneration(10);
        }

        public void FieldGen(int x, int y)
        {
            for (int i = 0; i <= y; i++)     //Rows
            {
                for (int o = 0; o <= x; o++)     //Columns
                {
                    Button newBtn = new Button();
                    newBtn.Content = i + "-" + o;
                    newBtn.Name = "Button" + i.ToString();
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

        public void MineGeneration(int MineCount)
        {
            Random mine_pos = new Random();
            int MINE_pos_y;
            int MINE_pos_x;

            for (int i = 0; i <= MineCount; i++)
            {   
                MINE_pos_y = mine_pos.Next(0, x-1);
                MINE_pos_x = mine_pos.Next(0, x-1);

                Button newBtnMine = new Button();
                newBtnMine.Content = "MINE";
                newBtnMine.Name = "Mine" + i.ToString();
                newBtnMine.Background = Brushes.Red;

                PlayGrid.Children.Add(newBtnMine);

                Grid.SetColumn(newBtnMine, MINE_pos_x);
                Grid.SetRow(newBtnMine, MINE_pos_y);

                int deb = 0;
                deb += 1;
            }
        }

        void newBtn_BLIND_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
