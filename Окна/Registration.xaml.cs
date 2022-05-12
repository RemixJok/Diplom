using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Diplom.Окна
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private Пользователи _currentЛогин = null;
        private Пользователи _currentСНИЛС = null;
        private Пользователи _currentИНН = null;

        public Registration()
        {
            InitializeComponent();
            DB.diplomEntities = new DiplomEntities();
        }


        //Кнопка регистрации
        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            var errorMessage = CheckErrors();
            if (errorMessage.Length > 0)
            {
                MessageBox.Show(errorMessage, "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Добавление данных в БД
                var newUser = new Пользователи()
                {
                    Логин = Login.Text.Trim().ToLower(),
                    Пароль = Password.Password.Trim(),
                    ФИО = FIO.Text.Trim(),
                    Пол = Pol.Text.ToLower(),
                    Дата_рождения = Convert.ToDateTime(Birthday.Text).ToLocalTime(),
                    Гражданство = Nationality.Text.Trim().ToLower(),
                    Паспорт = Pasport.Text.Trim().ToLower(),
                    СНИЛС = SNILS.Text.Trim(),
                    ИНН = INN.Text.Trim(),
                    Адрес_электронной_почты = Email.Text.Trim(),
                    Почтовый_адрес = MailAddress.Text.Trim(),
                    Адрес_регистрации = RegAddress.Text.Trim()
                };
                DB.diplomEntities.Пользователи.Add(newUser);
                DB.diplomEntities.SaveChanges();

                MessageBox.Show("Пользователь успешно добавлен!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }
        }

        //Кнопка назад
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Окна.LoginWindow loginWindow = new Окна.LoginWindow();
            loginWindow.Show();
            Close();
        }

        //Проверка на ошибки
        private string CheckErrors()
        {
            var errorBuilder = new StringBuilder();

            if (Login.Text.Length < 5)
                errorBuilder.AppendLine("Поле 'Логин' не может содержать меньше 5 символов!");

            var loginFromDB = DB.diplomEntities.Пользователи.ToList().FirstOrDefault(p => p.Логин.ToLower() == Login.Text.ToLower());
            if (loginFromDB != null && loginFromDB != _currentЛогин)
                errorBuilder.AppendLine("Такой логин уже зарегистрирован!");

            if (Password.Password.Length < 8)
                errorBuilder.AppendLine("Поле 'Пароль' не может содержать меньше 8 символов!");

            if (FIO.Text.Length < 20)
                errorBuilder.AppendLine("Поле 'ФИО' не может содержать меньше 20 символов!");

            if (string.IsNullOrWhiteSpace(Pol.Text))
                errorBuilder.AppendLine("Поле 'Пол' не может быть пустым!");

            if (Birthday.Text.Length < 10)
                errorBuilder.AppendLine("Поле 'Дата рождения' не может содержать меньше 10 символов!");

            if (Pasport.Text.Length < 30)
                errorBuilder.AppendLine("Поле 'Данные паспорта' не может быть меньше 30 символов!");

            if (SNILS.Text.Length < 11)
                errorBuilder.AppendLine("Поле 'СНИЛС' не может быть меньше 11 цифр!");

            var SNILSFromDB = DB.diplomEntities.Пользователи.ToList().FirstOrDefault(p => p.СНИЛС == SNILS.Text);
            if (SNILSFromDB != null && SNILSFromDB != _currentСНИЛС)
                errorBuilder.AppendLine("Такой СНИЛС уже зарегистрирован!");

            if (INN.Text.Length < 12)
                errorBuilder.AppendLine("Поле 'ИНН' не может быть меньше 12 цифр!");

            var INNFromDB = DB.diplomEntities.Пользователи.ToList().FirstOrDefault(p => p.ИНН == INN.Text);
            if (INNFromDB != null && INNFromDB != _currentИНН)
                errorBuilder.AppendLine("Такой ИНН уже зарегистрирован!");

            if (Phone.Text.Length < 11)
                errorBuilder.AppendLine("Поле 'Мобильный телефон' не может быть меньше 11 цифр!");

            if (Email.Text.Length < 10)
                errorBuilder.AppendLine("Поле 'Адрес электронной почты' не может быть меньше 10 символов!");

            if (MailAddress.Text.Length < 30)
                errorBuilder.AppendLine("Поле 'Почтовый адрес' не может быть меньше 30 символов!");

            if (RegAddress.Text.Length < 30)
                errorBuilder.AppendLine("Поле 'Адрес регистрации' не может быть меньше 30 символов!");

            return errorBuilder.ToString();
        }


        //Ограничение на вписание только цифр
        private void Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }

        private void INN_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }

        private void SNILS_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
