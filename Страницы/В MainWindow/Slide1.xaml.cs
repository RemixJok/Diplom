using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide1.xaml
    /// </summary>
    public partial class Slide1 : Page
    {
        public Slide1()
        {
            InitializeComponent();
        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide2());
        }
    }
}
