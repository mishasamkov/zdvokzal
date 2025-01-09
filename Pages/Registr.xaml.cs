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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zdvokzal.Pages
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Page
    {
        public static Pod_Registr pod;
        public Registr()
        {
            InitializeComponent();
            pod = new Pod_Registr();
        }
        public void OpenPagePod()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                frame_first.Navigate(pod);
                DoubleAnimation opgrisAnimation = new DoubleAnimation();
                opgrisAnimation.From = 0;
                opgrisAnimation.To = 1;
                opgrisAnimation.Duration = TimeSpan.FromSeconds(1.2);

                frame_first.BeginAnimation(Frame.OpacityProperty, opgrisAnimation);
            };
            frame_first.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }
        private void Click_Registr(object sender, RoutedEventArgs e)
        {

            if (password.Password != password_povt.Password)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }
            if (string.IsNullOrEmpty(login.Text))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            MessageBox.Show("пользователя должен подтвердить администратор");
            MainWindow.init.OpenPageFirst();
            login.Text = "";
        }
        private void Click_Vhod(object sender, MouseButtonEventArgs e)
        {
            MainWindow.init.OpenPageFirst();
        }
    }
}
