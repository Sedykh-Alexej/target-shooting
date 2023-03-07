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
    /// Логика взаимодействия для Player.xaml
    /// </summary>
    public partial class Player : Page
    {
        public Player()
        {
            InitializeComponent();
            txtScore.Content = Level.score;
            txtLevel.Content = Level.lvl;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            string Nickname = Nick.Text;
            int Score = Level.score;
            string Complexity = Level.lvl;

            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(Nick.Text))
                errors.AppendLine("Укажите ник пожалуйста");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            Gamer gamer = new Gamer(Nickname,Score,Complexity);
            ApplicationContex.GetContext().Gamers.Add(gamer);

            try
            {
                ApplicationContex.GetContext().SaveChanges();
                Manager.Forma.Navigate(new FormMenu());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
