using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
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
            SelectArea selectArea = new SelectArea();
            selectArea.Show();
            Close();
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
            //Показ ошибки, если файл не загружен
            if (TBPasport.Text.Length == 0)
            {
                TBPasport.Background = new SolidColorBrush(Colors.IndianRed);
                MessageBox.Show("Выберите файл в поле 'Паспортные данные'");
            }
            //Очистка поля, если файл загружен
            else
            {
                TBPasport.ToolTip = "";
                TBPasport.Background = Brushes.Transparent;
            }

            //Показ ошибки, если файл не загружен
            if (TBLandAppl.Text.Length == 0)
            {
                TBLandAppl.Background = new SolidColorBrush(Colors.IndianRed);
                MessageBox.Show("Выберите файл в поле 'Заявление на участок'");
            }
            //Очистка поля, если файл загружен
            else
            {
                TBLandAppl.ToolTip = "";
                TBLandAppl.Background = Brushes.Transparent;
            }

        }

        //Кнопки для выбора файла
        private void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            //Создание OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();

            //Фильтр для расширения всех файлов
            openFileDialog.Filter = " txt Файлы (*.txt)|*.txt| jpg Файлы (*.jpg)|*.jpg| jpe Файлы (*.jpe)|*.jpe| jpeg Файлы (*.jpeg)|*.jpeg| doc Файлы (*.doc)|*.doc| docs Файлы (*.docx)|*.docx|" +
                                    " xls Файлы (*.xls)|*.xls| xlsx Файлы (*.xlsx)|*.xlsx| pdf Файлы (*.pdf)|*.pdf| png Файлы (*.png)|*.png| bmp Файлы (*.bmp)|*.bmp";

            //Отображение OpenFileDialog путем вызова метода ShowDialog
            Nullable<bool> result = openFileDialog.ShowDialog();

            //Получение имени выбранного файла и отображение в TextBox
            if (result == true)
            {
                //Открытие файла
                string filename = openFileDialog.FileName;
                TBPasport.Text = filename;
            }
        }

        private void ChooseFile1_Click(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = " txt Файлы (*.txt)|*.txt| jpg Файлы (*.jpg)|*.jpg| jpe Файлы (*.jpe)|*.jpe| jpeg Файлы (*.jpeg)|*.jpeg| doc Файлы (*.doc)|*.doc| docs Файлы (*.docx)|*.docx|" +
                                    " xls Файлы (*.xls)|*.xls| xlsx Файлы (*.xlsx)|*.xlsx| pdf Файлы (*.pdf)|*.pdf| png Файлы (*.png)|*.png| bmp Файлы (*.bmp)|*.bmp";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                TBLandAppl.Text = filename;
            }
        }

        private void ChooseFile2_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = " txt Файлы (*.txt)|*.txt| jpg Файлы (*.jpg)|*.jpg| jpe Файлы (*.jpe)|*.jpe| jpeg Файлы (*.jpeg)|*.jpeg| doc Файлы (*.doc)|*.doc| docs Файлы (*.docx)|*.docx|" +
                                    " xls Файлы (*.xls)|*.xls| xlsx Файлы (*.xlsx)|*.xlsx| pdf Файлы (*.pdf)|*.pdf| png Файлы (*.png)|*.png| bmp Файлы (*.bmp)|*.bmp";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                TBOtherDoc.Text = filename;
            }
        }

        private void ChooseFile3_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = " txt Файлы (*.txt)|*.txt| jpg Файлы (*.jpg)|*.jpg| jpe Файлы (*.jpe)|*.jpe| jpeg Файлы (*.jpeg)|*.jpeg| doc Файлы (*.doc)|*.doc| docs Файлы (*.docx)|*.docx|" +
                                    " xls Файлы (*.xls)|*.xls| xlsx Файлы (*.xlsx)|*.xlsx| pdf Файлы (*.pdf)|*.pdf| png Файлы (*.png)|*.png| bmp Файлы (*.bmp)|*.bmp";
            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                TBPowerOfAttorney.Text = filename;
            }
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
