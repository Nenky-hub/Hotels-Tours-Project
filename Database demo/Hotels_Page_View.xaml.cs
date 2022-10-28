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
    /// Логика взаимодействия для Hotels_Page_View.xaml
    /// </summary>
    public partial class Hotels_Page_View : Page
    {
        public Hotels_Page_View()
        {
            InitializeComponent();
            DGidHotels.ItemsSource = Hotel_DataBaseEntities2.GetContext().Hotels.ToList();
        }

        private void ButtonComment_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Comments_Page(null));
        }
    }
}
