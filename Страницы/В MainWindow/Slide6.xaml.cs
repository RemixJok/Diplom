﻿using System.Windows;
using System.Windows.Controls;

namespace Diplom.Страницы.В_MainWindow
{
    /// <summary>
    /// Логика взаимодействия для Slide6.xaml
    /// </summary>
    public partial class Slide6 : Page
    {
        public Slide6()
        {
            InitializeComponent();
        }

        private void ArrowLeft_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide5());
        }

        private void ArrowRight_Click(object sender, RoutedEventArgs e)
        {
            Link.ChoseArea.Navigate(new Страницы.В_MainWindow.Slide7());
        }
    }
}
