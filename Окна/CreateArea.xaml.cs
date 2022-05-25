using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data.Entity;
using System.Diagnostics;
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

            UserName.Text = userName;
        }

        // Открытие или Закрытие бордера по кнопке
        private void OpenUserMenu(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Visibility == Visibility.Hidden)
                UserGrid.Visibility = Visibility.Visible;
            else
                UserGrid.Visibility = Visibility.Hidden;
        }

        // Простые кнопки
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
