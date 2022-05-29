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

            // Вывод участков в ДатаГрид
            DGridArea.ItemsSource = DB.diplomEntities.Участки.ToList();
        }

        // Кнопка "Выбрать участок"
        private void SelectArea_Click(object sender, RoutedEventArgs e)
        {
            Участки path = DGridArea.SelectedItem as Участки;
            DataAreaFromGrid.areaData = DB.diplomEntities.Участки.Add(path);

            SlArea.Navigate(new WhenAreaSelected());
        }
    }
}
