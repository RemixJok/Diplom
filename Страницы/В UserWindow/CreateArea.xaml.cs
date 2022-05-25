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
    /// Логика взаимодействия для CreateArea.xaml
    /// </summary>
    public partial class CreateArea : Page
    {
        public CreateArea()
        {
            InitializeComponent();
        }

        private void GoToSelectArea(object sender, RoutedEventArgs e)
        {
            CrArea.Navigate(new Страницы.В_UserWindow.SelectArea());
        }
    }
}
