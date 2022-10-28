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

namespace Database_demo
{
    /// <summary>
    /// Логика взаимодействия для loginPage.xaml
    /// </summary>
    public partial class loginPage : Page
    {
        public loginPage()
        {
            InitializeComponent();
        }

        private void Authorization_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new Authorization());
        }

        private void Found_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new ToursPage());
        }

        private void FoundHotel_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Manager.MainFrame.Navigate(new Hotels_Page_View());
        }
    }
}
