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
using System.Windows.Threading; //чтобы можно было использовать диспетчер времени

namespace Стрельба_по_мишеням
{
    /// <summary>
    /// Логика взаимодействия для GamePage2.xaml
    /// </summary>
    public partial class GamePage2 : Page
    {
        DispatcherTimer gameTimer = new DispatcherTimer(); //создание нового экземпляра диспетчера времени

        List<Ellipse> removeThis = new List<Ellipse>(); // составляем список на удаление элементов

        
        int spawnRate; //скорость появления кругов по умолчанию
        int currentRate; //текущая скорость поможет добавить интервал между появлением кругов
        int lastScore; //Лучший счёт игрока
        int health;  //общее состояние здоровья игрока в начале игры
        int posX; //x положение кругов
        int posY; //y положение кругов
        int score = 0; //текущий счет за игру

        double growthRate = 0.6; //скорость роста по умолчанию для каждого круга в игре
        Random rand = new Random(); //генератор случайных чисел

        MediaPlayer playClickSound = new MediaPlayer();
        MediaPlayer playerBangSound = new MediaPlayer();

        Uri ClickedSound;
        Uri BangSound;

        Brush brush; //цвет для кругов
        public GamePage2()
        {
            //инстркуции для начала игры
            InitializeComponent();
            gameTimer.Tick += GameLoop; //задаём начало игрового цикла
            gameTimer.Interval = TimeSpan.FromMilliseconds(20); //один итервал занимает 20 милисекунд
            gameTimer.Start(); //стартует внутри игровой таймер

            currentRate = spawnRate; //установливаем дефолтную скорость

            BangSound = new Uri("pack://siteoforigin:,,,/sound/Звук пропуска мишени.mp3");
            ClickedSound = new Uri("pack://siteoforigin:,,,/sound/Выстрел.mp3");

            if (Level.lvl == "Лёгкий")
            {
                spawnRate = 80;
            }
            if (Level.lvl == "Средний")
            {
                spawnRate = 60;
            }
            if (Level.lvl == "Сложный")
            {
                spawnRate = 40;
            }
            if (HP.LowHP == 1)
            {
                health = 2;
            }
            if (HP.LowHP == 0)
            {
                health = 350;
            }
        }
        /*Итерации за один тик таймера*/
        private void GameLoop(object sender, EventArgs e)
        {

            //обновляем счет и показываем последний счет
            txtScore.Content = "Счёт: " + score;
            txtLastScore.Content = "Лучший счёт: " + lastScore;

            currentRate -= 2;

            if (currentRate < 1)
            {
                currentRate = spawnRate;

                posX = rand.Next(15, 936);
                posY = rand.Next(50, 575);

                // создайте случайный цвет для кругов и сохраните его внутри кисти
                brush = new SolidColorBrush(Color.FromRgb((byte)rand.Next(1, 255), (byte)rand.Next(1, 255), (byte)rand.Next(1, 255)));

                //Дефолтные настройки эллипса
                Ellipse circle = new Ellipse
                {

                    Tag = "circle",
                    Height = 10,
                    Width = 10,
                    Stroke = Brushes.Black,
                    StrokeThickness = 1,
                    Fill = brush

                };

                //помещает эллипс на ранее загатовленные координаты
                Canvas.SetLeft(circle, posX);
                Canvas.SetTop(circle, posY);
                // Добавляет круг
                MyCanvas.Children.Add(circle);
            }

            // Для каждого цикла ниже вы найдете каждый эллипс внутри холста и вырастите его 

            foreach (var x in MyCanvas.Children.OfType<Ellipse>())
            {
                // мы ищем холст и находим эллипс, который существует внутри него

                x.Height += growthRate; //Увеличивает высоту круга
                x.Width += growthRate; //Увеличивает ширину круга
                x.RenderTransformOrigin = new Point(0.5, 0.5); //Увеличиваем размер круга на 0.5

                //если ширина круга превышает 70, мы хотим, чтобы он взорвался

                if (x.Width > 70)
                {
                    removeThis.Add(x);
                    health -= 15;
                    playerBangSound.Open(BangSound);
                    playerBangSound.Play();

                }

            }

            if (health > 1)
            {
                //связываем хитбар с нынешними хп
                healthBar.Width = health;
            }
            else
            {
                GameOverFunction();
            }


            foreach (Ellipse i in removeThis)
            {
                MyCanvas.Children.Remove(i); //удаляет эллипс с рабочей области
            }

            if (score > 10 && score < 11)
            {
                spawnRate -=10;
            }
            if (score > 100 && score < 101)
            {
                spawnRate -=10;
                growthRate = 1.5;
            }
            if (score > 1000 && score < 1001)
            {
                spawnRate -=10;
            }


        }
        private void CanvasClicking(object sender, MouseButtonEventArgs e)
        {
            //Если мы нажали на эллипс
            if (e.OriginalSource is Ellipse)
            {
                //// создайте локальный эллипс и свяжите его с исходным источником
                Ellipse circle = (Ellipse)e.OriginalSource;

                //Теперь мы удаляем его с экрана
                MyCanvas.Children.Remove(circle);

                score++;

                //Загружаем звук выстрела в медиаплеер
                playClickSound.Open(ClickedSound);
                playClickSound.Play();
            }
        }

        private void GameOverFunction()
        {

            gameTimer.Stop();

            //Вывод окна и джём пока пользователь нажмёт ок
            MessageBox.Show("Игра окончена" + Environment.NewLine + "Ваш счёт: " + score + Environment.NewLine + "Нажмите ок для продолжения.");

            foreach (var y in MyCanvas.Children.OfType<Ellipse>())
            {
                //Удаляем все эллипсы
                removeThis.Add(y);
            }

            foreach (Ellipse i in removeThis)
            {
                MyCanvas.Children.Remove(i);
            }

            //Откатываем все переменные
            growthRate = .6;
            if (Level.lvl == "Лёгкий")
            {
                spawnRate = 80;
            }
            if (Level.lvl == "Средний")
            {
                spawnRate = 60;
            }
            if (Level.lvl == "Сложный")
            {
                spawnRate = 40;
            }
            if (lastScore < score)
            {
                lastScore = score;
            }
            score = 0;
            currentRate = 5;
            if (HP.LowHP == 1)
            {
                health = 2;
            }
            if (HP.LowHP == 0)
            {
                health = 350;
            }
            removeThis.Clear();
            gameTimer.Start();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Level.score = lastScore;
            gameTimer.Stop();
            Manager.Forma.Navigate(new Player());
        }

        private void Exit_menu(object sender, RoutedEventArgs e)
        {
            gameTimer.Stop();
            Manager.Forma.Navigate(new FormMenu());
        }
    }
}
