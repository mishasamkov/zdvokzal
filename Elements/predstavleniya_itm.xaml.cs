using ClassConnection;
using ClassModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для predstavleniya_itm.xaml
    /// </summary>
    public partial class predstavleniya_itm : UserControl
    {
        ClassModule.Predstavleniya predstavleniya;
        ClassConnection.Connection connection;
        public predstavleniya_itm(Predstavleniya _predstavleniya)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (First.RoleUser == false)
            {
                buttons.Visibility = Visibility.Hidden;
            }
            predstavleniya = _predstavleniya;
            nazvanie.Content = "Название: " + _predstavleniya.nazvanie;
            connection.LoadData(ClassConnection.Connection.tabels.rabotniki);
            var select_rezh = Connection.rabotniki.Find(x => x.kod_rabotnika == _predstavleniya.rezh_post);
            rezh.Content = "Режиссёр: " + select_rezh.familiya + " " + select_rezh.imya + " " + select_rezh.otchestvo;
            connection.LoadData(ClassConnection.Connection.tabels.rabotniki);
            var select_dir = Connection.rabotniki.Find(x => x.kod_rabotnika == _predstavleniya.dir_post);
            dir.Content = "Дирижер: " + select_dir.familiya + " " + select_rezh.imya + " " + select_rezh.otchestvo;
            connection.LoadData(ClassConnection.Connection.tabels.rabotniki);
            var select_avtor = Connection.rabotniki.Find(x => x.kod_rabotnika == _predstavleniya.avtor);
            avtor.Content = "Автор: " + select_avtor.familiya + " " + select_rezh.imya + " " + select_rezh.otchestvo;
            zhanr.Content = "Жанр: " + _predstavleniya.zhanr;
            tip.Content = "Тип: " + _predstavleniya.tip;
        }
        private void Click_PItm_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.predstavleniya_win(predstavleniya));
        }

        private void Click_PItm_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.LoadData(Connection.tabels.predstavleniya);
                string query = $"Delete From predstavleniya Where kod_predstavleniya = " + predstavleniya.kod_predstavleniya.ToString() + "";
                var query_apply = connection.Query(query);
                if (query_apply != null)
                {
                    connection.LoadData(Connection.tabels.predstavleniya);
                    MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.predstavleniya);
                }
                else MessageBox.Show("Запрос на удаление не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
