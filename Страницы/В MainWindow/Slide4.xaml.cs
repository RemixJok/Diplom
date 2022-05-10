using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide4.xaml
    /// </summary>
    public partial class Slide4 : Page
    {
        public Slide4()
        {
            InitializeComponent();
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide3());
        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide5());
        }
    }
}
