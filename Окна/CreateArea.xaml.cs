using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для CreateArea.xaml
    /// </summary>
    public partial class CreateArea : Window
    {
        public CreateArea(string userName)
        {
            InitializeComponent();

            //Вывод деятельности на ЗУ в комбобокс
            ComboPlanActiv.ItemsSource = DB.diplomEntities.Деятельность_на_ЗУ.ToList();
            UserName.Text = userName;
        }

        //Открытие или Закрытие бордера по кнопке
        private void OpenUserMenu(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Visibility == Visibility.Hidden)
                UserGrid.Visibility = Visibility.Visible;
            else
                UserGrid.Visibility = Visibility.Hidden;
        }

        //Простые кнопки
        private void GoToSelectArea(object sender, RoutedEventArgs e)
        {
            SelectArea selectArea = new SelectArea(UserName.Text);
            selectArea.Show();
            Close();
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            UserPageStart userPage = new UserPageStart(DataUser.User);
            userPage.Show();
            Close();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            CRArea.Navigate(new Страницы.В_UserPage.FAQ());
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //Кнопка отправки заявления
        private void SendApplic_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Заявление на участок было направлено на почту для рассмотрения, после его рассмотрения вам позвонят и отправят уведомление на почту, которую вы оставили при регистрации.",
                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

            //Кнопка удаления пользователя
            DiplomEntities deleteUser = new DiplomEntities();

            //Нахождение пользователя с там же id, под которым выполнен вход
            var user = DB.diplomEntities.Пользователи.FirstOrDefault(p => p.ID_Пользователя == DataUser.User.ID_Пользователя);

            //Удаление пользователя из БД 
            DB.diplomEntities.Entry(user).State = EntityState.Deleted;
            DB.diplomEntities.SaveChanges();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //Открытие браузера и переход на страницу
        private void DownlInstr_Click(object sender, RoutedEventArgs e)
        {
            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vk = new ChromeDriver(driverService, new ChromeOptions());
            vk.Navigate().GoToUrl(@"https://fareast.parma.tech/storage/npa-doc/file_11.pdf");
            vk.Manage().Window.Maximize();
        }
    }
}
