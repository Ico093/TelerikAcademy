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
using System.Threading;

namespace Kino
{
    /// <summary>
    /// Interaction logic for _2.xaml
    /// </summary>
    public partial class AddMovie : Window
    {
        private Window window;
        public AddMovie(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void OnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            string name = MovieName.Text;
            string price = Price.Text;
            double doublePrice;
            if(name!=String.Empty&&double.TryParse(price,out doublePrice)&&doublePrice>=0)
            {
                Admin admin = new Admin("admin", "admin");
                admin.AddMovie(name, doublePrice,new List<Projection>());
            }
            else
            {
                MessageBox.Show("Wrong name or price");
            }
            AdminPanel panel = new AdminPanel(window);
            window.DataContext = panel.DataContext;
            window.Content = panel.Content;

            EmailSender emailSender=new EmailSender();
            new Thread(
                new ParameterizedThreadStart(
                    emailSender.SendToAll)).Start("Premiere of the movie: "+name+" in Eilat Stone! "+
                                                  "We remind you that as a loyal customer, you can have a discounted ticket.");
        }

        private void OnBackButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPanel panel = new AdminPanel(window);
            window.DataContext = panel.DataContext;
            window.Content = panel.Content;
        }
    }
}
