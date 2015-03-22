using Kino.Classes;
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
using System.Windows.Shapes;

namespace Kino
{
    /// <summary>
    /// Interaction logic for Window1Enter.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Window window;

        public Login()
        {
            InitializeComponent();
            this.window = null;
        }

        public Login(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void OnLogInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LogInName.Text == "admin" && LogInPassword.Password == "admin")
            {
                AdminPanel main;

                if (window != null)
                {
                    main = new AdminPanel(window);
                    window.Content = main.Content;
                    window.DataContext = main.DataContext;
                }
                else
                {
                    main = new AdminPanel(this);
                    this.Content = main.Content;
                    this.DataContext = main.DataContext;
                }
            }

            else if (LogInName.Text == "lelka" && LogInPassword.Password == "lelka")
            {
                OperatorPanel main;

                if (window != null)
                {
                    main = new OperatorPanel(window);
                    window.Content = main.Content;
                    window.DataContext = main.DataContext;
                }
                else
                {
                    main = new OperatorPanel(this);
                    this.Content = main.Content;
                    this.DataContext = main.DataContext;
                }
            }
            else
            {
                MessageBox.Show("Wron username and password!");
            }
        }

        private void LogIn_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text == "Enter username")
            {
                tb.Text = string.Empty;
            }
        }

        private void LogIn_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (sender as TextBox);
            if (tb.Text == string.Empty)
            {
                tb.Text = "Enter username";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
