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
    public partial class AddProjection : Window
    {
        private Window window;
        public AddProjection(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void OnAddProjectionButton_Click(object sender, RoutedEventArgs e)
        {
            string time = Time.Text;
            DateTime a;
            if (!DateTime.TryParse(time, out a))
            {
                MessageBox.Show("Wrong time format!");
                return;
            }

            string hall = Hall.Text;
            Halls myhall;
            switch (hall)
            {
                case "1":
                    {
                        myhall = Halls.Hall1;
                        break;
                    }
                case "2":
                    {
                        myhall = Halls.Hall2;
                        break;
                    }
                case "3":
                    {
                        myhall = Halls.Hall3;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Incorrect hall!");
                        return;
                    }
            }
            try
            {
                Admin admin = new Admin("admin", "admin");
                admin.AddProjectionToMovie(window.DataContext.ToString(), new Projection(myhall, time));
                AdminPanel panel = new AdminPanel(window);
                window.DataContext = panel.DataContext;
                window.Content = panel.Content;
            }
            catch (InvalidMovieException)
            {
                MessageBox.Show("Invalid movie projection!");
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
