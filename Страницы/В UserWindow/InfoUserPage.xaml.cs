using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diplom.Страницы.В_UserWindow
{
    /// <summary>
    /// Логика взаимодействия для InfoUserPage.xaml
    /// </summary>
    public partial class InfoUserPage : Page
    {
        public InfoUserPage(Пользователи selectedUser)
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

        private void OpenMoreInfo(object sender, RoutedEventArgs e)
        {

        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
