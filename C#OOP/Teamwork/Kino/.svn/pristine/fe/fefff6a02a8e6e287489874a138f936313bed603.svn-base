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
    /// Interaction logic for _3.xaml
    /// </summary>
    public partial class ConfirmOrder : Window
    {
        private Window window;
        private int originalPrice;
        public ConfirmOrder(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Seats_Loaded(object sender, RoutedEventArgs e)
        {
            List<int> seats = Seats.DataContext as List<int>;
            StringBuilder buildSeats = new StringBuilder();
            for (int i = 0; i < seats.Count - 1; i++)
            {
                buildSeats.Append(seats[i] + ",");
            }
            buildSeats.Append(seats[seats.Count - 1]);

            Seats.Text = buildSeats.ToString();
        }

        private void OnBackButton_Click(object sender, RoutedEventArgs e)
        {
            OperatorPanel operatorPanel = new OperatorPanel(window);
            window.DataContext = operatorPanel.DataContext;
            window.Content = operatorPanel.Content;
        }

        private void OnFinishButton_Click(object sender, RoutedEventArgs e)
        {
            Employee lelka = new Employee("lelka", "lelka");
            string[] seatsString = Seats.Text.Split(',');
            List<int> seats = new List<int>();
            for (int i = 0; i < seatsString.Length; i++)
            {
                seats.Add(int.Parse(seatsString[i]));
            }

            lelka.SavePlaces(movieName.Text, projectionHour.Text, seats);
          
            int id;
            if (int.TryParse(ID.Text, out id))
            {
                LoyalCustomer customer = CustomersStorage.Instance.GetCustomerByID(id);
                if (customer != null)
                {
                    customer.LoyaltyPoints += seats.Count;
                    CustomersStorage.Instance.SetInformation();
                }
            }

            //Ticket Add
            Accountant.Instance.AddTicket(seats.Count, projectionHour.Text, DateTime.Now.DayOfWeek.ToString(), double.Parse(TotalPrice.Text));

            //Statistics calculation
            Accountant.Instance.CalculateTotalStatistic(int.Parse(TotalPrice.Text));

            if (ID.Text!=null)
            {
                Accountant.Instance.CalculateLoyalStatistic((ulong)seats.Count);                
            }

            Accountant.Instance.CalculateDiscountedStatistic(int.Parse(DiscountedSeats.Text));
            

            OperatorPanel operatorPanel = new OperatorPanel(window);
            window.DataContext = operatorPanel.DataContext;
            window.Content = operatorPanel.Content;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id;
            if (int.TryParse((sender as TextBox).Text, out id))
            {
                LoyalCustomer customer=CustomersStorage.Instance.GetCustomerByID(id);
                if (customer!=null)
                {
                    TotalPrice.Text = (originalPrice - originalPrice * customer.GetLoyaltyPercentDiscount() / 100).ToString();
                }
                else
                {
                    TotalPrice.Text = originalPrice.ToString();
                }
            }
            else
            {
                TotalPrice.Text = originalPrice.ToString();
            }
        }

        private void PriceTextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text = (int.Parse(NormalSeats.Text) * int.Parse(PriceOfTicket.Text) + int.Parse(DiscountedSeats.Text) * (int.Parse(PriceOfTicket.Text) - 2)).ToString();
            this.originalPrice = int.Parse(TotalPrice.Text);
        }
    }
}
