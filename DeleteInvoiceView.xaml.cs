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
    /// Interaction logic for DeleteInvoiceView.xaml
    /// </summary>
    public partial class DeleteInvoiceView : Window
    {
        public DeleteInvoiceView()
        {
            InitializeComponent();

            this.DataContext = new Invoice();
        }

        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            var invoice = this.DataContext as Invoice;

            var repo = new InvoiceRepository();
            repo.DeleteInvoice(invoice);

            DialogResult = true;
        }
    }
}

