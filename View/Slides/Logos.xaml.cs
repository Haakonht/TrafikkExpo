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
    public partial class Logos : UserControl
    {
        public Logos()
        {
            InitializeComponent();
            Loaded += AnimatingControl_Loaded;
        }

        private void AnimatingControl_Loaded(object sender, RoutedEventArgs e)
        {
            double logolengde = SlideTimer / 3;
            var fadeInRH = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(logolengde / 2),
            };

            var fadeOutRH = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromSeconds(logolengde / 2),
                Duration = TimeSpan.FromSeconds(logolengde / 2),
            };

            var fadeInSEM = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                BeginTime = TimeSpan.FromSeconds(logolengde),
                Duration = TimeSpan.FromSeconds(logolengde / 2),
            };

            var fadeOutSEM = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromSeconds(logolengde + (logolengde / 2)),
                Duration = TimeSpan.FromSeconds(logolengde / 2),
            };

            var fadeInBOB = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                BeginTime = TimeSpan.FromSeconds(logolengde * 2),
                Duration = TimeSpan.FromSeconds(logolengde / 2),
            };

            var fadeOutBOB = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                BeginTime = TimeSpan.FromSeconds(logolengde * 2 + (logolengde / 2)),
                Duration = TimeSpan.FromSeconds(logolengde / 2),
            };

            Storyboard.SetTarget(fadeInRH, rh);
            Storyboard.SetTargetProperty(fadeInRH, new PropertyPath(Image.OpacityProperty));
            Storyboard.SetTarget(fadeOutRH, rh);
            Storyboard.SetTargetProperty(fadeOutRH, new PropertyPath(Image.OpacityProperty));
            Storyboard.SetTarget(fadeInSEM, sem);
            Storyboard.SetTargetProperty(fadeInSEM, new PropertyPath(Image.OpacityProperty));
            Storyboard.SetTarget(fadeOutSEM, sem);
            Storyboard.SetTargetProperty(fadeOutSEM, new PropertyPath(Image.OpacityProperty));
            Storyboard.SetTarget(fadeInBOB, bob);
            Storyboard.SetTargetProperty(fadeInBOB, new PropertyPath(Image.OpacityProperty));
            Storyboard.SetTarget(fadeOutBOB, bob);
            Storyboard.SetTargetProperty(fadeOutBOB, new PropertyPath(Image.OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(fadeInRH);
            sb.Children.Add(fadeOutRH);
            sb.Children.Add(fadeInSEM);
            sb.Children.Add(fadeOutSEM);
            sb.Children.Add(fadeInBOB);
            sb.Children.Add(fadeOutBOB);
            sb.Begin();
        }
    }
}
