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
    /// Логика взаимодействия для ToursPage.xaml
    /// </summary>
    public partial class ToursPage : Page
    {
        public ToursPage()
        {
            InitializeComponent();
            var allTypes = Hotel_DataBaseEntities2.GetContext().Types.ToList();
            allTypes.Insert(0, new Type
            {
                Name = "Все типы"
            });
            ComboboxType.ItemsSource = allTypes;
            CheckActual.IsChecked = true;
            ComboboxType.SelectedIndex = 0;

            UpdateTours();
        }

        private void UpdateTours()
        {
            var currentTours = Hotel_DataBaseEntities2.GetContext().Tours.ToList();


            if (ComboboxType.SelectedIndex > 0)
            {
                currentTours = currentTours.Where(p => p.Types.Contains(ComboboxType.SelectedItem as Type)).ToList();
            }

            currentTours = currentTours.Where(p => p.Name.ToLower().Contains(TBoxSerch.Text.ToLower())).ToList();

            if (CheckActual.IsChecked.Value)
            {
                currentTours = currentTours.Where(p => (bool)p.IsActual).ToList();
            }

            LViewTours.ItemsSource = currentTours.OrderBy(p => p.ticketsCount).ToList();
        }

        private void CheckActual_Checked(object sender, RoutedEventArgs e)
        {
            UpdateTours();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateTours();
        }

        private void ComboBoxType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTours();
        }
    }
}
