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
using System.Windows.Media.Animation;
using ClassConnection;
using zdvokzal.Pages;

namespace zdvokzal.Elements
{
    /// <summary>
    /// Логика взаимодействия для Add_itm.xaml
    /// </summary>
    public partial class Add_itm : UserControl
    {
        public static Add_itm itm;
        Page page_str;
        ClassConnection.Connection connection;
        public Add_itm(Page _page_str)
        {
            InitializeComponent();
            connection = new ClassConnection.Connection();
            if (First.RoleUser == false)
            {
                border.Visibility = Visibility.Hidden;
            }
            itm = this;
            page_str = _page_str;
            DoubleAnimation opgridAnimation = new DoubleAnimation(); opgridAnimation.From = 0;
            opgridAnimation.To = 1;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.4);
            border.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
        }
        private void Click_add(object sender, RoutedEventArgs e)
        {
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, page_str);
        }
    }
}
