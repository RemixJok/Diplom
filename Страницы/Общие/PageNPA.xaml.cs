using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.Общие
{
    /// <summary>
    /// Логика взаимодействия для PageNPA.xaml
    /// </summary>
    public partial class PageNPA : Page
    {
        public PageNPA()
        {
            InitializeComponent();
        }

        //Открытие браузера и переход на страницу
        private void FederZakon_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vk = new ChromeDriver(driverService, new ChromeOptions());
            vk.Navigate().GoToUrl(@"https://fareast.parma.tech/storage/npa-doc/file_11.pdf");
            vk.Manage().Window.Maximize();
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

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver youtube = new ChromeDriver(driverService, new ChromeOptions());
            youtube.Navigate().GoToUrl(@"https://www.youtube.com/channel/UCmDbgw1-FTeiEQzH_jMRnoQ");
            youtube.Manage().Window.Maximize();
        }
    }
}
