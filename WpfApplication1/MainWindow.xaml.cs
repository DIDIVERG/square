using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        private int iterations;
        private double lastSideLength;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(iterationTextBox.Text, out iterations))
            {
                DrawShapes();
            }
            else
            {
                MessageBox.Show("Please enter a valid number of iterations.");
            }
        }

        private void DrawShapes()
        {
            canvas.Children.Clear();

            double sideLength = 200;
            double centerX = canvas.ActualWidth / 2;
            double centerY = canvas.ActualHeight / 2;
            lastSideLength = sideLength;

            for (int i = 1; i <= iterations; i++)
            {
                if (i % 2 == 1)
                {
                    DrawSquare(centerX, centerY, lastSideLength);
                }
                else
                {
                    DrawCircle(centerX, centerY, lastSideLength / 2);
                }

                sideLength /= Math.Sqrt(2);
                lastSideLength = sideLength;
            }
        }

        private void DrawSquare(double centerX, double centerY, double sideLength)
        {
            double x = centerX - sideLength / 2;
            double y = centerY - sideLength / 2;

            Rectangle square = new Rectangle
            {
                Width = sideLength,
                Height = sideLength,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            Canvas.SetLeft(square, x);
            Canvas.SetTop(square, y);

            canvas.Children.Add(square);
        }

        private void DrawCircle(double centerX, double centerY, double radius)
        {
            Ellipse circle = new Ellipse
            {
                Width = radius * 2,
                Height = radius * 2,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };

            // Установка координат центра окружности
            Canvas.SetLeft(circle, centerX - radius);
            Canvas.SetTop(circle, centerY - radius);

            canvas.Children.Add(circle);
        }
    }
}
