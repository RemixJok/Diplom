using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для UserPageStart.xaml
    /// </summary>
    public partial class UserPageStart : Window
    {
        public UserPageStart(Пользователи selectedUser)
        {
            InitializeComponent();

            //Вывод данных в textblock
            UserName.Text = selectedUser.ФИО.Trim();
            FIO.Text = selectedUser.ФИО.Trim();
            Pol.Text = selectedUser.Пол;
            Birthday.Text = selectedUser.Дата_рождения.ToString("dd.MM.yyyy");
            Nationality.Text = selectedUser.Гражданство.Trim();
            Pasport.Text = selectedUser.Паспорт.Trim();
            SNILS.Text = selectedUser.СНИЛС.Trim();
            INN.Text = selectedUser.ИНН.Trim();
            Phone.Text = selectedUser.Мобильный_телефон.Trim();
            Email.Text = selectedUser.Адрес_электронной_почты.Trim();
            MailAdress.Text = selectedUser.Почтовый_адрес.Trim();
            RegAdress.Text = selectedUser.Адрес_регистрации.Trim();
        }

        //Открытие или Закрытие бордера по кнопке
        private void OpenList(object sender, RoutedEventArgs e)
        {
            if (ListGrid.Visibility == Visibility.Hidden)
                ListGrid.Visibility = Visibility.Visible;
            else
                ListGrid.Visibility = Visibility.Hidden;
        }

        private void OpenUserMenu(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Visibility == Visibility.Hidden)
                UserGrid.Visibility = Visibility.Visible;
            else
                UserGrid.Visibility = Visibility.Hidden;
        }

        private void OpenMoreInfo(object sender, RoutedEventArgs e)
        {
            if (MoreInfo.Visibility == Visibility.Hidden)
                MoreInfo.Visibility = Visibility.Visible;
            else
                MoreInfo.Visibility = Visibility.Hidden;
        }

        //Навигация по фреймам
        private void BtnNpa_Click(object sender, RoutedEventArgs e)
        {
            FrameNPABP.Navigate(new Страницы.Общие.PageNPA());
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            /*UserPageStart userPage = new UserPageStart(null);
            userPage.Show();
            Close();*/

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            FrameNPABP.Navigate(new Страницы.В_UserPage.FAQ());
        }

        //Простые кнопки
        private void MyArea_Click(object sender, RoutedEventArgs e)
        {
            CreateArea createArea = new CreateArea(UserName.Text);
            createArea.Show();
            Close();
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            FrameNPABP.Navigate(new Страницы.Общие.ChangeUserInfo((sender as Button).DataContext as Пользователи));
        }

        private void DeleteInfo_Click(object sender, RoutedEventArgs e)
        {

            DiplomEntities deleteUser = new DiplomEntities();

            Пользователи user = deleteUser.Пользователи.Where(p => p.ID_Пользователя == 1).FirstOrDefault();

            deleteUser.Пользователи.Remove(user);
            deleteUser.SaveChanges();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
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
