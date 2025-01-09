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
using ClassConnection;
using ClassModule;
using zdvokzal.Pages;

namespace zdvokzal.Elements
{
    /// <summary>
    /// Логика взаимодействия для raspisanie_itm.xaml
    /// </summary>
    public partial class raspisanie_itm : UserControl
    {
        Connection connection;
        ClassModule.Raspisanie_gastroley raspisanie_gastroley;
        public raspisanie_itm(Raspisanie_gastroley _raspisanie)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (First.RoleUser == false)
            {
                buttons.Visibility = Visibility.Hidden;
            }
            raspisanie_gastroley = _raspisanie;
            connection.LoadData(Connection.tabels.predstavleniya);
            var pred = Connection.predstavleniya.Find(x => x.kod_predstavleniya == _raspisanie.predstavlenie);
            predstavlenie.Content = "Представление: " + pred.nazvanie;
            data_nach.Content = "Дата начала: " + _raspisanie.data_nach.ToString("dd.MM.yyyy");
            data_okonch.Content = "Дата окончания: " + _raspisanie.data_okonch.ToString("dd.MM.yyyy");
            mesto.Content = "Место: " + _raspisanie.mesto;
        }

        private void Click_PItm_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.raspisanie_win(raspisanie_gastroley));
        }

        private void Click_PItm_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connection.LoadData(Connection.tabels.raspisanie_gastroley);
                string query = "Delete raspisanie_gastroley Where [kod_raspisaniya] = " + raspisanie_gastroley.kod_raspisaniya.ToString() + "";
                var query_apply = Main.connection.Query(query);
                if (query_apply != null)
                {
                    Main.connection.LoadData(Connection.tabels.raspisanie_gastroley);
                    Main.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.raspisanie_gastroley);
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
