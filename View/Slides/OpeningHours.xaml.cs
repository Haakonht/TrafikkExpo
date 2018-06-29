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
using TrafikkExpo.Model;

namespace TrafikkExpo.View.Slides
{
    /// <summary>
    /// Interaction logic for OpeningHours.xaml
    /// </summary>
    public partial class OpeningHours : UserControl
    {
        public OpeningHours()
        {
            InitializeComponent();
            Mandag.Content = Storage.Monday;
            Tirsdag.Content = Storage.Tuesday;
            Onsdag.Content = Storage.Wednesday;
            Torsdag.Content = Storage.Thursday;
            Fredag.Content = Storage.Friday;
            Loaded += AnimatingControl_Loaded;
        }

        private void AnimatingControl_Loaded(object sender, RoutedEventArgs e)
        {
            var fadeIn = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(Storage.FadeTimer),
            };

            var fadeOut = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromSeconds(Storage.SlideTimer - Storage.FadeTimer),
                Duration = TimeSpan.FromSeconds(Storage.FadeTimer),
            };

            var scrollText = new DoubleAnimation()
            {
                From = 1080,
                To = -1200,
                Duration = TimeSpan.FromSeconds(Storage.SlideTimer),
            };

            Storyboard.SetTarget(fadeIn, Schedule);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath(Grid.OpacityProperty));
            Storyboard.SetTarget(fadeOut, Schedule);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath(Grid.OpacityProperty));
            Storyboard.SetTarget(scrollText, Infomatic);
            Storyboard.SetTargetProperty(scrollText, new PropertyPath("(Canvas.Top)"));


            var sb = new Storyboard();
            sb.Children.Add(fadeIn);
            sb.Children.Add(scrollText);
            sb.Children.Add(fadeOut);
            sb.Begin();
        }
    }
}
