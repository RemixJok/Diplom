using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows;

namespace Diplom
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Открытие окна с заданным фреймом
            ChoseArea.Navigate(new Страницы.В_MainWindow.Slide1());
            Link.ChoseArea = ChoseArea;
        }

        // Простые кнопки
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Окна.LoginWindow loginWindow = new Окна.LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Окна.Registration registration = new Окна.Registration();
            registration.Show();
            Close();
        }

        // Открытие браузера и переход на страницу
        private void FindNeighbor_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vk = new ChromeDriver(driverService, new ChromeOptions());
            vk.Navigate().GoToUrl(@"https://vk.com/hectarevillage");
            vk.Manage().Window.Maximize();
        }

        private void Ipoteka_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vostokIpoteka = new ChromeDriver(driverService, new ChromeOptions());
            vostokIpoteka.Navigate().GoToUrl(@"https://erdc.ru/dv-ipoteka/");
            vostokIpoteka.Manage().Window.Maximize();
        }

        private void Rosreestr_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver rosreestr = new ChromeDriver(driverService, new ChromeOptions());
            rosreestr.Navigate().GoToUrl(@"https://rosreestr.gov.ru/");
            rosreestr.Manage().Window.Maximize();
        }

        private void Minvostok_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver minRF = new ChromeDriver(driverService, new ChromeOptions());
            minRF.Navigate().GoToUrl(@"https://minvr.gov.ru/");
            minRF.Manage().Window.Maximize();
        }

        private void youtube_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver youtube = new ChromeDriver(driverService, new ChromeOptions());
            youtube.Navigate().GoToUrl(@"https://www.youtube.com/channel/UCmDbgw1-FTeiEQzH_jMRnoQ");
            youtube.Manage().Window.Maximize();
        }

        private void VK_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vk = new ChromeDriver(driverService, new ChromeOptions());
            vk.Navigate().GoToUrl(@"https://vk.com/1hectare");
            vk.Manage().Window.Maximize();
        }
    }
}
