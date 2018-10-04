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

        public double row = 0;
        public double column = 0;

        public Mainpage()
        {
            InitializeComponent();

            x = 11;
            y = 11;

            FieldGen(x, y);
        }

        public void FieldGen(int x, int y)
        {
            
        }
    }
}
