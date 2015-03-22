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
    /// Interaction logic for Window2MovieProgram.xaml
    /// </summary>
    public partial class OperatorPanel : Window
    {
        private Window window;
        public OperatorPanel(Window window)
        {
            InitializeComponent();
            MoviesStorage.Instance.GetInformation();
            DataContext = MoviesStorage.Movies;
            this.window = window;
        }

        private void a(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ssts");
        }

        private void aaa(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("ssts");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void OnBackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(window);
            window.Content = login.Content;
        }

        private void OnAddLoyalCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            LoyalCustomerRegistration customer = new LoyalCustomerRegistration(window);
            window.Content = customer.Content;
        }

        private void OnReserveButton_Click(object sender, RoutedEventArgs e)
        {
            Places places = new Places(window);
            var time=(sender as Button).Content;
            var hall = (sender as Button).Tag;

            window.DataContext = new { time = time, hall = hall };
            window.Content = places.Content;
        }
    }
}
