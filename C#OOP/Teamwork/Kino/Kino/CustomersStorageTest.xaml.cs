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
using Kino.Classes;
namespace Kino
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CustomersStorageTest : Window
    {
        public CustomersStorageTest()
        {
            InitializeComponent();
        }

        private void AddToFile(object sender, RoutedEventArgs e)
        {
            Employee employeeInstance = new Employee("","");
            employeeInstance.AddCustomer("Ivan", "123@mail.bg", DateTime.Now, 0);
            employeeInstance.AddCustomer("BaiPesho", "123@mail.bg", DateTime.Now, 0);
            ShowInformation();
        }

        private void ShowInformation()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var currentCustomer in CustomersStorage.Customers)
            {
                builder.Append(currentCustomer.Id + 
                               currentCustomer.Name + 
                               currentCustomer.Email + Environment.NewLine + 
                               currentCustomer.Age + 
                               currentCustomer.DateOfBirth + 
                               currentCustomer.LoyaltyPoints+Environment.NewLine);
            }
            TestBlock.Text = builder.ToString();
        }

        private void ReadFromFile(object sender, RoutedEventArgs e)
        {
            CustomersStorage.Instance.GetInformation();
            ShowInformation();
        }
    }
}
