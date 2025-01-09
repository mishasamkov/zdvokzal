using ClassConnection;
using ClassModule;
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
using zdvokzal.Pages;

namespace zdvokzal.Elements
{
    /// <summary>
    /// Логика взаимодействия для rab_itm.xaml
    /// </summary>
    public partial class rab_itm : UserControl
    {
        ClassConnection.Connection connection;
        ClassModule.Rabotniki rabotniki;
        public rab_itm(Rabotniki _rabotniki)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (First.RoleUser == false)
            {
                buttons.Visibility = Visibility.Hidden;
            }
            rabotniki = _rabotniki;
            fam.Content = _rabotniki.familiya + " " + _rabotniki.imya + " " + _rabotniki.otchestvo;
            god.Content = "Год Рождения: " + _rabotniki.god_rozd.ToString("dd.MM.yyyy");
            god_post.Content = "Год поступления на работу: " + _rabotniki.god_post_na_rab.ToString("dd.MM.yyyy");
            stazh.Content = "Стаж: " + _rabotniki.stazh + " лет";
            pol.Content = "Пол: " + _rabotniki.pol;
            dolzh.Content = "Должность: " + _rabotniki.dolzhnost;
            adres.Content = "Адрес: " + _rabotniki.adres;
            gorod.Content = "Город: " + _rabotniki.gorod;
            tel.Content = "Телефон: " + _rabotniki.telefon;
        }

        private void Click_PItm_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.rabotniki_win(rabotniki));
        }

        private void Click_PItm_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connection.LoadData(Connection.tabels.rabotniki);
                string query = "Delete rabotniki Where [kod_rabotnika] = " + rabotniki.kod_rabotnika.ToString() + "";
                var query_apply = Main.connection.Query(query);
                if (query_apply != null)
                {
                    Main.connection.LoadData(Connection.tabels.rabotniki);
                    Main.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.rabotniki);
                }
                else MessageBox.Show("Запрос на удаление не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
