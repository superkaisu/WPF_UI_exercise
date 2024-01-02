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
    /// Interaction logic for AddNewProductView.xaml
    /// </summary>
    public partial class AddNewProductView : Window
    {
        private InvoiceRepository repo = new InvoiceRepository();
        public AddNewProductView()
        {
            InitializeComponent();

            this.DataContext = new Product();
        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = this.DataContext as Product;

            repo.AddNewProduct(product);

        }
    }
}
