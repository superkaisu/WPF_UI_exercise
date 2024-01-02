using System;
using System.ComponentModel;

namespace kayttoliittyma_harjoitustyo
{
    /// <summary>
    /// InvoiceLines for Invoices, 
    /// </summary>
    public class InvoiceLine : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int InvoiceLineID { get; set; }
        public int InvoiceNbr { get; set; }

        public int ProductID { get; set; }

        private double unitPrice = 0;

        public double UnitPrice
        {
            get
            {
                return unitPrice;
            }

            set
            {
                unitPrice = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InvoiceLineTotal"));
            }

        }

        private int lineProductQty = 0;
        public int LineProductQty
        {
            get
            {
                return lineProductQty;
            }
            set
            {
                lineProductQty = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("InvoiceLineTotal"));
            }

        }

        private double invoiceLineTotal = 0;
        public double InvoiceLineTotal
        {
            get
            {
                invoiceLineTotal = LineProductQty * UnitPrice;
                return Math.Round(invoiceLineTotal, 2);
            }

        }


    }
}
