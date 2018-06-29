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
using TrafikkExpo.View.Prototypes;
using static TrafikkExpo.Model.Storage;

namespace TrafikkExpo.View.Slides
{
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : UserControl
    {
        public Courses()
        {
            InitializeComponent();
            foreach (Course c in Storage.Courses)
            {
                CourseRow row = new CourseRow(c, false);
                Table.Children.Add(row);
            }
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
                BeginTime = TimeSpan.FromSeconds(SlideTimer - Storage.FadeTimer),
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
            Storyboard.SetTarget(scrollText, Klasser);
            Storyboard.SetTargetProperty(scrollText, new PropertyPath("(Canvas.Top)"));

            var sb = new Storyboard();
            sb.Children.Add(fadeIn);
            sb.Children.Add(scrollText);
            sb.Children.Add(fadeOut);
            sb.Begin();
        }
    }
}
