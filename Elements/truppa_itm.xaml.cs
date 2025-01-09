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
    /// Логика взаимодействия для truppa_itm.xaml
    /// </summary>
    public partial class truppa_itm : UserControl
    {
        ClassConnection.Connection connection;
        ClassModule.Truppa truppa;
        ClassModule.Predstavleniya predstavleniya;
        ClassModule.Rabotniki rabotniki;

        public truppa_itm(Truppa _truppa)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (First.RoleUser == false)
            {
                buttons.Visibility = Visibility.Hidden;
            }
            truppa = _truppa;
            connection.LoadData(Connection.tabels.predstavleniya);
            var pred = Connection.predstavleniya.Find(x => x.kod_predstavleniya == _truppa.predstavlenie);
            connection.LoadData(Connection.tabels.rabotniki);
            var rab = Connection.rabotniki.Find(x => x.kod_rabotnika == _truppa.akter_cirka);
            nazvanie.Content = "Представление: " + pred.nazvanie;
            akter.Content = "Актер: " + rab.imya + " " + rab.familiya + " " + rab.otchestvo;
            rol.Content = "Название роли: " + _truppa.nazvanie_roli;
        }

        private void Click_PItm_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                Main.connection.LoadData(Connection.tabels.truppa);
                string query = "Delete truppa Where [kod_truppy] = " + truppa.kod_truppy.ToString() + "";
                var query_apply = Main.connection.Query(query);
                if (query_apply != null)
                {
                    Main.connection.LoadData(Connection.tabels.truppa);
                    Main.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.truppa);
                }
                else MessageBox.Show("Запрос на удаление не был обработан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Click_PItm_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.Truppa_win(truppa));
        }
    }
}
