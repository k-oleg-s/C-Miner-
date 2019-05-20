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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MineField mineField;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        void NewGame()
        {
            int x = 5;
            int y = 4;
            int mineskolvo = 5;

            // //MessageBox.Show("t2");

            mineField = new MineField(x, y, mineskolvo);

            foreach (Spot s in mineField.spots)
            {
                s.btn.PreviewMouseLeftButtonDown += Btn_PreviewMouseLeftButtonDown;
                s.btn.MouseRightButtonDown += Btn_MouseRightButtonDown;

                s.btn.Content = "O";
                s.btn.VerticalContentAlignment = System.Windows.VerticalAlignment.Top;
                txtbx1.Text = "s";
                grd1.Children.Add(s.btn);
            }

        }

        private void Btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button b1 && Find1(b1) != null)
            {
                    txtbx1.Text = b1.Name;
                    Spot s = Find1(b1);
                    mineField.leftPressed(s); 
            }
        }

        private void Btn_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button b1 && Find1(b1) != null)
            {
                txtbx1.Text = b1.Name;
                Spot s = Find1(b1);
                mineField.rightPressed(s);
            }
        }

        private Spot Find1(Button b)
        {
            foreach (Spot s in mineField.spots)
            {
                if (s.btn == b) return s;                
            }
            return null;
        }


        class Spot
        {
            public int x { get; set; }
            public int y { get; set; }
            public bool ismined;
            public bool isclosed = true;
            public bool isflagged;
            public int hint;
            public Button btn;
        }

        class MineField
        {
            int dx = 5;
            int dy = 4;

            public List<Spot> spots = new List<Spot> { };

            public MineField(int x, int y, int minesqnt)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        Spot t = new Spot();
                        t.btn = new Button();
                        //        t.btn.Visibility = true;
                        t.btn.Name = "x" + i + "y" + j;
                        t.btn.Width = 50;
                        t.btn.Height = 50;
                        t.btn.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        t.btn.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        t.btn.Margin = new Thickness(10);
                        spots.Add(t);
                    }
                }
            }

            public void leftPressed(Spot s)
            { MessageBox.Show("leftPressed"); }

            public void rightPressed(Spot s)
            { MessageBox.Show("rightPressed"); }

        }
    }
}
