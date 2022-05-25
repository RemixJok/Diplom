using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для SelectArea.xaml
    /// </summary>
    public partial class SelectArea : Window
    {
        public SelectArea(string userName)
        {
            InitializeComponent();

            // Вывод участков в ДатаГрид
            DGridArea.ItemsSource = DB.diplomEntities.Участки.ToList();
            UserName.Text = userName;
        }

        // Кнопка выбора участка
        private void SelectArea_Click(object sender, RoutedEventArgs e)
        {
            Участки path = DGridArea.SelectedItem as Участки;
            DataAreaFromGrid.areaData = DB.diplomEntities.Участки.Add(path);

            WhenAreaSelected areaSelected = new WhenAreaSelected(UserName.Text);
            areaSelected.Show();
            Close();
        }

        // Открытие или Закрытие бордера по кнопке
        private void OpenUserMenu(object sender, RoutedEventArgs e)
        {
            if (UserGrid.Visibility == Visibility.Hidden)
                UserGrid.Visibility = Visibility.Visible;
            else
                UserGrid.Visibility = Visibility.Hidden;
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

        // Обновление списка участков
        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //if (Visibility == Visibility.Visible)
            //{
            //   DB.diplomEntities.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            //    DGridArea.ItemsSource = DB.diplomEntities.Участки.ToList();
            //}
        }
    }
}
