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
using System.Windows.Shapes;
using TrafikkExpo.Model;
using TrafikkExpo.View.Prototypes;
using static TrafikkExpo.Model.Storage;

namespace TrafikkExpo.View.Dialogs
{
    /// <summary>
    /// Interaction logic for OpeningHoursDialog.xaml
    /// </summary>
    public partial class CourseManagerDialog : Window
    {
        public CourseManagerDialog()
        {
            InitializeComponent();
            SetMyCustomFormat();
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcherTimer.Start();
            FraDato.Value = DateTime.Today;
            TilDato.Value = DateTime.Today;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            refreshPanel();
        }

        private void refreshPanel()
        {
            CoursePanel.Children.Clear();
            foreach (Course c in Storage.Courses)
            {
                CoursePanel.Children.Add(new CourseRow(c, true));
            }
        }

        public void SetMyCustomFormat()
        {
            FraDato.CustomFormat = "dd MMM yyyy - HH:mm";
            TilDato.CustomFormat = "dd MMM yyyy - HH:mm";
        }

        public void confirmBtn_click(object sender, RoutedEventArgs evt)
        {
            Storage.AddCourse(Kursnavn.Text, FraDato.Value, TilDato.Value, Pris.Text);
        }

        public void cancelBtn_click(object sender, RoutedEventArgs evt)
        {
            Close();
        }
    }
}
