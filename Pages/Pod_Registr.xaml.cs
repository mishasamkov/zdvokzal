using System;
using System.Collections.Generic;
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

namespace zdvokzal.Pages
{
    /// <summary>
    /// Логика взаимодействия для Pod_Registr.xaml
    /// </summary>
    public partial class Pod_Registr : Page
    {
        public Pod_Registr()
        {
            InitializeComponent();
        }
        private async Task AuthenticateAsync(string login, string password, string ip, string database)
        {
            SqlConnection sqlConnection = new SqlConnection($"Server={ip};Database={database};User ID={login};Password={password};");
            await sqlConnection.OpenAsync();
            sqlConnection.Close();
        }
        private async void Click_Vhod(object sender, RoutedEventArgs e)
        {

        }
    }
}
