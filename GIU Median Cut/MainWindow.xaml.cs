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
using Octree;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Interop;

namespace GIU_Median_Cut
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String path { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void openDialoge(object sender, RoutedEventArgs e)
        {

            //gridColor.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 26, 26, 26));

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            //     = File.ReadAllText(openFileDialog.FileName);
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                Console.WriteLine(openFileDialog.FileName);
                generateColors(null, null);
                TextBlock text = new TextBlock();
                Console.WriteLine("Done");
            }

        }

        private void generateColors(object sender, RoutedEventArgs e)
        {
            if (path != "")
            {
                image.Source = Imaging.CreateBitmapSourceFromHBitmap(new Bitmap(path).GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions()); ;
                var colors = Octree.Control.run(System.Drawing.Image.FromFile(path));
                gridColor.Children.Clear();
                gridColor.ColumnDefinitions.Clear();
                gridColor.ShowGridLines = false;
                int counter = 1;
                foreach (var color in colors)
                {
                    System.Windows.Shapes.Rectangle rec = new System.Windows.Shapes.Rectangle()
                    {
                        Width = 100,
                        Height = 100,
                        Fill = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, color.R, color.G, color.B)),
                        StrokeThickness = 2,
                    };
                    //rec.Margin = new Thickness(counter * 100, 0,  700 - counter * 100, 0);
                    //gridColor.Children.Add(rec);
                    gridColor.ColumnDefinitions.Add(new ColumnDefinition());

                    gridColor.Children.Add(rec);
                    Grid.SetColumn(rec, gridColor.ColumnDefinitions.Count - 1);
                    counter++;
                }
                //gridCol. = new SolidColorBrush(System.Windows.Media.Color.FromArgb(1, color.R, color.G, color.B));
                //canvas.Children.Add(rec);
                //.Content = DynamicGrid;
                MessageBox.Show("Done");
            }
        }
    }
}
