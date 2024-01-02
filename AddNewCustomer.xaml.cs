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


namespace kayttoliittyma_harjoitustyo
{
    /// <summary>
    /// Interaction logic for AddNewInvoice.xaml
    /// </summary>
    public partial class AddNewCustomer : Window
    {
        public AddNewCustomer()
        {
            InitializeComponent();

            this.DataContext = new Customer();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)this.DataContext;

            var repo = new InvoiceRepository();

            repo.AddNewCustomer(customer);

            DialogResult = true; //closing the window after saving customer
        }
    }
}
