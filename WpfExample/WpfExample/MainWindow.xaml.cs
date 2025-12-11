using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // OneTime привязка (инициализация)
            txtTarget.ToolTip = $"Создано: {DateTime.Now:HH:mm:ss}";
        }

        private void btnNormal_OnClick(object sender, RoutedEventArgs e)
        {
            sldSource.Value = 30;
        }

        private void btnLarge_OnClick(object sender, RoutedEventArgs e)
        {
            sldSource.Value = 60;
        }

        private void btnDynamic_Click(object sender, RoutedEventArgs e)
        {
            // Динамическая привязка (создается в runtime)
            CreateDynamicBinding();
        }

        private void CreateDynamicBinding()
        {
            // Динамическая привязка Background к выбранному цвету
            Binding binding = new Binding();
            binding.Source = listColor;
            binding.Path = new PropertyPath("SelectedItem.Tag");
            binding.Mode = BindingMode.OneWay;

            txtTarget.SetBinding(TextBox.BackgroundProperty, binding);
        }

        // Обработчики для CheckBox
        private void chkBold_Checked(object sender, RoutedEventArgs e)
        {
            txtTarget.FontWeight = FontWeights.Bold;
        }

        private void chkBold_Unchecked(object sender, RoutedEventArgs e)
        {
            txtTarget.FontWeight = FontWeights.Normal;
        }
    }
}