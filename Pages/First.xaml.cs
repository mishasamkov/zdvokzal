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

namespace zdvokzal.Pages
{
    /// <summary>
    /// Логика взаимодействия для First.xaml
    /// </summary>
    public partial class First : Page
    {
        public Connection connection;
        public static bool RoleUser = false;
        public First()
        {
            InitializeComponent();
            connection = new Connection();
        }

        private void Click_Vhod(object sender, RoutedEventArgs e)
        {
            if (login.Text == "")
                MessageBox.Show("Введите ваш логин!");
            if (password.Password == "")
                MessageBox.Show("Введите ваш пароль!");
            if (connection.Connect(login.Text, password.Password) == true)
            {
                if (connection.RoleUser(login.Text, password.Password) == "admin") RoleUser = true;
                else RoleUser = false;
                MainWindow.init.OpenPageMain();
            }
            else
            {
                MessageBox.Show("Данного пользователя не существует!");
                login.Text = "";
                password.Password = "";
                return;
            }
        }
    }
}
