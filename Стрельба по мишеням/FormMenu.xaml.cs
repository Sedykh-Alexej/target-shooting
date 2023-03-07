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

namespace Стрельба_по_мишеням
{
    /// <summary>
    /// Логика взаимодействия для FormMenu.xaml
    /// </summary>
    public partial class FormMenu : Page
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void Settings_Button_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new SettingsPage());
        }

        private void StartGame_Button_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new GamePage2());
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TopGamer_Button_click(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new TopGamer());
        }
    }
}
