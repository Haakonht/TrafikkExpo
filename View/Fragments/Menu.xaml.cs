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
using TrafikkExpo.Model;
using TrafikkExpo.View.Dialogs;

namespace TrafikkExpo.View.Fragments
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Menu()
        {
            InitializeComponent();
            Slider.Value = Storage.SlideTimer;
            Fader.Value = Storage.FadeTimer;
            SlideLabel.Content = "Tid Per Slide: " + Storage.SlideTimer + "s";
            FadeLabel.Content = "Fading Effekt: " + Storage.FadeTimer + "s";
            foreach (System.Windows.Forms.Screen Screen in System.Windows.Forms.Screen.AllScreens)
            {
                ScreenSelector.Items.Add(new Item(Screen.DeviceName, Screen.Bounds.Location.X, Screen.Bounds.Location.Y));
            }
            ScreenSelector.SelectedIndex = 0;
        }

        public void startSlideshow(object sender, RoutedEventArgs evt)
        {
            Item screenData = (Item)ScreenSelector.SelectedItem;
            Slideshow slideshow = new Slideshow();
            slideshow.WindowStartupLocation = WindowStartupLocation.Manual;
            slideshow.Left = screenData.X;
            slideshow.Top = screenData.Y;
            slideshow.Show();
        }

        public void changeOpeningHours(object sender, RoutedEventArgs evt)
        {
            OpeningHoursDialog diag = new OpeningHoursDialog();
            diag.Visibility = Visibility.Visible;
        }

        public void administrateCourses(object sender, RoutedEventArgs evt)
        {
            CourseManagerDialog diag = new CourseManagerDialog();
            diag.Visibility = Visibility.Visible;
        }

        public void exitApp(object sender, RoutedEventArgs evt)
        {
            Storage.Serialize();
            Application.Current.Shutdown();
        }

        private class Item
        {
            public string Name;
            public double X;
            public double Y;
            public Item(string name, double top, double left)
            {
                Name = name; X = top; Y = left;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Storage.SlideTimer = (int)Slider.Value;
            SlideLabel.Content = "Tid Per Slide: " + Storage.SlideTimer + "s";
        }

        private void Fader_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Storage.FadeTimer = (int)Fader.Value;
            FadeLabel.Content = "Fading Effekt: " + Storage.FadeTimer + "s";
        }
    }
}
