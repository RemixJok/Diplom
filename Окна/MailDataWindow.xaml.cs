using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Interop;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для MailDataWindow.xaml
    /// </summary>
    public partial class MailDataWindow : Window
    {
        public MailDataWindow()
        {
            InitializeComponent();

            // Вывод эл. почты в текст бокс
            txtBoxLogin.Text = DataUser.User.Адрес_электронной_почты.ToString();
        }

        // Проверка на длинну пароля
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (txtBoxPassword.Password.Length < 5)
                errorBuilder.AppendLine("Поле 'Пароль' не может содержать меньше 15 символов!");

            return errorBuilder.ToString();
        }

        // Кнопка "Войти" и запись данных из текст бокса в класс - LoginAndPassMail
        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                LoginAndPassMail.Login = txtBoxLogin.Text.ToString().Trim();
                LoginAndPassMail.Password = txtBoxPassword.Password.ToString();

                DialogResult = true;
            }
        }

        // Убирание кнопки "Закрыть" у окна
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
