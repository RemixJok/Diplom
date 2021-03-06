using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Diplom.Страницы.Общие
{
    /// <summary>
    /// Логика взаимодействия для ChangeUserInfo.xaml
    /// </summary>
    public partial class ChangeUserInfo : Page
    {
        private Пользователи _currentUser = new Пользователи();

        public ChangeUserInfo(Пользователи selectedUser)
        {
            InitializeComponent();

            if (selectedUser != null)
                _currentUser = selectedUser;

            DataContext = _currentUser;
        }

        // Кнопка сохранения введенной информации при регистрации и проверка на ошибки
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentUser.Логин.Length < 5)
                errors.AppendLine("Поле 'Логин' не может содержать меньше 5 символов!");

            if (_currentUser.Пароль.Length < 8)
                errors.AppendLine("Поле 'Пароль' не может содержать меньше 8 символов!");

            if (_currentUser.ФИО.Length < 20)
                errors.AppendLine("Поле 'ФИО' не может содержать меньше 20 символов!");

            if (Convert.ToString(_currentUser.Дата_рождения).Length < 10)
                errors.AppendLine("Поле 'Дата рождения' не может содержать меньше 10 символов!");

            if (_currentUser.Гражданство.Length < 30)
                errors.AppendLine("Поле 'Данные паспорта' не может быть меньше 30 символов!");

            if (SNILS.Text.Length < 11)
                errors.AppendLine("Поле 'СНИЛС' не может быть меньше 11 цифр!");

            if (_currentUser.ИНН.Length < 12)
                errors.AppendLine("Поле 'ИНН' не может быть меньше 12 цифр!");

            if (_currentUser.Мобильный_телефон.Length < 11)
                errors.AppendLine("Поле 'Мобильный телефон' не может быть меньше 11 цифр!");

            if (_currentUser.Адрес_электронной_почты.Length < 14)
                errors.AppendLine("Поле 'Адрес электронной почты' не может быть меньше 14 символов!");

            if (_currentUser.Адрес_электронной_почты.Contains(value: "@") && Email.Text.Contains(value: "."))
                errors.AppendLine("Поле 'Адрес электронной почты' не содержит @ или .");

            if (_currentUser.Почтовый_адрес.Length < 30)
                errors.AppendLine("Поле 'Почтовый адрес' не может быть меньше 30 символов!");

            if (_currentUser.Адрес_регистрации.Length < 30)
                errors.AppendLine("Поле 'Адрес регистрации' не может быть меньше 30 символов!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentUser.ID_Пользователя == 0)
                DB.diplomEntities.Пользователи.Add(_currentUser);

            try
            {
                DB.diplomEntities.SaveChanges();
                MessageBox.Show("Информация сохранена!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        // Ограничение на вписание только цифр
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
