using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data.Entity;
using System.Diagnostics;
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

            // Вывод данных в textblock
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

        // Открытие или Закрытие бордера по кнопке
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

        // Навигация по фреймам
        private void BtnNpa_Click(object sender, RoutedEventArgs e)
        {
            FrameNPABP.Navigate(new Страницы.Общие.PageNPA());
        }

        private void MyProfile_Click(object sender, RoutedEventArgs e)
        {
            UserPageStart userPage = new UserPageStart(DataUser.User);
            userPage.Show();
            Close();
        }

        private void FAQ_Click(object sender, RoutedEventArgs e)
        {
            FrameNPABP.Navigate(new Страницы.В_UserPage.FAQ());
        }

        private void MyArea_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Перед тем как выбирать участок, Вам необходимо создать 'Пароль для внешних приложений', чтобы наша система смогла отправить Ваши данные на нашу почту, " +
                "пожалуйста посмотрите инструкцию и добавьте пароль. Нажмите 'ОК' и подождите пока откроется браузер с инструкцией.", "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);

            ChromeOptions options = new ChromeOptions();
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            IWebDriver vk = new ChromeDriver(driverService, new ChromeOptions());
            vk.Navigate().GoToUrl(@"https://help.mail.ru/mail/security/protection/external");
            vk.Manage().Window.Maximize();

            FrameNPABP.Navigate(new Страницы.В_UserWindow.SelectArea());
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            FrameNPABP.Navigate(new Страницы.Общие.ChangeUserInfo(DataUser.User));
        }

        private void DeleteInfo_Click(object sender, RoutedEventArgs e)
        {
            // Показ сообщения перед удалением
            MessageBoxResult result = MessageBox.Show($"Вы точно хотите удалить аккаунт пользователя {UserName.Text}?",
                "Уведомление!", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                DiplomEntities deleteUser = new DiplomEntities();

                // Нахождение пользователя с там же id, под которым выполнен вход
                var user = DB.diplomEntities.Пользователи.FirstOrDefault(p => p.ID_Пользователя == DataUser.User.ID_Пользователя);

                // Удаление пользователя из БД 
                DB.diplomEntities.Entry(user).State = EntityState.Deleted;
                DB.diplomEntities.SaveChanges();

                MessageBox.Show($"Пользователь {UserName.Text} удален");

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        // Открытие инструкции пользователя
        private void DownlInstr_Click(object sender, RoutedEventArgs e)
        {
            Process wordProcess = new Process();
            wordProcess.StartInfo.FileName = @"C:\Users\cepel\Desktop\UserInstruction.pdf";
            wordProcess.StartInfo.UseShellExecute = true;
            wordProcess.Start();
        }
    }
}
