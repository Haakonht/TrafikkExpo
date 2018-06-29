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
    public partial class MainBrand : UserControl
    {
        public MainBrand()
        {
            InitializeComponent();
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

            Storyboard.SetTarget(fadeIn, trafikkeriet);
            Storyboard.SetTargetProperty(fadeIn, new PropertyPath(Image.OpacityProperty));
            Storyboard.SetTarget(fadeOut, trafikkeriet);
            Storyboard.SetTargetProperty(fadeOut, new PropertyPath(Image.OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(fadeIn);
            sb.Children.Add(fadeOut);
            sb.Begin();
        }
    }
}
