using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Database_demo
{
    /// <summary>
    /// Логика взаимодействия для hotelPage.xaml
    /// </summary>
    public partial class hotelPage : Page
    {
        public hotelPage()
        {
            InitializeComponent();
            //DGidHotels.ItemsSource = Hotel_DataBaseEntities2.GetContext().Hotels.ToList();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {

            Manager.MainFrame.Navigate(new AddEditePage((sender as Button).DataContext as  Hotel));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditePage(null));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGidHotels.SelectedItems.Cast<Hotel>().ToList();

            if(MessageBox.Show($"Вы точно хотите удалить следующие {hotelsForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question)== MessageBoxResult.Yes)
            {
                try
                {
                    Hotel_DataBaseEntities2.GetContext().Hotels.RemoveRange(hotelsForRemoving);
                    Hotel_DataBaseEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGidHotels.ItemsSource = Hotel_DataBaseEntities2.GetContext().Hotels.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible)
            {
                Hotel_DataBaseEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGidHotels.ItemsSource = Hotel_DataBaseEntities2.GetContext().Hotels.ToList();
            }
        }

        private void ToursPageOpen_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Add_Edit_Tour_Page());
        }
    }
}
