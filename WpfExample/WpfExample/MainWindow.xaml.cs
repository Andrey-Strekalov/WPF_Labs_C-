using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int N = 10;
            try
            {
                N = Convert.ToInt32(FigureCount.Text);
            }
            catch (Exception ex)
            {
                this.Title = "Enter integer number only!";
                return;
            }
            GenerateShapes(N);
        }

        private void GenerateShapes(int N)
        {
            MainCanvas.Children.Clear();

            Random rndShapeType = new Random(DateTime.Now.Millisecond);
            Random rndStyle = new Random(DateTime.Now.Second);
            Random rndPosition = new Random(DateTime.Now.Minute);
            Random rndSize = new Random(DateTime.Now.Minute);

            for (int i = 0; i < N; i++)
            {
                Shape currentShape;
                int shapeType = rndShapeType.Next(0, 4); // 4 типа фигур

                switch (shapeType)
                {
                    case 0:
                        currentShape = new Ellipse();
                        break;
                    case 1:
                        currentShape = new Rectangle();
                        break;
                    case 2:
                        currentShape = CreateTriangle();
                        break;
                    case 3:
                        currentShape = new Polygon();
                        ((Polygon)currentShape).Points = new PointCollection
                        {
                            new Point(0, 0),
                            new Point(1, 1),
                            new Point(0, 1)
                        }; // Прямоугольный треугольник
                        break;
                    default:
                        currentShape = new Ellipse();
                        break;
                }

                // Выбор стиля (1-4)
                int shapeStyle = rndStyle.Next(0, 4) + 1;
                string styleName = "style" + shapeStyle;
                Style currentStyle = (Style)this.FindResource(styleName);
                currentShape.Style = currentStyle;

                // Установка размеров
                currentShape.Width = rndSize.Next(20, 150);
                currentShape.Height = rndSize.Next(20, 150);

                // Добавление на холст
                MainCanvas.Children.Add(currentShape);
                Canvas.SetLeft(currentShape, rndPosition.Next(5, 700));
                Canvas.SetTop(currentShape, rndPosition.Next(5, 250));
            }
        }

        private Polygon CreateTriangle()
        {
            Polygon triangle = new Polygon();
            triangle.Points = new PointCollection
            {
                new Point(0, 1),    // верхняя точка
                new Point(1, -1),   // правая нижняя
                new Point(-1, -1)   // левая нижняя
            };
            return triangle;
        }
    }
}
