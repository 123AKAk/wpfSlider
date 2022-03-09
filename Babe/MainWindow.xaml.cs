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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Babe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string _imageDirectory = System.IO.Directory.GetCurrentDirectory();
        private DispatcherTimer htimer;
        Random _random = new Random();

        int numbers = 0;
        public MainWindow()
        {
            InitializeComponent();           
        }
        
        //windows loaded display pictures
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] imagePaths = System.IO.Directory.GetFiles(_imageDirectory, "*.jpg");

            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[0]));
            image.Source = bitmapImage;

            htimer = new DispatcherTimer();
            htimer.Interval = new TimeSpan(0, 0, 5);
            htimer.Tick += timer_tick;
            htimer.Start();
        }

        // all timing starts here        
        private void timer_tick(object sender, EventArgs e)
        {
            numbers++;
            DoubleAnimation badass = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = false
            };
            image.BeginAnimation(OpacityProperty, badass);
            image.Opacity = 100;            
              
            string[] imagePaths = System.IO.Directory.GetFiles(_imageDirectory, "*.jpg");            
            if(numbers == imagePaths.Length)
            {
                numbers = 0;
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[numbers]));
                image.Source = bitmapImage;
            }
            else
            {                
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[numbers]));
                image.Source = bitmapImage;
            }            
            htimer.Stop();
            htimer.Start();
        }

        //previous
        private void button_Click(object sender, RoutedEventArgs e)
        {
            string[] imagePaths = System.IO.Directory.GetFiles(_imageDirectory, "*.jpg");
            if (numbers != 0)
            {
                numbers--;
                htimer.Stop();
                DoubleAnimation badass = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    AutoReverse = false
                };
                image.BeginAnimation(OpacityProperty, badass);
                image.Opacity = 100;
                
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[numbers]));
                image.Source = bitmapImage;

                htimer.Start();
            }
            else
            {
                numbers = imagePaths.Length - 1;
                                
                htimer.Stop();
                DoubleAnimation badass = new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                    AutoReverse = false
                };
                image.BeginAnimation(OpacityProperty, badass);
                image.Opacity = 100;

                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[numbers]));
                image.Source = bitmapImage;

                htimer.Start();
            }
        }

        //next
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            htimer.Stop();
            numbers++;
            DoubleAnimation badass = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
                AutoReverse = false
            };
            image.BeginAnimation(OpacityProperty, badass);
            image.Opacity = 100;
            
            string[] imagePaths = System.IO.Directory.GetFiles(_imageDirectory, "*.jpg");

            if (numbers == imagePaths.Length)
            {
                numbers = 0;
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[numbers]));
                image.Source = bitmapImage;
            }
            else
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[numbers]));
                image.Source = bitmapImage;
            }

            htimer.Start();
        }
    }
}
