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
    /// Interaction logic for CustomerListView.xaml
    /// </summary>
    public partial class CustomerListView : Window
    {
        public CustomerListView()
        {
            InitializeComponent();
        }

        public CustomerListView(ObservableCollection<Customer> customers) : this()
        {
            //Here "binded" products-list to the datagrid
            gridCustomerData.ItemsSource = customers;
        }


    }
}
