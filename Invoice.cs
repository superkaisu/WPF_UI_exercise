using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace kayttoliittyma_harjoitustyo
{
    /// <summary>
    /// Invoice class
    /// </summary>
    public class Invoice : Customer
    {
        public int InvoiceNbr { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime InvoiceDueDate { get; set; }
        public ObservableCollection<InvoiceLine> InvoiceLines { get; set; }
        public double InvoiceLineTotal { get; set; }

        public double InvoiceTotal { get; set; }
 
 


        //Constructor for Invoice with automatic due date
        public Invoice()
        {

            InvoiceDate = DateTime.Today;
            DateTime newDate = InvoiceDate.AddDays(14);
            InvoiceDueDate = newDate;
            InvoiceTotal = 0;

            InvoiceLines = new ObservableCollection<InvoiceLine>();
            
        }

        //public double AddToInvoiceTotal()
        //{
        //    double sum = 0;

        //    foreach (var item in InvoiceLines)
        //    {
        //        sum += item.InvoiceLineTotal;
        //    }

        //   return invoiceTotal = sum;
        //}
    }
}
