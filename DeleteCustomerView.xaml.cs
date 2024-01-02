﻿using System;
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
    /// Interaction logic for DeleteCustomerView.xaml
    /// </summary>
    public partial class DeleteCustomerView : Window
    {
        public DeleteCustomerView()
        {
            InitializeComponent();

            this.DataContext = new Customer();
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = this.DataContext as Customer;

            var repo = new InvoiceRepository();
            repo.DeleteCustomer(customer);

            DialogResult = true;
        }
    }
}
