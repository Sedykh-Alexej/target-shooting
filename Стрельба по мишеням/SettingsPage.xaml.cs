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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void BtnBack(object sender, RoutedEventArgs e)
        {
            Manager.Forma.Navigate(new FormMenu());
        }

        private void purplestyle(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"PurpleStyle.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void blackstyle(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(@"BlackStyle.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }

        private void Easy(object sender, RoutedEventArgs e)
        {
            Level.lvl = "Лёгкий";
            MessageBox.Show("Вы включили лёгкий режим" + Environment.NewLine + "Кникните ок,чтобы продолжить!");
        }

        private void Medium(object sender, RoutedEventArgs e)
        {
            Level.lvl = "Средний";
            MessageBox.Show("Вы включили cредний режим" + Environment.NewLine + "Кникните ок,чтобы продолжить!");
        }

        private void Hard(object sender, RoutedEventArgs e)
        {
            Level.lvl = "Сложный";
            MessageBox.Show("Вы включили сложный режим" + Environment.NewLine + "Кникните ок,чтобы продолжить!");
        }

        private void On(object sender, RoutedEventArgs e)
        {
            HP.LowHP = 1;
            MessageBox.Show("Вы включили режим с одним хп" + Environment.NewLine + "Кникните ок,чтобы продолжить!");
        }

        private void OFF(object sender, RoutedEventArgs e)
        {
            HP.LowHP = 0;
            MessageBox.Show("Вы отключили режим с одним хп" + Environment.NewLine + "Кникните ок,чтобы продолжить!");

        }
    }
}