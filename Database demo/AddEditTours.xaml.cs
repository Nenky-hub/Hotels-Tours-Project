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
    /// Логика взаимодействия для AddEditTours.xaml
    /// </summary>
    public partial class AddEditTours : Page
    {
        private Tour _currentTour = new Tour();
        public AddEditTours(Tour selectedTour)
        {
            InitializeComponent();

            if (selectedTour != null)
            {
                _currentTour = selectedTour;
            }


            DataContext = _currentTour;
            ComboBoxIsActual.SelectedIndex = 0;
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentTour.Name))
            {
                errors.AppendLine("Укажите название тура");
            }
            if (_currentTour.ticketsCount < 0)
            {
                errors.AppendLine("Количество билетов не может быть отрицательным");
            }
            if (_currentTour.Price == null)
            {
                errors.AppendLine("Укажите цену");
            }
            if (_currentTour.Price <0)
            {
                errors.AppendLine("Цена не может быть отрицательной");
            }
            //if (_currentTour. == null)
            //{
            //    errors.AppendLine("Выберите актуальность");
            //}
            if(ComboBoxIsActual.SelectedIndex == 0)
            {
                _currentTour.IsActual = false;
            }
            if (ComboBoxIsActual.SelectedIndex == 1)
            {
                _currentTour.IsActual = true;
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if( _currentTour.Id == 0)
            {
                Hotel_DataBaseEntities2.GetContext().Tours.Add(_currentTour);
            }

            try
            {
                Hotel_DataBaseEntities2.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ComboBoxIsActual_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
