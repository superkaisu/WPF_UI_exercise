using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for InvoiceListView.xaml
    /// </summary>
    public partial class InvoiceListView : Window
    {
        public InvoiceListView()
        {
            InitializeComponent();
        }

        public InvoiceListView(ObservableCollection<Invoice> invoices) : this()
        {
            //Here "binded" products-list to the datagrid
            gridInvoiceData.ItemsSource = invoices;
        }


        private void grdInvoiceData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var repo = new InvoiceRepository();
            this.DataContext = repo.GetInvoices();
        }
    }
}
