using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide5.xaml
    /// </summary>
    public partial class Slide5 : Page
    {
        public Slide5()
        {
            InitializeComponent();
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide3());
        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide6());
        }
    }
}
