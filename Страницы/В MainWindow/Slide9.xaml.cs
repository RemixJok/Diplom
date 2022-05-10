using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide9.xaml
    /// </summary>
    public partial class Slide9 : Page
    {
        public Slide9()
        {
            InitializeComponent();
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide8());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Окна.LoginWindow loginWindow = new Окна.LoginWindow();
            loginWindow.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
