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
    /// Interaction logic for _2.xaml
    /// </summary>
    public partial class DeleteProjection : Window
    {
        private Window window;
        public DeleteProjection(Window window)
        {
            var name = window.DataContext;
            var movie = MoviesStorage.Instance.GetMovie(name.ToString());
            window.DataContext = movie;
            InitializeComponent();
            this.window = window;
        }

        private void OnDeleteProjectionButton_Click(object sender, RoutedEventArgs e)
        {
            var projection = Projections.SelectedValue;
            Admin admin = new Admin("admin", "admin");
            if (projection!=null)
            {
                MessageBoxResult answer = MessageBox.Show("Are you sure you want to delete this projection?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (answer == MessageBoxResult.Yes)
                {
                    admin.DeleteProjection((window.DataContext as Movie).MovieName, (projection as Projection).ProjectionHour);
                    MoviesStorage.Instance.SetInformation();

                    window.DataContext = (window.DataContext as Movie).MovieName;
                    DeleteProjection panel = new DeleteProjection(window);
                    window.Content = panel.Content;
                }
            }
            else
            {
                MessageBox.Show("Choose Projection!");
            }
        }

        private void OnBackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel panel = new AdminPanel(window);
            window.DataContext = panel.DataContext;
            window.Content = panel.Content;
        }
    }
}
