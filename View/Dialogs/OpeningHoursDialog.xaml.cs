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

namespace TrafikkExpo.View.Dialogs
{
    /// <summary>
    /// Interaction logic for OpeningHoursDialog.xaml
    /// </summary>
    public partial class OpeningHoursDialog : Window
    {
        public OpeningHoursDialog()
        {
            InitializeComponent();
            Mandag.Text = Storage.Monday;
            Tirsdag.Text = Storage.Tuesday;
            Onsdag.Text = Storage.Wednesday;
            Torsdag.Text = Storage.Thursday;
            Fredag.Text = Storage.Friday;
        }

        public void confirmBtn_click(object sender, RoutedEventArgs evt)
        {
            Storage.Monday = Mandag.Text;
            Storage.Tuesday = Tirsdag.Text;
            Storage.Wednesday = Onsdag.Text;
            Storage.Thursday = Torsdag.Text;
            Storage.Friday = Fredag.Text;
            Close();
        }

        public void cancelBtn_click(object sender, RoutedEventArgs evt)
        {
            Close();
        }
    }
}
