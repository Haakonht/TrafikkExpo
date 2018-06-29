using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TrafikkExpo.Model;
using static TrafikkExpo.Model.Storage;

namespace TrafikkExpo.View.Prototypes
{
    /// <summary>
    /// Interaction logic for CourseRow.xaml
    /// </summary>
    public partial class CourseRow : UserControl
    {
        private Course c;

        public CourseRow(Course course, Boolean deletable)
        {
            InitializeComponent();
            this.c = course;
            Kursnavn.Text = course.courseName;
            fraDato.Text = string.Format("{0:dd MM yyyy H:mm}", course.from);
            tilDato.Text = string.Format("{0:dd MM yyyy H:mm}", course.to);
            Pris.Text = course.price;
            if(deletable)
            {
                Kursnavn.FontSize = 12;
                fraDato.FontSize = 12;
                tilDato.FontSize = 12;
                Pris.FontSize = 12;
                ColumnDefinition c1 = new ColumnDefinition();
                c1.Width = new GridLength(0.2, GridUnitType.Star);
                Grid.ColumnDefinitions.Add(c1);
                DeleteBtn.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storage.DeleteCourse(c);
        }
    }
}
