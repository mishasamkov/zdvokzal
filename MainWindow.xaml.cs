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
using zdvokzal;
using zdvokzal;
using zdvokzal.Pages;
using zdvokzal.Properties;
using System.IO;
using ClassConnection;

namespace zdvokzal
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow init;
        public static Connection connect;
        public static Main main;
        public static First first;
        public static Pod_Registr pod;
        public static Registr registr;

        public MainWindow()
        {
            InitializeComponent();
            init = this;
            connect = new Connection();
            main = new Main();
            first = new First();
            pod = new Pod_Registr();
            registr = new Registr();
            OpenPageFirst();
        }
        public void OpenPageRegistr()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                frame.Navigate(registr);
                DoubleAnimation opgrisAnimation = new DoubleAnimation();
                opgrisAnimation.From = 0;
                opgrisAnimation.To = 1;
                opgrisAnimation.Duration = TimeSpan.FromSeconds(1.2);
                frame.BeginAnimation(Frame.OpacityProperty, opgrisAnimation);
            };
            frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }
        public void OpenPageFirst()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                frame.Navigate(first);
                DoubleAnimation opgrisAnimation = new DoubleAnimation();
                opgrisAnimation.From = 0;
                opgrisAnimation.To = 1;
                opgrisAnimation.Duration = TimeSpan.FromSeconds(1.2);
                frame.BeginAnimation(Frame.OpacityProperty, opgrisAnimation);
            };
            frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }
        public void OpenPageMain()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                frame.Navigate(main);

                DoubleAnimation opgtisdAnimation = new DoubleAnimation();
                opgtisdAnimation.From = 0;
                opgtisdAnimation.To = 1;
                opgtisdAnimation.Duration = TimeSpan.FromSeconds(1.2);

                frame.BeginAnimation(Frame.OpacityProperty, opgtisdAnimation);
            };

            frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }
        public void OpenPagePod()
        {
            DoubleAnimation opgridAnimation = new DoubleAnimation();
            opgridAnimation.From = 1;
            opgridAnimation.To = 0;
            opgridAnimation.Duration = TimeSpan.FromSeconds(0.6);
            opgridAnimation.Completed += delegate
            {
                frame.Navigate(pod);
                DoubleAnimation opgrisAnimation = new DoubleAnimation();
                opgrisAnimation.From = 0;
                opgrisAnimation.To = 1;
                opgrisAnimation.Duration = TimeSpan.FromSeconds(1.2);

                frame.BeginAnimation(Frame.OpacityProperty, opgrisAnimation);
            };
            frame.BeginAnimation(Frame.OpacityProperty, opgridAnimation);
        }
    }
}
