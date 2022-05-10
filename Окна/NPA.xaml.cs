using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для NPA.xaml
    /// </summary>
    public partial class NPA : Window
    {
        public NPA()
        {
            InitializeComponent();
            //Открытие окна с заданным фреймом
            WinNPA.Navigate(new Страницы.Общие.PageNPA());
            Link.ChoseArea = WinNPA;
        }

        //Кнопки
        private void Main_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void BussinesPlan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Close();
        }

        //Открытие браузера и переход на страницу
        private void Rosreestr_Click(object sender, RoutedEventArgs e)
        {
            IWebDriver youtube = new ChromeDriver();
            youtube.Navigate().GoToUrl(@"https://rosreestr.gov.ru/");
            youtube.Manage().Window.Maximize();
        }

        private void Minvostok_Click(object sender, RoutedEventArgs e)
        {
            IWebDriver youtube = new ChromeDriver();
            youtube.Navigate().GoToUrl(@"https://minvr.gov.ru/");
            youtube.Manage().Window.Maximize();
        }
    }
}
