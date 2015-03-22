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
using Kino.Classes;

namespace Kino
{
    /// <summary>
    /// Interaction logic for Places.xaml
    /// </summary>
    public partial class Places : Window
    {
        private Window window;
        private Movie myMovie;
        private List<int> markedSeats;

        public Places(Window window)
        {
            InitializeComponent();
            this.window = window;
            this.markedSeats = new List<int>();
        }

        private void OnChooseButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (sender as Button);
            if (btn.Background == Brushes.LawnGreen)
            {
                btn.Background = Brushes.Gold;
                btn.BorderBrush = Brushes.Red;
                markedSeats.Add(int.Parse(btn.Content.ToString()));
            }
            else if (btn.Background == Brushes.Gold)
            {
                btn.Background = Brushes.LawnGreen;
                btn.BorderBrush = Brushes.Gold;
                markedSeats.Remove(int.Parse(btn.Content.ToString()));
            }
        }
        private void OnBackButton_Click(object sender, RoutedEventArgs e)
        {
            OperatorPanel operatorPanel = new OperatorPanel(window);
            window.DataContext = operatorPanel.DataContext;
            window.Content = operatorPanel.Content;
        }

        private void OnContinueButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmOrder order = new ConfirmOrder(window);
            if (DiscoutedNumber.Text == string.Empty)
            {
                DiscoutedNumber.Text = "0";
            }
            if ((markedSeats.Count != 0) && (markedSeats.Count >= int.Parse(DiscoutedNumber.Text)))
            {
                window.DataContext = new
                {
                    MovieName = myMovie.MovieName,
                    hourOfProjection = Time.Content,
                    NumberOfTickets = markedSeats.Count,
                    Hall = Hall.Content,
                    Seats = markedSeats,
                    Normal = markedSeats.Count - int.Parse(DiscoutedNumber.Text),
                    Discounted = DiscoutedNumber.Text,
                    Price = myMovie.Price
                };
                window.Content = order.Content;
            }
            else if (markedSeats.Count < int.Parse(DiscoutedNumber.Text))
            {
                MessageBox.Show("The discounted places can not be more than the marked places.");
            }
            else
            {
                OnBackButton_Click(sender, e);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WrapPanel wrap = new WrapPanel();
            wrap.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            int number = 1;

            //взимане на филма за тази прожекция

            myMovie = MoviesStorage.Movies.Where(x => x.Projections.Where(y => y.ProjectionHour == Time.Content.ToString() && y.Hall == (Halls)Enum.Parse(typeof(Halls),
                                                               Hall.Content.ToString())).Select(y => y).FirstOrDefault() != null).Select(x => x).FirstOrDefault();
            List<int> boughtSeats = myMovie.Projections.Where(x => x.ProjectionHour == Time.Content.ToString()).Select(x => x).FirstOrDefault().ReservedPlaces;

            for (int row = 0; row < 10; row++)
            {
                for (int col = 0; col < 5; col++, number++)
                {
                    Button seat = new Button();
                    seat.Style = (Style)this.FindResource("ButtonSeats");
                    seat.Content = number;
                    seat.Width = 40;
                    seat.Height = 40;
                    seat.Margin = new Thickness(17);
                    seat.FontSize = 20;
                    seat.Click += OnChooseButton_Click;
                    if (boughtSeats.Contains(number))
                    {
                        seat.Background = Brushes.Red;
                        //живе един стил ей тука добави моля тя за mousover
                    }
                    else
                    {
                        seat.Background = Brushes.LawnGreen;
                    }
                    //живе сложи малко стилове тук!

                    wrap.Children.Add(seat);
                }
            }

            Seats.Children.Add(wrap);
        }
    }
}
