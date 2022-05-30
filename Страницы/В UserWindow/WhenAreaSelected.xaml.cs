using Diplom.Окна;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace Diplom.Страницы.В_UserWindow
{
    /// <summary>
    /// Логика взаимодействия для WhenAreaSelected.xaml
    /// </summary>
    public partial class WhenAreaSelected : Page
    {
        public WhenAreaSelected()
        {
            InitializeComponent();

            // Вывод данных в textbox
            Region.Text = DataAreaFromGrid.areaData.Регион.ToString().Trim();
            Adress.Text = DataAreaFromGrid.areaData.Адрес.ToString().Trim();
            DateToUchet.Text = DataAreaFromGrid.areaData.Дата_постановки_на_учет.ToShortDateString().Trim();
            Square.Text = DataAreaFromGrid.areaData.Площадь_ЗУ.ToString().Trim();

            ComboPlanActiv.ItemsSource = DB.diplomEntities.Деятельность_на_ЗУ.ToList(); // Вывод из таблицы "Деятельность на ЗУ" в комбобокс
        }

        // Кнопка "Выбрать другой участок"
        private void ChoseArea_Click(object sender, RoutedEventArgs e)
        {
            WhenAreaSl.Navigate(new SelectArea());
        }

        // Кнопка "Отправить заявление"
        private void SendApplic_Click(object sender, RoutedEventArgs e)
        {
            MailDataWindow mailData = new MailDataWindow();
            mailData.ShowDialog();                                      // Открытие нового окна, пока оно не закроется, программа дальше не будет работать

            var userLogin = LoginAndPassMail.Login.ToString();          // Запись "Логина" из класса в переменную
            var userPassword = LoginAndPassMail.Password.ToString();    // Запись "Пароля" из класса в переменную

            MessageBox.Show("Подождите несоколько секунд выполняется отправка данных, по завершении отправки Вы увидите уведомление об успешной отправке",
                "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);

            // Переменные, в которые заносятся данные пользователя для импорта в ворд, данные беруться из классов DataUser и DataAreaFromGrid
            var idUser = DataUser.User.ID_Пользователя.ToString();
            var name = DataUser.User.ФИО.ToString();
            var pol = DataUser.User.Пол.ToString();
            var birthday = DataUser.User.Дата_рождения.ToString("dd.MM.yyyy");
            var nationality = DataUser.User.Гражданство.ToString();
            var pasport = DataUser.User.Паспорт.ToString();
            var snils = DataUser.User.СНИЛС.ToString();
            var inn = DataUser.User.ИНН.ToString();
            var phone = DataUser.User.Мобильный_телефон.ToString();
            var email = DataUser.User.Адрес_электронной_почты.ToString();
            var mailAdress = DataUser.User.Почтовый_адрес.ToString();
            var registrationAdress = DataUser.User.Адрес_регистрации.ToString();

            var idArea = DataAreaFromGrid.areaData.ID_Участка.ToString();
            var region = DataAreaFromGrid.areaData.Регион.ToString();
            var adress = DataAreaFromGrid.areaData.Адрес.ToString();
            var dateToUchet = DataAreaFromGrid.areaData.Дата_постановки_на_учет.ToShortDateString();
            var square = DataAreaFromGrid.areaData.Площадь_ЗУ.ToString();
            var status = DataAreaFromGrid.areaData.ToString();

            // Создание нового документа Word
            var application = new Word.Application();

            Word.Document document = application.Documents.Add();

            // Создание параграфа для хранения названий страницы
            Word.Paragraph userParagraph = document.Paragraphs.Add();
            Word.Range userRange = userParagraph.Range;

            // Добавление заголовка
            userRange.Text = "Информация о пользователе и участке";
            userParagraph.set_Style("Заголовок");
            userRange.InsertParagraphAfter();

            // Добавление таблицы
            Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = tableParagraph.Range;
            Word.Table userInfoTable = document.Tables.Add(tableRange, 18, 2); // Сколько строк и колонок
            userInfoTable.Borders.InsideLineStyle = userInfoTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            userInfoTable.Range.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            // Добавление название колонок
            Word.Range cellRange;

            cellRange = userInfoTable.Cell(1, 1).Range;
            cellRange.Text = "Наименование";
            cellRange = userInfoTable.Cell(1, 2).Range;
            cellRange.Text = "Данные";

            cellRange = userInfoTable.Cell(2, 1).Range;
            cellRange.Text = "ID_Пользователя";
            cellRange = userInfoTable.Cell(2, 2).Range;
            cellRange.Text = idUser;

            cellRange = userInfoTable.Cell(3, 1).Range;
            cellRange.Text = "ФИО";
            cellRange = userInfoTable.Cell(3, 2).Range;
            cellRange.Text = name;

            cellRange = userInfoTable.Cell(4, 1).Range;
            cellRange.Text = "Пол";
            cellRange = userInfoTable.Cell(4, 2).Range;
            cellRange.Text = pol;

            cellRange = userInfoTable.Cell(5, 1).Range;
            cellRange.Text = "Дата рождения";
            cellRange = userInfoTable.Cell(5, 2).Range;
            cellRange.Text = birthday;

            cellRange = userInfoTable.Cell(6, 1).Range;
            cellRange.Text = "Гражданство";
            cellRange = userInfoTable.Cell(6, 2).Range;
            cellRange.Text = nationality;

            cellRange = userInfoTable.Cell(7, 1).Range;
            cellRange.Text = "Данные паспорта";
            cellRange = userInfoTable.Cell(7, 2).Range;
            cellRange.Text = pasport;

            cellRange = userInfoTable.Cell(8, 1).Range;
            cellRange.Text = "СНИЛС";
            cellRange = userInfoTable.Cell(8, 2).Range;
            cellRange.Text = snils;

            cellRange = userInfoTable.Cell(9, 1).Range;
            cellRange.Text = "ИНН";
            cellRange = userInfoTable.Cell(9, 2).Range;
            cellRange.Text = inn;

            cellRange = userInfoTable.Cell(10, 1).Range;
            cellRange.Text = "Мобильный телефон";
            cellRange = userInfoTable.Cell(10, 2).Range;
            cellRange.Text = phone;

            cellRange = userInfoTable.Cell(11, 1).Range;
            cellRange.Text = "Электронная почта";
            cellRange = userInfoTable.Cell(11, 2).Range;
            cellRange.Text = email;

            cellRange = userInfoTable.Cell(12, 1).Range;
            cellRange.Text = "Почтовый адрес";
            cellRange = userInfoTable.Cell(12, 2).Range;
            cellRange.Text = mailAdress;

            cellRange = userInfoTable.Cell(13, 1).Range;
            cellRange.Text = "Адрес регистрации";
            cellRange = userInfoTable.Cell(13, 2).Range;
            cellRange.Text = registrationAdress;

            cellRange = userInfoTable.Cell(14, 1).Range;
            cellRange.Text = "ID_Участка";
            cellRange = userInfoTable.Cell(14, 2).Range;
            cellRange.Text = idArea;

            cellRange = userInfoTable.Cell(15, 1).Range;
            cellRange.Text = "Регион";
            cellRange = userInfoTable.Cell(15, 2).Range;
            cellRange.Text = region;

            cellRange = userInfoTable.Cell(16, 1).Range;
            cellRange.Text = "Адрес";
            cellRange = userInfoTable.Cell(16, 2).Range;
            cellRange.Text = adress;

            cellRange = userInfoTable.Cell(17, 1).Range;
            cellRange.Text = "Дата постановки на учет";
            cellRange = userInfoTable.Cell(17, 2).Range;
            cellRange.Text = dateToUchet;

            cellRange = userInfoTable.Cell(18, 1).Range;
            cellRange.Text = "Площадь земельного участка";
            cellRange = userInfoTable.Cell(18, 2).Range;
            cellRange.Text = square;

            document.SaveAs2(@"C:\Users\cepel\Desktop\Заявление.docx");
            document.Close();
            application.Quit();

            // Протоколы, на всякий случай
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Tls12
                | SecurityProtocolType.Ssl3
                | SecurityProtocolType.Tls
                | SecurityProtocolType.Tls11;

            // Отправка E-mail письма
            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential
            {
                Password = userPassword,
                UserName = userLogin,
            }; // Логин и пароль от почты пользователя

            // Порт, хост и включение ssl протокола для работы отправки
            client.Port = 2525;
            client.Host = "smtp.mail.ru";
            client.EnableSsl = true;

            MailMessage message = new MailMessage();
            message.From = new MailAddress(DataUser.User.Адрес_электронной_почты.ToString(), DataUser.User.ФИО); // От кого
            message.To.Add(new MailAddress("cepelev2001@mail.ru"));                                              // Кому
            message.Subject = $"Заявление на участок от пользователя {name}";                                    // Заголовок письма
            message.BodyEncoding = System.Text.Encoding.UTF8;                                                    // Кодировка
            message.Attachments.Add(new Attachment(@"C:\Users\cepel\Desktop\Заявление.docx"));                   // Добавление документа в письмо

            client.Send(message);
            client.Dispose();

            MessageBox.Show("Заявление на участок было направлено на почту для рассмотрения, после его рассмотрения вам позвонят и отправят уведомление на почту, которую вы оставили при регистрации.",
                "Уведомление!", MessageBoxButton.OK, MessageBoxImage.Information);

            // Удаление участка
            DiplomEntities deleteArea = new DiplomEntities();

            // Нахождение участка с там же id, который был выбран
            var area = DB.diplomEntities.Участки.FirstOrDefault(p => p.ID_Участка == DataAreaFromGrid.areaData.ID_Участка);

            // Удаление участка из БД
            DB.diplomEntities.Entry(area).State = EntityState.Deleted;
            DB.diplomEntities.SaveChanges();

            /*// Удаления пользователя
            DiplomEntities deleteUser = new DiplomEntities();

            // Нахождение пользователя с там же id, под которым выполнен вход
            var user = DB.diplomEntities.Пользователи.FirstOrDefault(p => p.ID_Пользователя == DataUser.User.ID_Пользователя);

            // Удаление пользователя из БД 
            DB.diplomEntities.Entry(user).State = EntityState.Deleted;
            DB.diplomEntities.SaveChanges();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();*/
        }
    }
}
