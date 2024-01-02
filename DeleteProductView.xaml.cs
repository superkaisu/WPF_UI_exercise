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
    /// Interaction logic for DeleteProductView.xaml
    /// </summary>
    public partial class DeleteProductView : Window
    {
        private InvoiceRepository repo = new InvoiceRepository();
        public DeleteProductView()
        {
            InitializeComponent();
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = this.DataContext as Product;

            repo.DeleteProduct(product);

            DialogResult = true;
        }
    }

}
