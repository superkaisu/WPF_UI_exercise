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
    /// Interaction logic for ProductListView.xaml
    /// </summary>
    public partial class ProductListView : Window
    {
        private InvoiceRepository repo;
        public ProductListView()
        {
            InitializeComponent();
            repo = new InvoiceRepository();
        }

        public ProductListView(ObservableCollection<Product> products) : this()
        {
            //Here "binded" products-list to the datagrid
            gridProductData.ItemsSource = products;
        }

        private void grdProductData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.DataContext = repo.GetAllProducts();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateProductView updateProduct = new UpdateProductView();
            updateProduct.ShowDialog();

            DialogResult = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteProductView deleteProduct = new DeleteProductView();
            deleteProduct.ShowDialog();

            DialogResult = true;
        }
    }

}