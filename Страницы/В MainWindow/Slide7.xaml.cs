using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide7.xaml
    /// </summary>
    public partial class Slide7 : Page
    {
        public Slide7()
        {
            InitializeComponent();
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide6());
        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide8());
        }
    }
}
