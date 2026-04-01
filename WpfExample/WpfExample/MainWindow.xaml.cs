using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int N, K;
        double result, x, y;
        public MainWindow()
        {
            InitializeComponent();

        }

       

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                N = Convert.ToInt32(TextN.Text);
                K = Convert.ToInt32(TextK.Text);
                x = Convert.ToDouble(TextX.Text);
                y = Convert.ToDouble(TextY.Text);

                for (int i = 1; i <= N; i++)
                {
                    for (int j = 1; j <= K; j++)
                    {
                        double numerator = Math.Sin(x) * Math.Pow(x, i) + Math.Cos(y) * Math.Pow(y, j);
                        double denominator = i * j;
                        result += numerator / denominator;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при вводе данных. Возможно недопустимый формат чисел" + ex.Message);
            }

            this.Title = "Ответ: " + result.ToString();
        }
    }
}