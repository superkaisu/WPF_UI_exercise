using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace kayttoliittyma_harjoitustyo
{
    /// <summary>
    /// Product class
    /// </summary>
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductMeasure { get; set; }
        public double? UnitPrice { get; set; }

        public ObservableCollection<Product> products;

        public Product()
        {
            ProductID = 0;
            ObservableCollection<Product> products = new ObservableCollection<Product>();
        }

    }
}
