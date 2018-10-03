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

        public int yy = 0;

        public double posun_x = 0;
        public double posun_y = 0;

        public Mainpage()
        {
            InitializeComponent();

            x = 11;
            y = 11;

            FieldGen(x, y);
        }

        public void FieldGen(int x, int y)
        {
            for (int u = 0; u < y; u++)
            {            
                for (int i = 0; i < x; i++)
                {
                    Button newBtn = new Button();

                    newBtn.Content = i.ToString();
                    newBtn.Name = "Button" + i.ToString();
                    newBtn.Width = 20;
                    newBtn.Height = 20;

                    Field.Children.Add(newBtn);

                    newBtn.SetValue(Canvas.LeftProperty, posun_x);
                    newBtn.SetValue(Canvas.TopProperty, posun_y);

                    posun_x += 19d;
                }
                posun_y += 19d;
            }
        }
    }
}
