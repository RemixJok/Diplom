using System;
using System.Linq;
using System.Windows;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DB.diplomEntities = new DiplomEntities();
        }

        //Кнопка для входа
        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Статический класс "DataUser", зранит данные о пользователе
                DataUser.User = DB.diplomEntities.Пользователи.FirstOrDefault(p => p.Логин == txtLogin.Text && p.Пароль == txtPassword.Password);

                if (DataUser.User == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    UserPageStart userPage = new UserPageStart(DataUser.User);
                    userPage.Show();
                    Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString(),
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        //Кнопка регистрации
        private void BtnGoToReg_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration(DataUser.User);
            registration.Show();
            Close();
        }

        //Кнопка назад
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        //Вотермарка в текстбоксе "Пароль"
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password.Length > 0)
            {
                Watermark.Visibility = Visibility.Collapsed;
            }
            else
            {
                Watermark.Visibility = Visibility.Visible;
            }
        }
    }
}
