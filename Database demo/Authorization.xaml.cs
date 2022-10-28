using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public partial class Authorization : Page
    {
        public string Access;
       
        public Authorization()
        {
            InitializeComponent();
           
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(Username_Box.Text))
            {
                errors.AppendLine("Укажите логин");
            }

            if (string.IsNullOrWhiteSpace(Password_Box.Text))
            {
                errors.AppendLine("Укажите пароль");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка входа.");
                return;
            }

            var login = Username_Box.Text;
            var password = Password_Box.Text;
            string querystring = null;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string admin = "Admin";
            string manager = "Manager";

            querystring = $"SELECT Login, Password, Access FROM Users where Login ='{login}' and Password = '{password}'";

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = dbs.mssql.app.biik.ru; Initial Catalog=Hotel_DataBase; Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand(querystring, sqlConnection);

            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                // MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Access = table.Rows[0][2].ToString();
                if (Access == admin)
                {
                    Manager.MainFrame.Navigate(new hotelPage());
                    sqlConnection.Close();
                }
                else if (Access == manager)
                {
                    Manager.MainFrame.Navigate(new Add_Edit_Tour_Page());
                    sqlConnection.Close();
                }
            }
            else
                MessageBox.Show("Логин или пароль неверный. Если Вы забыли пароль - обратитесь к администратору", "Аккаунт не обнаружен!", MessageBoxButton.OK);

        }
    }
}
