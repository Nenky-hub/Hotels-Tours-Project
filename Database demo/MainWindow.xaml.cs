using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new loginPage());
            Manager.MainFrame = MainFrame;

            Hotels.Visibility = Visibility.Hidden;
            //ImportTours();
        }

        //private void ImportTours()
        //{
        //    var fileData = File.ReadAllLines(@"D:\Downloads\Туры.txt");
        //    var images = Directory.GetFiles(@"D:\Downloads\import до\Туры фото");

        //    foreach (var line in fileData)
        //    {
        //        var data = line.Split('\t');
        //        var tempTour = new Tour
        //        {
        //            Name = data[0].Replace("\"", ""),
        //            ticketsCount = int.Parse(data[2]),
        //            Price = decimal.Parse(data[3]),
        //            IsActual = (data[4] == "0") ? false : true
        //        };

        //        foreach (var tourType in data[5].Replace("\"", "").Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            var currentType = Hotel_DataBaseEntities2.GetContext().Types.ToList().FirstOrDefault(p => p.Name == tourType);
        //            if (currentType != null)
        //                tempTour.Types.Add(currentType);
                  
        //        }

        //        try
        //        {
        //            tempTour.ImagePreview = File.ReadAllBytes(images.FirstOrDefault(p => p.Contains(tempTour.Name)));

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.Message);
        //        }
        //        Hotel_DataBaseEntities2.GetContext().Tours.Add(tempTour);
        //        Hotel_DataBaseEntities2.GetContext().SaveChanges();
        //    }

        //}
        private void Hotels_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new hotelPage());
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_CR(object sender, EventArgs e)
        {
            if(MainFrame.CanGoBack)
            {
                ButtonBack.Visibility = Visibility.Visible;
            }
            else
            {
                ButtonBack.Visibility = Visibility.Hidden;
            }
            
        }

       
        
    }
}
