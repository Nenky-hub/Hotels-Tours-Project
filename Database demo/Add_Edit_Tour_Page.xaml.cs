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
    /// Логика взаимодействия для Add_Edit_Tour_Page.xaml
    /// </summary>
    public partial class Add_Edit_Tour_Page : Page
    {
        public Add_Edit_Tour_Page()
        {
            InitializeComponent();
            DGidTours.ItemsSource = Hotel_DataBaseEntities2.GetContext().Tours.ToList();
        }

        private void ButtonEditTours_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditTours((sender as Button).DataContext as Tour));
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditTours(null));
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var toursForRemoving = DGidTours.SelectedItems.Cast<Tour>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {toursForRemoving.Count()} элементов", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Hotel_DataBaseEntities2.GetContext().Tours.RemoveRange(toursForRemoving);
                    Hotel_DataBaseEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");

                    DGidTours.ItemsSource = Hotel_DataBaseEntities2.GetContext().Tours.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                Hotel_DataBaseEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGidTours.ItemsSource = Hotel_DataBaseEntities2.GetContext().Tours.ToList();
            }
        }

        private void DGidTours_ColumnReordered(object sender, DataGridColumnEventArgs e)
        {

        } 
    }
}
