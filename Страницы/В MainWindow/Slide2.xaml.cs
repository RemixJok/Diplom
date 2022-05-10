using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide2.xaml
    /// </summary>
    public partial class Slide2 : Page
    {
        public Slide2()
        {
            InitializeComponent();
        }

        private void GroupVK_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vk = new ChromeDriver(driverService, new ChromeOptions());
            vk.Navigate().GoToUrl(@"https://vk.com/hectarevillage");
            vk.Manage().Window.Maximize();
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide1());
        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide3());
        }
    }
}
