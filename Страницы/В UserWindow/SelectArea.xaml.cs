using Diplom.Окна;
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
