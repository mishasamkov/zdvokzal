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
using zdvokzal;
using System.Windows.Media.Animation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using ClassConnection;
using ClassModule;
using zdvokzal.Elements;
using zdvokzal.Pages;
using zdvokzal.Pages.PagesUser;
using System.Net;
using System.Runtime.Remoting.Contexts;

namespace zdvokzal.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public string currentPage = "predstavleniya";
        public enum page_main
        {
            predstavleniya, programma_cirka, rabotniki, raspisanie_gastroley, truppa, export, none
        };
        public static page_main page_select;
        public static Connection connection;
        public static Main main;
        public Main()
        {
            InitializeComponent();
            main = this;
            MainWindow.main = this;
            page_select = page_main.none;
            connection = new Connection();
            btn_up.Visibility = Visibility.Hidden;
            btn_down.Visibility = Visibility.Hidden;
        }
        public void CreateConnect(bool connectApply)
        {
            if (connectApply == true)
            {
                connection = new Connection();
                connection.LoadData(Connection.tabels.predstavleniya);
                connection.LoadData(Connection.tabels.programma_cirka);
                connection.LoadData(Connection.tabels.rabotniki);
                connection.LoadData(Connection.tabels.raspisanie_gastroley);
                connection.LoadData(Connection.tabels.truppa);
            }
        }
        public void Anim_move(Control control1, Control control2, Frame frame_main = null, Page pages = null, page_main page_restart = page_main.none, params Control[] buttons)
        {
            if (page_restart != page_main.none)
            {
                if (page_restart == page_main.predstavleniya)
                {
                    page_select = page_main.none;
                    Click_tickets(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.programma_cirka)
                {
                    page_select = page_main.none;
                    Click_programma(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.rabotniki)
                {
                    page_select = page_main.none;
                    Click_rabotniki(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.raspisanie_gastroley)
                {
                    page_select = page_main.none;
                    Click_raspisanie(new object(), new RoutedEventArgs());
                }
                else if (page_restart == page_main.truppa)
                {
                    page_select = page_main.none;
                    Click_truppa(new object(), new RoutedEventArgs());
                }
            }
            else
            {
                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.3);
                opgridAnimation.Completed += delegate
                {
                    if (pages != null)
                    {
                        frame_main.Navigate(pages);
                    }
                    control1.Visibility = Visibility.Hidden;
                    control2.Visibility = Visibility.Visible;
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.4);
                    control2.BeginAnimation(ScrollViewer.OpacityProperty, opgriAnimation);
                    if (buttons != null && buttons.Length > 0)
                    {
                        Anim_btn(buttons);
                    }
                };
                control1.BeginAnimation(ScrollViewer.OpacityProperty, opgridAnimation);
            }
        }
        public void Anim_btn(params Control[] buttons)
        {
            foreach (var button in buttons)
            {
                button.Visibility = Visibility.Visible;
                DoubleAnimation opacityAnimation = new DoubleAnimation();
                opacityAnimation.From = 0;
                opacityAnimation.To = 1;
                opacityAnimation.Duration = TimeSpan.FromSeconds(0.4);
                button.BeginAnimation(Control.OpacityProperty, opacityAnimation);
            }
        }
        private void Click_programma(object sender, RoutedEventArgs e)
        {
            currentPage = "programma";
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.programma_cirka)
            {
                page_select = page_main.programma_cirka;

                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(Connection.tabels.programma_cirka);
                            foreach (Programma_cirka prog_itm in Connection.programma_cirka)
                            {
                                if (page_select == page_main.programma_cirka)
                                {
                                    parent.Children.Add(new programma_itm(prog_itm));
                                    await Task.Delay(90);
                                }
                            }
                            if (page_select == page_main.programma_cirka)
                            {
                                if (First.RoleUser == true)
                                {
                                    var ff = new programma_win(new Programma_cirka());
                                    parent.Children.Add(new Add_itm(ff));
                                }
                            }
                            Anim_btn(btn_up, btn_down);
                        });
                    };
                    parent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_rabotniki(object sender, RoutedEventArgs e)
        {
            currentPage = "rabotniki";
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.rabotniki)
            {
                page_select = page_main.rabotniki;

                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(Connection.tabels.rabotniki);
                            foreach (Rabotniki rab in Connection.rabotniki)
                            {
                                if (page_select == page_main.rabotniki)
                                {
                                    parent.Children.Add(new rab_itm(rab));
                                    await Task.Delay(90);
                                }
                            }
                            if (page_select == page_main.rabotniki)
                            {
                                if (First.RoleUser == true)
                                {
                                    var ff = new rabotniki_win(new Rabotniki());
                                    parent.Children.Add(new Add_itm(ff));
                                }
                            }
                            Anim_btn(btn_up, btn_down);
                        });
                    };
                    parent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_truppa(object sender, RoutedEventArgs e)
        {
            currentPage = "truppa";
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.truppa)
            {
                page_select = page_main.truppa;

                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {

                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(Connection.tabels.truppa);
                            foreach (Truppa trup in Connection.truppa)
                            {
                                if (page_select == page_main.truppa)
                                {
                                    parent.Children.Add(new truppa_itm(trup));
                                    await Task.Delay(90);
                                }
                            }
                            if (page_select == page_main.truppa)
                            {
                                if (First.RoleUser == true)
                                {
                                    var ff = new Truppa_win(new Truppa());
                                    parent.Children.Add(new Add_itm(ff));
                                }
                            }
                            Anim_btn(btn_up, btn_down);
                        });
                    };
                    parent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_raspisanie(object sender, RoutedEventArgs e)
        {
            currentPage = "raspisanie";
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.raspisanie_gastroley)
            {
                page_select = page_main.raspisanie_gastroley;

                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {

                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(Connection.tabels.raspisanie_gastroley);
                            foreach (Raspisanie_gastroley rasp_itm in Connection.raspisanie_gastroley)
                            {
                                if (page_select == page_main.raspisanie_gastroley)
                                {
                                    parent.Children.Add(new raspisanie_itm(rasp_itm));
                                    await Task.Delay(90);
                                }
                            }
                            if (page_select == page_main.raspisanie_gastroley)
                            {
                                if (First.RoleUser == true)
                                {
                                    var ff = new raspisanie_win(new Raspisanie_gastroley());
                                    parent.Children.Add(new Add_itm(ff));
                                }
                            }
                            Anim_btn(btn_up, btn_down);
                        });
                    };
                    parent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_tickets(object sender, RoutedEventArgs e)
        {
            currentPage = "predstavleniya";
            if (frame_main.Visibility == Visibility.Visible)
            {
                MainWindow.main.Anim_move(MainWindow.main.frame_main, MainWindow.main.scroll_main);
            }
            if (page_select != page_main.predstavleniya)
            {
                page_select = page_main.predstavleniya;

                DoubleAnimation opgridAnimation = new DoubleAnimation();
                opgridAnimation.From = 1;
                opgridAnimation.To = 0;
                opgridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                opgridAnimation.Completed += delegate
                {
                    parent.Children.Clear();
                    DoubleAnimation opgriAnimation = new DoubleAnimation();
                    opgriAnimation.From = 0;
                    opgriAnimation.To = 1;
                    opgriAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    opgriAnimation.Completed += delegate
                    {
                        Dispatcher.InvokeAsync(async () =>
                        {
                            MainWindow.connect.LoadData(Connection.tabels.predstavleniya);
                            foreach (Predstavleniya pred_itm in Connection.predstavleniya)
                            {
                                if (page_select == page_main.predstavleniya)
                                {
                                    parent.Children.Add(new predstavleniya_itm(pred_itm));
                                    await Task.Delay(90);
                                }
                            }
                            if (page_select == page_main.predstavleniya)
                            {
                                var ff = new predstavleniya_win(new Predstavleniya());
                                parent.Children.Add(new Add_itm(ff));
                            }
                            Anim_btn(btn_up, btn_down);
                        });
                    };
                    parent.BeginAnimation(StackPanel.OpacityProperty, opgriAnimation);
                };
                parent.BeginAnimation(StackPanel.OpacityProperty, opgridAnimation);
            }
        }

        private void Click_back(object sender, RoutedEventArgs e)
        {
            parent.Children.Clear();
            page_select = page_main.none;
            MainWindow.init.OpenPageFirst();
        }

        private void Click_Export(object sender, MouseButtonEventArgs e)
        {
            btn_up.Visibility = Visibility.Hidden;
            btn_down.Visibility = Visibility.Hidden;
            MainWindow.main.Anim_move(MainWindow.main.scroll_main, MainWindow.main.frame_main, MainWindow.main.frame_main, new Export());
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tb_search.Text == "Поиск")
            {
                tb_search.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tb_search.Text))
            {
                tb_search.Text = "Поиск";
            }
        }

        private void Text_Changed(object sender, TextChangedEventArgs e)
        {
            string searchText = tb_search.Text.Trim();
            if (!string.IsNullOrEmpty(searchText) && searchText != "Поиск")
            {
                if (currentPage == "programma")
                {
                    var filteredData = from p in Connection.programma_cirka join pr in Connection.predstavleniya on p.predstavlenie equals pr.kod_predstavleniya where pr.nazvanie.ToLower().Contains(searchText.ToLower()) || p.cena.ToString().Contains(searchText.ToLower()) || p.data_prem.ToString("dd.MM.yyyy").Contains(searchText.ToLower()) select new { p, pr.nazvanie, p.cena, p.data_prem };
                    parent.Children.Clear();
                    foreach (var prog in filteredData)
                    {
                        parent.Children.Add(new programma_itm(prog.p));
                    }
                }
                else if (currentPage == "predstavleniya")
                {
                    var filteredData = Connection.predstavleniya.Where(x => x.nazvanie.ToLower().Contains(searchText) || x.zhanr.ToLower().Contains(searchText) || x.tip.ToLower().Contains(searchText)).ToList();
                    parent.Children.Clear();
                    foreach (var prog in filteredData)
                    {
                        parent.Children.Add(new predstavleniya_itm(prog));
                    }
                }
                else if (currentPage == "rabotniki")
                {
                    var filteredData = Connection.rabotniki.Where(x => x.familiya.ToLower().Contains(searchText) || x.imya.ToLower().Contains(searchText) || x.otchestvo.ToLower().Contains(searchText)).ToList();
                    parent.Children.Clear();
                    foreach (var prog in filteredData)
                    {
                        parent.Children.Add(new rab_itm(prog));
                    }
                }
                else if (currentPage == "raspisanie")
                {
                    var filteredData = from p in Connection.raspisanie_gastroley join pr in Connection.predstavleniya on p.predstavlenie equals pr.kod_predstavleniya where pr.nazvanie.ToLower().Contains(searchText.ToLower()) || p.mesto.ToString().Contains(searchText) || p.data_nach.ToString("dd.MM.yyyy").Contains(searchText) || p.data_okonch.ToString("dd.MM.yyyy").Contains(searchText) select new { p, pr.nazvanie, p.mesto, p.data_nach, p.data_okonch };
                    parent.Children.Clear();
                    foreach (var prog in filteredData)
                    {
                        parent.Children.Add(new raspisanie_itm(prog.p));
                    }
                }
                else if (currentPage == "truppa")
                {
                    var filteredData = from t in Connection.truppa join pr in Connection.predstavleniya on t.predstavlenie equals pr.kod_predstavleniya join r in Connection.rabotniki on t.akter_cirka equals r.kod_rabotnika where pr.nazvanie.ToLower().Contains(searchText.ToLower()) || r.familiya.ToLower().Contains(searchText.ToLower()) || r.imya.ToLower().Contains(searchText.ToLower()) || r.otchestvo.ToLower().Contains(searchText.ToLower()) || t.nazvanie_roli.ToLower().Contains(searchText.ToLower()) select new { t, pr.nazvanie, r.familiya, r.imya, r.otchestvo, t.nazvanie_roli };
                    parent.Children.Clear();
                    foreach (var prog in filteredData)
                    {
                        parent.Children.Add(new truppa_itm(prog.t));
                    }
                }
            }
        }

        private void Click_Up(object sender, RoutedEventArgs e)
        {
            if (currentPage == "programma")
            {
                var sortedData = (from prog in Connection.programma_cirka
                                  join pred in Connection.predstavleniya
                                  on prog.predstavlenie equals pred.kod_predstavleniya
                                  orderby pred.nazvanie
                                  select new { Programma = prog, PredstavlenieNazvanie = pred.nazvanie }).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new programma_itm(prog.Programma));
                }
            }
            else if (currentPage == "predstavleniya")
            {
                var sortedData = Connection.predstavleniya.OrderBy(x => x.nazvanie).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new predstavleniya_itm(prog));
                }
            }
            else if (currentPage == "rabotniki")
            {
                var sortedData = Connection.rabotniki.OrderBy(x => x.familiya).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new rab_itm(prog));
                }
            }
            else if (currentPage == "raspisanie")
            {
                var sortedData = (from rasp in Connection.raspisanie_gastroley
                                  join pred in Connection.predstavleniya
                                  on rasp.predstavlenie equals pred.kod_predstavleniya
                                  orderby pred.nazvanie
                                  select new { Raspisanie = rasp, PredstavlenieNazvanie = pred.nazvanie }).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new raspisanie_itm(prog.Raspisanie));
                }
            }
            else if (currentPage == "truppa")
            {
                var sortedData = (from truppa in Connection.truppa
                                  join pred in Connection.predstavleniya
                                  on truppa.predstavlenie equals pred.kod_predstavleniya
                                  orderby pred.nazvanie
                                  select new { Truppa = truppa, PredstavlenieNazvanie = pred.nazvanie }).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new truppa_itm(prog.Truppa));
                }
            }
        }

        private void Click_Down(object sender, RoutedEventArgs e)
        {
            if (currentPage == "programma")
            {
                var sortedData = (from prog in Connection.programma_cirka
                                  join pred in Connection.predstavleniya
                                  on prog.predstavlenie equals pred.kod_predstavleniya
                                  orderby pred.nazvanie descending
                                  select new { Programma = prog, PredstavlenieNazvanie = pred.nazvanie }).ToList();
                parent.Children.Clear();
                foreach (var item in sortedData)
                {
                    parent.Children.Add(new programma_itm(item.Programma));
                }
            }
            else if (currentPage == "predstavleniya")
            {
                var sortedData = Connection.predstavleniya.OrderByDescending(x => x.nazvanie).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new predstavleniya_itm(prog));
                }
            }
            else if (currentPage == "rabotniki")
            {
                var sortedData = Connection.rabotniki.OrderByDescending(x => x.familiya).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new rab_itm(prog));
                }
            }
            else if (currentPage == "raspisanie")
            {
                var sortedData = (from rasp in Connection.raspisanie_gastroley
                                  join pred in Connection.predstavleniya
                                  on rasp.predstavlenie equals pred.kod_predstavleniya
                                  orderby pred.nazvanie descending
                                  select new { Raspisanie = rasp, PredstavlenieNazvanie = pred.nazvanie }).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new raspisanie_itm(prog.Raspisanie));
                }
            }
            else if (currentPage == "truppa")
            {
                var sortedData = (from truppa in Connection.truppa
                                  join pred in Connection.predstavleniya
                                  on truppa.predstavlenie equals pred.kod_predstavleniya
                                  orderby pred.nazvanie descending
                                  select new { Truppa = truppa, PredstavlenieNazvanie = pred.nazvanie }).ToList();
                parent.Children.Clear();
                foreach (var prog in sortedData)
                {
                    parent.Children.Add(new truppa_itm(prog.Truppa));
                }
            }
        }
    }
}
