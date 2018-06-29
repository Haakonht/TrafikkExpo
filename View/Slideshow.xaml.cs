using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using TrafikkExpo.Model;
using TrafikkExpo.View.Slides;

namespace TrafikkExpo.View
{
    /// <summary>
    /// Interaction logic for Slideshow.xaml
    /// </summary>
    public partial class Slideshow : Window
    {
        private int slide = 0;
        private System.Windows.Threading.DispatcherTimer dispatcherTimer;
        private double originalTime;
        private int seconds, milliseconds;

        public Slideshow()
        {
            InitializeComponent();
            originalTime = Storage.SlideTimer;
            calculateTime();
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, seconds, milliseconds);
            dispatcherTimer.Start();
        }

        private void calculateTime()
        {
            string s = Storage.SlideTimer.ToString("0.00", CultureInfo.InvariantCulture);
            string[] parts = s.Split('.');
            seconds = int.Parse(parts[0]);
            milliseconds = int.Parse(parts[1]);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (originalTime != Storage.SlideTimer)
            {
                calculateTime();
                dispatcherTimer.Interval = new TimeSpan(0, 0, 0, seconds, milliseconds);
            }
            slide++;
            SlideControl.Children.Clear();
            if (slide == 1)
            {
                SlideControl.Children.Add(new OpeningHours());
            }
            else if (slide == 2)
            {
                SlideControl.Children.Add(new Courses());
            }
            else if (slide == 3)
            {
                SlideControl.Children.Add(new Logos());
            }
            else if (slide == 4)
            {
                SlideControl.Children.Add(new MainBrand());
                slide = 0;
            }
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dispatcherTimer.IsEnabled = false;
                dispatcherTimer.Stop();
                Grid.Children.Clear();
                Close();
            }  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ResizeMode = ResizeMode.NoResize;
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            Topmost = true;
        }
    }
}
