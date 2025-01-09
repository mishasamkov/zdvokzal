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
    /// Логика взаимодействия для programma_itm.xaml
    /// </summary>
    public partial class programma_itm : UserControl
    {
        ClassModule.Programma_cirka programma;
        ClassConnection.Connection connection;
        public programma_itm(Programma_cirka _programma)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (First.RoleUser == false)
            {
                buttons.Visibility = Visibility.Hidden;
            }
            programma = _programma;
            connection.LoadData(Connection.tabels.predstavleniya);
            var pred = Connection.predstavleniya.Find(x => x.kod_predstavleniya == _programma.predstavlenie);
            predstavlenie.Content = "Представление: " + pred.nazvanie;
            data_prem.Content = "Дата премьеры: " + _programma.data_prem.ToString("dd.MM.yyyy");
            period.Content = "Период: " + _programma.period + " дней";
            dni_vremya.Content = "Дни и время: " + _programma.dni_vremya;
            cena.Content = "Цена: " + _programma.cena + " руб";
        }
        private void Click_PItm_redact(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Pages.PagesUser.programma_win(programma));
        }

        private void Click_PItm_remove(object sender, RoutedEventArgs e)
        {
            try
            {
                connection.LoadData(Connection.tabels.programma_cirka);
                string query = $"Delete From programma_cirka Where kod_programmy = " + programma.kod_programmy.ToString() + "";
                var query_apply = connection.Query(query);
                if (query_apply != null)
                {
                    connection.LoadData(Connection.tabels.programma_cirka);
                    MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main, null, null, Main.page_main.programma_cirka);
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
