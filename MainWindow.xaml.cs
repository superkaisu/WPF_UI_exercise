using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace kayttoliittyma_harjoitustyo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InvoiceRepository repo;
        private ObservableCollection<Invoice> invoices;



        private int index;
        public MainWindow()
        {
            InitializeComponent();

            repo = new InvoiceRepository();

            repo.CreateInvoiceDb();
            repo.CreateCustomersTable();
            repo.CreateProductsTable();
            repo.CreateInvoiceTable();
            repo.CreateInvoiceLinesTable();

            repo.AddCustomers();
            repo.AddProducts();
            repo.AddDemoInvoices();
            repo.AddDemoInvoiceLines();


            // This is for showing product name in datagrid
            comProductNameColumn.ItemsSource = repo.GetAllProducts();

            //Main window datacontext
            invoices = repo.GetInvoices();

            this.DataContext = invoices[0];

            //lblInvoiceTotal.Content = sum;

        }

        private void AddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            AddNewProductView addNewProduct = new AddNewProductView();

            addNewProduct.ShowDialog();
        }

        private void GetAllProducts(object sender, RoutedEventArgs e)
        {
            var products = repo.GetAllProducts();
            var listView = new ProductListView(products);
            listView.ShowDialog();
        }

        // KESKEN

        private void grdInvoiceLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FirstInvoiceClick(object sender, RoutedEventArgs e)
        {
            index = 0;
            this.DataContext = invoices[index];
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            index++;
            if (index >= invoices.Count)
            {
                index = invoices.Count - 1;
            }
            invoices = repo.GetInvoices();
            this.DataContext = invoices[index];
        }

        private void PrevClick(object sender, RoutedEventArgs e)
        {
            index--;
            if (index < 0)
            {
                index = 0;
            }
            invoices = repo.GetInvoices();
            this.DataContext = invoices[index];
        }

        private void LastInvoiceClick(object sender, RoutedEventArgs e)
        {
            invoices = repo.GetInvoices();
            index = invoices.Count - 1;
            this.DataContext = invoices[index];
        }

        private void ListAllIncvoices(object sender, RoutedEventArgs e)
        {
            var refreshInvoices = repo.GetInvoices();
            var listView = new InvoiceListView(refreshInvoices);
            listView.ShowDialog();

        }

        private void btnClickSaveInvoice(object sender, RoutedEventArgs e)
        {
            var invoice = (Invoice)this.DataContext;

            repo.SaveInvoice(invoice);

            this.DataContext = repo.GetInvoices();

        }
        private void btnAddNewInvoice(object sender, RoutedEventArgs e)
        {
            AddNewInvoice addNew = new AddNewInvoice();

            addNew.ShowDialog();

        }

        private void btnAddCustomer(object sender, RoutedEventArgs e)
        {
            AddNewCustomer addNew = new AddNewCustomer();

            addNew.ShowDialog();

        }

        private void ListAllCustomers(object sender, RoutedEventArgs e)
        {
            var refreshCustomers = repo.ListAllCustomers();
            var listView = new CustomerListView(refreshCustomers);
            listView.ShowDialog();
        }



        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            DeleteCustomerView deleteCustomer = new DeleteCustomerView();

            deleteCustomer.ShowDialog();


        }

        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            DeleteInvoiceView deleteInvoice = new DeleteInvoiceView();

            deleteInvoice.ShowDialog();
        }


        private void VersionInfoClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kaken Rakennus Oy Laskutusohjelma v1.0 (c)Kaisu Suurniemi", "Information");
        }

        private void AddInvoiceInfo(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Don't save empty invoice.", "Information");
        }

        private void ManagingProductsInfo(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Navigate Menubar to Products, where you can Add a product or List and Update products.", "Information");
        }

    }
}
