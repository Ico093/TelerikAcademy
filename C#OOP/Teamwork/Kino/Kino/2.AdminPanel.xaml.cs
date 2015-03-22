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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        private Admin admin;
        private Window window;
        public AdminPanel(Window window)
        {
            InitializeComponent();
            MoviesStorage.Instance.GetInformation();
            DataContext = MoviesStorage.Movies;
            this.admin = new Admin("admin", "admin");
            this.window = window;
        }

        private void OnAddMovieButton_Click(object sender, RoutedEventArgs e)
        {
            AddMovie window1 = new AddMovie(window);
            window.Content = window1.Content;
        }

        private void RemoveMovie_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure you want to delete this movie?", "Delete Confirmation", MessageBoxButton.YesNo);
            if(answer==MessageBoxResult.Yes)
            {
                var listItem = (sender as Button).DataContext;
                admin.DeleteMovie(listItem.ToString());

                AdminPanel main = new AdminPanel(window);
                window.DataContext = main.DataContext;
            }
        }

        private void OnBackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(window);
            window.Content = login.Content;
        }

        private void OnAddProjectionButton_Click(object sender, RoutedEventArgs e)
        {
            AddProjection projection = new AddProjection(window);
            window.Content = projection.Content;
            window.DataContext = (sender as Button).DataContext;
        }

        private void OnDeleteProjectionButton_Click(object sender, RoutedEventArgs e)
        {
            window.DataContext = (sender as Button).DataContext;
            DeleteProjection panel = new DeleteProjection(window);
            window.Content = panel.Content;
        }
        private void ShowStatistics()
        {
            MessageBox.Show("Loyal Statistic:" + Environment.NewLine + 
                            Accountant.Instance.LoyalStatistic.ToString() + Environment.NewLine +
                            "Discounted Statistic:" + Environment.NewLine +
                            Accountant.Instance.DiscountedStatistic + Environment.NewLine +
                            "Total Statistic:" + Environment.NewLine + 
                            Accountant.Instance.TotalStatistic.ToString());
        }

        private void ShowStatistics_Click(object sender, RoutedEventArgs e)
        {
            Accountant.Instance.GetInformation();
            ShowStatistics();
        }

    }
}
