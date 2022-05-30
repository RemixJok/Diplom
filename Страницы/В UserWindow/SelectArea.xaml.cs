using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_UserWindow
{
    /// <summary>
    /// Логика взаимодействия для SelectArea.xaml
    /// </summary>
    public partial class SelectArea : Page
    {
        public SelectArea()
        {
            InitializeComponent();

            DGridArea.ItemsSource = DB.diplomEntities.Участки.ToList();      // Вывод участков в ДатаГрид
        }

        // Кнопка "Выбрать участок"
        private void SelectArea_Click(object sender, RoutedEventArgs e)
        {
            Участки path = DGridArea.SelectedItem as Участки;                // Запись выбранного участка в переменную (path)
            DataAreaFromGrid.areaData = DB.diplomEntities.Участки.Add(path); // Запись данных из переменной (path) в класс DataAreaFromGrid

            SlArea.Navigate(new WhenAreaSelected());                         // Переход на следующую страницу
        }
    }
}
