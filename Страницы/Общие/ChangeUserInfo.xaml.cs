using System;
using System.Globalization;
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
            SetPol(_currentUser.Пол);
            SetBirthday(_currentUser.Дата_рождения);
        }

        /// <summary>
        /// Т.к. пол пользователя храним, как строку, то при открытии окна надо задать выбранный элемент из выпадающего списка
        /// </summary>
        /// <param name="userPol"></param>
        private void SetPol(string userPol)
        {
            foreach (ComboBoxItem item in Pol.Items)
            {
                if (item.Content.ToString().ToLower().Equals(userPol.ToLower()))
                {
                    Pol.SelectedItem = item;
                }
            }
        }

        private void SetBirthday(DateTime birthday)
        {
            Birthday.Text = birthday.ToString("dd.MM.yyyy");
        }

        // Кнопка сохранения введенной информации при регистрации и проверка на ошибки
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var errorBuilder = new StringBuilder();

            if (_currentUser.ФИО.Length < 20)
                errorBuilder.AppendLine("Поле 'ФИО' не может содержать меньше 20 символов!");

            if (Convert.ToString(_currentUser.Дата_рождения).Length < 10)
                errorBuilder.AppendLine("Поле 'Дата рождения' не может содержать меньше 10 символов!");

            DateTime dateBirthday = DateTime.ParseExact(Birthday.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            {
                _currentUser.Дата_рождения = dateBirthday;
                _currentUser.Пол = Pol.Text;
                _currentUser.Пароль = Password.Password;
            }
            if (dateBirthday < new DateTime(1960, 1, 1) || new DateTime(2002, 12, 31) < dateBirthday)
                errorBuilder.AppendLine("Дата рождения не может быть меньше чем 01.01.1960 или больше чем 31.12.2002");

            if (Nationality.Text.Contains(value: "Россия".ToLower()) && Nationality.Text.Contains(value: "Украина".ToLower()) && Nationality.Text.Contains(value: "Казахстан".ToLower())
                && Nationality.Text.Contains(value: "Беларусь".ToLower()) && Nationality.Text.Contains(value: "Литва".ToLower()) && Nationality.Text.Contains(value: "Латвия".ToLower())
                && Nationality.Text.Contains(value: "Эстония".ToLower()))
                errorBuilder.AppendLine("В поле 'Гражданство' указано не разрешенное гражданство");

            if (_currentUser.Паспорт.Length < 30)
                errorBuilder.AppendLine("Поле 'Данные паспорта' не может быть меньше 30 символов!");

            if (SNILS.Text.Length < 11)
                errorBuilder.AppendLine("Поле 'СНИЛС' не может быть меньше 11 цифр!");

            if (_currentUser.ИНН.Length < 12)
                errorBuilder.AppendLine("Поле 'ИНН' не может быть меньше 12 цифр!");

            if (_currentUser.Мобильный_телефон.Length < 11)
                errorBuilder.AppendLine("Поле 'Мобильный телефон' не может быть меньше 11 цифр!");

            if (_currentUser.Адрес_электронной_почты.Length < 14)
                errorBuilder.AppendLine("Поле 'Адрес электронной почты' не может быть меньше 14 символов!");

            if (!Email.Text.Contains(value: "@mail.ru"))
                errorBuilder.AppendLine("Поле 'Адрес электронной почты' не содержит '@mail.ru'");

            if (_currentUser.Почтовый_адрес.Length < 30)
                errorBuilder.AppendLine("Поле 'Почтовый адрес' не может быть меньше 30 символов!");

            if (_currentUser.Адрес_регистрации.Length < 30)
                errorBuilder.AppendLine("Поле 'Адрес регистрации' не может быть меньше 30 символов!");

            if (errorBuilder.Length > 0)
            {
                MessageBox.Show(errorBuilder.ToString());
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

            MessageBox.Show("Чтобы увидеть изменения перейдите в свой профиль!",
                "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
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
