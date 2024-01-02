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
    public partial class AddNewInvoice : Window
    {
        private InvoiceRepository repo = new InvoiceRepository();
        public AddNewInvoice()
        {
            InitializeComponent();

            this.DataContext = new Invoice();

            comProductNameColumn_newInvoice.ItemsSource = repo.GetAllProducts();
        }

        private void btnSaveNewInvoice(object sender, RoutedEventArgs e)
        {
            var invoice = (Invoice)this.DataContext;

            repo.AddNewInvoice(invoice);

            repo.GetInvoices();

            DialogResult = true;

        }

    }
}
