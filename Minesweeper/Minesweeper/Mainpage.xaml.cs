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
using System.Diagnostics;

namespace Minesweeper
{
    /// <summary>
    /// Interakční logika pro Mainpage.xaml
    /// </summary>
    public partial class Mainpage : Page
    {
        List<int> Random_y_row = new List<int>();
        List<int> Random_x_column = new List<int>();

        public int score = 0;

        public int MineCounterNumber = 0;

        public int mineAddCounter = 0;

        public int x = 0;
        public int y = 0;

        public int row = 0;
        public int column = 0;

        public Mainpage()
        {
            InitializeComponent();

            x = 9;
            y = 9;

            FieldGen(x, y, 3);
            //MineGeneration(3);
            //NumberGen(x, y);
        }

        public void FieldGen(int x, int y, int mines)
        {
            Random mine_pos = new Random();
            int MINE_pos_y;
            int MINE_pos_x;

            for (int i = 0; i < mines; i++)
            {
                MINE_pos_y = mine_pos.Next(1, y-2);
                MINE_pos_x = mine_pos.Next(1, x-1);                

                Random_y_row.Add(MINE_pos_y);
                Random_x_column.Add(MINE_pos_x);
            }

            Random_y_row.Sort();
            Random_x_column.Sort();
            
            for (int i = 0; i < Random_x_column.Count; i++)
            {
                Debug.Write(Random_x_column[i] + " ");
            }

            Debug.WriteLine("");

            for (int i = 0; i < Random_x_column.Count; i++)
            {
                Debug.Write(Random_y_row[i] + " ");
            }

            Debug.WriteLine("");

            for (int i = 0; i < y; i++)     //Rows
            {
                for (int o = 0; o < x; o++)     //Columns
                {
                    if (Random_y_row[mineAddCounter] == i && Random_x_column[mineAddCounter] == o && mineAddCounter < mines)
                    {
                        Button newBtnMine = new Button();
                        newBtnMine.Background = Brushes.Red;
                        //newBtnMine.Content = "MINE";
                        newBtnMine.Name = "Mine";      //název podle označení pozice
                        newBtnMine.Click += new RoutedEventHandler(newBtnMine_MINE_Click);

                        ColumnDefinition newColMine = new ColumnDefinition();
                        newColMine.Width = new GridLength(35, GridUnitType.Pixel);
                        PlayGrid.ColumnDefinitions.Add(newColMine);

                        RowDefinition newRowMine = new RowDefinition();
                        newRowMine.Height = new GridLength(35, GridUnitType.Pixel);
                        PlayGrid.RowDefinitions.Add(newRowMine);

                        PlayGrid.Children.Add(newBtnMine);

                        Grid.SetColumn(newBtnMine, o);
                        Grid.SetRow(newBtnMine, i);

                        if (mineAddCounter < mines - 1)
                        {
                            mineAddCounter += 1;
                        }
                    }
                    else
                    {
                        int listTemporary_X = 0;
                        int listTemporary_Y = 0;

                        for (int q = 0; q < mines; q++)
                        {
                            for (int p = 0; p < 3; p++) //Row
                            {
                                if (p == 0)
                                {
                                    int whileTemp = 0;

                                    while (whileTemp < 3)
                                    {
                                        if (whileTemp == 0)
                                        {
                                            
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Content = " ";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X] - 1);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y] - 1);          //Y

                                            PlayGrid.Children.Add(new1);

                                            /*int whileTemp2 = 0;

                                            while (whileTemp2 < mines)
                                            {
                                                if (q > 0 && Random_x_column[listTemporary_X - 1] == Random_x_column[whileTemp2] && Random_y_row[listTemporary_Y - 1] == Random_y_row[whileTemp2])
                                                {

                                                }
                                                else
                                                {
                                                    
                                                }

                                                whileTemp2 += 1;
                                            }*/

                                        }
                                        if (whileTemp == 1)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Content = " ";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X]);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y] - 1);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }
                                        if (whileTemp == 2)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Content = " ";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X] + 1);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y] - 1);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }

                                        whileTemp += 1;
                                    }
                                }

                                if (p == 1)
                                {
                                    int whileTemp = 0;

                                    while (whileTemp < 2)
                                    {
                                        if (whileTemp == 0)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Name = "one";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X] - 1);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y]);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }
                                        if (whileTemp == 1)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Name = "one";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X] + 1);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y]);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }

                                        whileTemp += 1;
                                    }
                                }

                                if (p == 2)
                                {
                                    int whileTemp = 0;

                                    while (whileTemp < 3)
                                    {
                                        if (whileTemp == 0)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Name = "one";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X] - 1);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y] + 1);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }
                                        if (whileTemp == 1)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Name = "one";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X]);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y] + 1);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }
                                        if (whileTemp == 2)
                                        {
                                            Button new1 = new Button();
                                            new1.Background = Brushes.Blue;
                                            new1.Name = "one";
                                            new1.Click += new RoutedEventHandler(new1_Click);

                                            Grid.SetColumn(new1, Random_x_column[listTemporary_X] + 1);    //X
                                            Grid.SetRow(new1, Random_y_row[listTemporary_Y] + 1);          //Y

                                            PlayGrid.Children.Add(new1);
                                        }

                                        whileTemp += 1;
                                    }
                                }
                            }

                            listTemporary_X += 1;
                            listTemporary_Y += 1;
                        }

                        Button newBtn = new Button();
                        newBtn.Content = i + "-" + o;
                        //newBtn.Name = "Blank";      //název podle označení pozice
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
        }

        private void newBtn_BLIND_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn.Content.ToString() == "0")
            {

            }
            else
            {
                score += 1;
                btn.Content = 0;
            }            

            Score.Content = score;
        }

        private void newBtnMine_MINE_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content = "💣";

            MessageBoxResult result = MessageBox.Show("Game over", "Confirmation", MessageBoxButton.OK, MessageBoxImage.Question);

            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }

        private void new1_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            btn.Content = 1;
        }
    }
}
