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
    /// Логика взаимодействия для TopGamer.xaml
    /// </summary>
    public partial class TopGamer : Page
    {
        public TopGamer()
        {
            InitializeComponent();
            DGridGamers.ItemsSource = ApplicationContex.GetContext().Gamers.ToList();
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new FormMenu());
        }
    }
}
