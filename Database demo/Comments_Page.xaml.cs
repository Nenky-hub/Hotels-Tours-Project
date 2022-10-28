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
    /// Логика взаимодействия для Comments_Page.xaml
    /// </summary>
    public partial class Comments_Page : Page
    {
        private HotelComment _currentHotelComment = new HotelComment();
        public Comments_Page(Hotel selectedHotel)
        {
            InitializeComponent();
           
            DataContext = _currentHotelComment;

            ComboHotels.ItemsSource = Hotel_DataBaseEntities2.GetContext().Hotels.ToList();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (_currentHotelComment.Hotel == null)
            {
                errors.AppendLine("Укажите название отеля");
            }
            
            if (string.IsNullOrWhiteSpace(_currentHotelComment.Text))
            {
                errors.AppendLine("Напишите отзыв");
            }
            if (string.IsNullOrWhiteSpace(_currentHotelComment.Autor))
            {
                errors.AppendLine("Укажите автора");
            }

            _currentHotelComment.CreationDate = DateTime.Now;
           
           
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotelComment.Id == 0)
            {
                Hotel_DataBaseEntities2.GetContext().HotelComments.Add(_currentHotelComment);
            }

            try
            {
                Hotel_DataBaseEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
