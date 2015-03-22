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
    /// Interaction logic for LoyalCustomerRegistration.xaml
    /// </summary>
    public partial class LoyalCustomerRegistration : Page
    {
        private Window window;
        public LoyalCustomerRegistration(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void OnFinishButton_Click(object sender, RoutedEventArgs e)
        {
            if(BirthDate.SelectedDate!=null&&BirthDate.SelectedDate<DateTime.Now)
            {
                //Трябва да се изпозлва Eployee инстанция и чрез метода AddCustomer се създава клиент и автоматично се записва и в файла. Id-то се генерира автоматично
                Employee lelka = new Employee("lelka", "lelka");
                lelka.AddCustomer(CustomerName.Text,CustomerEmail.Text,BirthDate.DisplayDate,1);
            }
            else
            {
                MessageBox.Show("Wrong date!");
            }

            OperatorPanel operatorPanel = new OperatorPanel(window);
            window.Content = operatorPanel.Content;
        }


    }
}
