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

namespace hourglass_simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Brush BrushColor = Brushes.Yellow;
            Pen blkPen = new Pen(Brushes.Black, 1);
            DrawingVisual vis = new DrawingVisual();
            DrawingContext dc = vis.RenderOpen();
            int gapx = 2 * 4, gapy = 2 * 4;
            //Draw some lines
            for (int y = 0; y < 20; y += 10)
            {
                dc.DrawLine(blkPen, new Point(0, y), new Point(100, y));
                dc.DrawLine(blkPen, new Point(y, 200), new Point(y, 0));
            }
          
            //Draw some circles
            for (int y = 0; y < 100; y++)
            {
                for (int x = 0; x < 100; x += 8)
                {
                    dc.DrawEllipse(BrushColor, blkPen, new Point(gapx, gapy), 10,10 );

                }
            }
            dc.Close();
            RenderTargetBitmap bmp = new RenderTargetBitmap(490, 260, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(vis);
            imgPlot.Source = bmp;
        }
    }
}
