using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Shapes;

namespace kayttoliittyma_harjoitustyo
{
    public class InvoiceRepository
    {
        //Paths for creating db and conn "ConnectionStrings"
        private const string local = @"Server=127.0.0.1; Port=3306; User ID=opiskelija; Pwd=opiskelija1;";
        private const string localWithDB = @"Server=127.0.0.1; Port=3306; User ID=opiskelija; Pwd=opiskelija1; Database=InvoiceDb;";

        /// <summary>
        /// Creating the DataBase to HeidiSql
        /// </summary>
        public void CreateInvoiceDb()
        {
            using (MySqlConnection conn = new MySqlConnection(local))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DROP DATABASE IF EXISTS InvoiceDb", conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("CREATE DATABASE InvoiceDb", conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Customers Table to HeidiSql
        /// </summary>
        public void CreateCustomersTable()
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {

                conn.Open();

                string createTable = "CREATE TABLE Customers (CustomerID INT NOT NULL PRIMARY KEY AUTO_INCREMENT, Customer_name VARCHAR(50), " +
                                        "Street_address VARCHAR(50), Postal_code INT, City VARCHAR(30))";

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Invoice Table to HeidiSql
        /// </summary>
        public void CreateInvoiceTable()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                string createTable = "CREATE TABLE Invoices (InvoiceNbr INT NOT NULL PRIMARY KEY AUTO_INCREMENT,"
                    + "Invoice_date DATETIME, Due_date DATETIME, CustomerID INT, FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID))";


                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Products Table to HeidiSql
        /// </summary>
        public void CreateProductsTable()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                string createTable = "CREATE TABLE Products (ProductID INT NOT NULL PRIMARY KEY AUTO_INCREMENT, Product_name VARCHAR(50), " +
                                        "Product_measure VARCHAR(30), Product_price DOUBLE)";

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// InvoiceLines table to HeidiSql
        /// </summary>
        public void CreateInvoiceLinesTable()
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {

                conn.Open();

                string createTable = "CREATE TABLE InvoiceLines (LineID INT NOT NULL PRIMARY KEY AUTO_INCREMENT, Line_productQty INT, " +
                                        "InvoiceNbr INT, ProductID INT, FOREIGN KEY (InvoiceNbr) REFERENCES Invoices(InvoiceNbr))";

                MySqlCommand cmd = new MySqlCommand(createTable, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand("ALTER TABLE InvoiceLines ADD FOREIGN KEY (ProductID) REFERENCES Products(ProductID)", conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Demo invoices
        /// </summary>
        public void AddDemoInvoices()
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                string invoice1 = "INSERT INTO Invoices(Invoice_date, Due_date, CustomerID)" +
                    "VALUES (CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY), 1)";
                string invoice2 = "INSERT INTO Invoices(Invoice_date, Due_date, CustomerID)" +
                    "VALUES (CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY), 2)";
                string invoice3 = "INSERT INTO Invoices(Invoice_date, Due_date, CustomerID)" +
                    "VALUES (CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY), 3)";
                string invoice4 = "INSERT INTO Invoices(Invoice_date, Due_date, CustomerID)" +
                    "VALUES (CURDATE(), DATE_ADD(CURDATE(), INTERVAL 14 DAY), 4)";


                MySqlCommand cmd = new MySqlCommand(invoice1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoice4, conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Demo Invoices InvoiceLines
        /// </summary>
        public void AddDemoInvoiceLines()
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {

                conn.Open();

                string invoiceLine1 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(5, 1, 1)";
                string invoiceLine2 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(2, 1, 2)";
                string invoiceLine3 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(10, 1, 4)";

                string invoiceLine4 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(10, 2, 1)";
                string invoiceLine5 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(100, 2, 2)";
                string invoiceLine6 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(4, 2, 3)";
                string invoiceLine7 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(28, 2, 4)";

                string invoiceLine8 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(1, 3, 1)";
                string invoiceLine9 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(3, 3, 4)";

                string invoiceLine10 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(20, 4, 2)";
                string invoiceLine11 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(1, 4, 3)";
                string invoiceLine12 = "INSERT INTO InvoiceLines(Line_productQty, InvoiceNbr, ProductID)" +
                    "VALUES(5, 4, 4)";

                MySqlCommand cmd = new MySqlCommand(invoiceLine1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine4, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine5, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine6, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine7, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine8, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine9, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine10, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine11, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(invoiceLine12, conn);
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// This adds basic products
        /// </summary>
        public void AddProducts()
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                string product1 = "INSERT INTO Products(Product_name, Product_measure, Product_price)" +
                    "VALUES('Silikoni', 'kpl', 8.05)";
                string product2 = "INSERT INTO Products(Product_name, Product_measure, Product_price)" +
                    "VALUES('Laatta', 'kpl', 2.10)";
                string product3 = "INSERT INTO Products(Product_name, Product_measure, Product_price)" +
                    "VALUES('Sementti', 'säkki', 6.99)";
                string product4 = "INSERT INTO Products(Product_name, Product_measure, Product_price)" +
                    "VALUES('Tyo', 'h', 60.00)";

                MySqlCommand cmd = new MySqlCommand(product1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(product4, conn);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Adding existing customers
        /// </summary>
        public void AddCustomers()
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                string customer1 = "INSERT INTO Customers(Customer_name, Street_address, Postal_code, City)" +
                    "VALUES('Reijo Keinänen', 'Tilhentie 1', 60123, 'Töysä' )";
                string customer2 = "INSERT INTO Customers(Customer_name, Street_address, Postal_code, City)" +
                    "VALUES('Tellervo Komulainen', 'Haapatie 222', 80123, 'Iisvesi' )";
                string customer3 = "INSERT INTO Customers(Customer_name, Street_address, Postal_code, City)" +
                    "VALUES('Eija Liimatta', 'Riimukuja 2 a 19', 70123, 'Rantasalmi' )";
                string customer4 = "INSERT INTO Customers(Customer_name, Street_address, Postal_code, City)" +
                    "VALUES('Anselmi Raivo', 'Rantatie 37', 50123, 'Ristiina' )";

                MySqlCommand cmd = new MySqlCommand(customer1, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(customer2, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(customer3, conn);
                cmd.ExecuteNonQuery();

                cmd = new MySqlCommand(customer4, conn);
                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// To get all products listed in DB
        /// </summary>
        /// <returns>ObservableCollection products</returns>
        ///
        public ObservableCollection<Product> GetAllProducts()
        {
            var products = new ObservableCollection<Product>();

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM products", conn);

                //Let's make a DataReader dr
                var dr = cmd.ExecuteReader();

                //
                while (dr.Read())
                {
                    Debug.WriteLine(dr.GetInt32("ProductID"));
                    Debug.WriteLine(dr.GetString("Product_name"));
                    Debug.WriteLine(dr.GetString("Product_measure"));
                    Debug.WriteLine(dr.GetDouble("Product_price"));

                    //Notice syntax
                    products.Add(new Product
                    {
                        ProductID = dr.GetInt32("ProductID"),
                        ProductName = dr.GetString("Product_name"),
                        ProductMeasure = dr.GetString("Product_measure"),
                        UnitPrice = dr.GetDouble("Product_price")
                    });
                }
            }

            return products;
        }


        //Tarvitaanko tätä?
        //public ObservableCollection<Invoice> GetAllInvoices()
        //{
        //    var invoices = new ObservableCollection<Invoice>();

        //    using (MySqlConnection conn = new MySqlConnection(localWithDB))
        //    {
        //        conn.Open();

        //        MySqlCommand cmd = new MySqlCommand("SELECT * FROM invoices", conn);

        //        //Let's make a DataReader dr
        //        var dr = cmd.ExecuteReader();



        //        while (dr.Read())
        //        {
        //            int invoiceNbr = dr.GetInt32("InvoiceNbr");
        //            Debug.WriteLine(dr.GetInt32("InvoiceNbr"));
        //            Debug.WriteLine(dr.GetDateTime("Invoice_date"));
        //            Debug.WriteLine(dr.GetDateTime("Due_date"));
        //            Debug.WriteLine(dr.GetInt32("CustomerID"));

        //            //Notice syntax
        //            invoices.Add(new Invoice
        //            {
        //                InvoiceNbr = dr.GetInt32("InvoiceNbr"),
        //                InvoiceDate = dr.GetDateTime("Invoice_date"),
        //                InvoiceDueDate = dr.GetDateTime("Due_date"),
        //                CustomerID = dr.GetInt32("CustomerID"),
        //            });

        //        }

        //    }

        //    return invoices;
        //}
        /// <summary>
        /// Gets invoices and invoiceLines from db
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Invoice> GetInvoices()
        {
            var invoices = new ObservableCollection<Invoice>();


            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                double sum = 0;
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT * FROM Invoices i, Customers c WHERE i.CustomerID = c.CustomerID", conn);

                var dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    var newInvoice = new Invoice
                    {
                        InvoiceNbr = dr.GetInt32("InvoiceNbr"),
                        InvoiceDate = dr.GetDateTime("Invoice_date"),
                        InvoiceDueDate = dr.GetDateTime("Due_date"),
                        CustomerID = dr.GetInt32("CustomerID"),
                        CustomerName = dr.GetString("Customer_name"),
                        StreetAddress = dr.GetString("Street_address"),
                        PostalCode = dr.GetInt32("Postal_code"),
                        City = dr.GetString("City")

                    };

                    GetLines(newInvoice);

                    foreach (var item in newInvoice.InvoiceLines)
                    {
                        sum += item.InvoiceLineTotal;
                    }

                    sum = Math.Round(sum, 2);

                    newInvoice.InvoiceTotal = sum;

                    invoices.Add(newInvoice);

                    sum = 0;
                }

                return invoices;
            }

        }
        /// <summary>
        /// Method to get lines for specific invoice from db.
        /// </summary>
        /// <param name="newInvoice"></param>
        public void GetLines(Invoice newInvoice)
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {

                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT i.LineID, i.Line_ProductQty, i.InvoiceNbr, i.ProductID, p.productID, p.Product_price FROM invoicelines i, products p " +
                    "WHERE p.ProductID = i.ProductID AND InvoiceNbr=@InvoiceNbr", conn);
                cmd.Parameters.AddWithValue("@InvoiceNbr", newInvoice.InvoiceNbr); //Choosing the invoice that's modified

                var dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    newInvoice.InvoiceLines.Add(new InvoiceLine
                    {
                        InvoiceLineID = dr.GetInt32("LineID"),
                        LineProductQty = dr.GetInt32("Line_ProductQty"),
                        InvoiceNbr = dr.GetInt32("InvoiceNbr"),
                        ProductID = dr.GetInt32("ProductID"),
                        UnitPrice = dr.GetDouble("Product_price")
                    });
                }

            }

        }
        /// <summary>
        /// Get customer list
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Customer> ListAllCustomers()
        {
            var customers = new ObservableCollection<Customer>();

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM customers", conn);

                var dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerID = dr.GetInt32("CustomerID"),
                        CustomerName = dr.GetString("Customer_name"),
                        PostalCode = dr.GetInt32("Postal_code"),
                        StreetAddress = dr.GetString("Street_address"),
                        City = dr.GetString("City")
                    });

                }

            }

            return customers;
        }

        /// <summary>
        /// Save invoice after modifying
        /// </summary>
        /// <param name="invoice"></param>
        public void SaveInvoice(Invoice invoice)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("UPDATE invoices SET Invoice_date=@Invoice_date, Due_date=@Due_date, " +
                    "CustomerID=@CustomerID WHERE InvoiceNbr=@InvoiceNbr", conn);
                cmd.Parameters.AddWithValue("@InvoiceNbr", invoice.InvoiceNbr);
                cmd.Parameters.AddWithValue("@Invoice_date", invoice.InvoiceDate);
                cmd.Parameters.AddWithValue("@Due_date", invoice.InvoiceDueDate);
                cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);

                cmd.ExecuteNonQuery();

                foreach (var line in invoice.InvoiceLines)
                {
                    //Inserting new line
                    if (line.InvoiceLineID == 0)
                    {
                        MySqlCommand cmdIns = new MySqlCommand("INSERT INTO invoicelines (Line_productQty, InvoiceNbr, ProductID) VALUES(@Line_productQty, @InvoiceNbr, @ProductID)", conn);
                        cmdIns.Parameters.AddWithValue("@Line_productQty", line.LineProductQty);
                        cmdIns.Parameters.AddWithValue("InvoiceNbr", invoice.InvoiceNbr);
                        cmdIns.Parameters.AddWithValue("@ProductID", line.ProductID);

                        cmdIns.ExecuteNonQuery();

                    }
                    //Updating existing line
                    else
                    {
                        MySqlCommand cmdUpd = new MySqlCommand("UPDATE invoicelines SET Line_productQty=@Line_productQty, InvoiceNbr=@InvoiceNbr, ProductID=@ProductID WHERE LineID=@LineID", conn);

                        cmdUpd.Parameters.AddWithValue("@Line_productQty", line.LineProductQty);
                        cmdUpd.Parameters.AddWithValue("@InvoiceNbr", invoice.InvoiceNbr);
                        cmdUpd.Parameters.AddWithValue("@ProductID", line.ProductID);
                        cmdUpd.Parameters.AddWithValue("LineID", line.InvoiceLineID);

                        cmdUpd.ExecuteNonQuery();
                    }



                }
            }

        }

        /// <summary>
        /// Adding new Customer to db
        /// </summary>
        /// <param name="customer"></param>
        public void AddNewCustomer(Customer customer)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO customers(Customer_name, Street_address, Postal_code, City) " +
                    "VALUES(@Customer_name, @Street_address, @Postal_code, @City)", conn);
                cmd.Parameters.AddWithValue("@Customer_name", customer.CustomerName);
                cmd.Parameters.AddWithValue("@Street_address", customer.StreetAddress);
                cmd.Parameters.AddWithValue("@Postal_code", customer.PostalCode);
                cmd.Parameters.AddWithValue("@City", customer.City);

                cmd.ExecuteNonQuery();
            }

        }
        /// <summary>
        /// Adding new Invoice with InvoiceLines to db
        /// </summary>
        /// <param name="invoice"></param>
        public void AddNewInvoice(Invoice invoice)
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO invoices (Invoice_date, Due_date, CustomerID) VALUES(@Invoice_date, @Due_date, @CustomerID)", conn);
                cmd.Parameters.AddWithValue("@Invoice_date", invoice.InvoiceDate);
                cmd.Parameters.AddWithValue("@Due_date", invoice.InvoiceDueDate);
                cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);

                cmd.ExecuteNonQuery();

            }

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT InvoiceNbr FROM invoices ORDER BY InvoiceNbr DESC LIMIT 1", conn);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    invoice.InvoiceNbr = dr.GetInt32("InvoiceNbr");
                }
            }

            AddInvoiceLines_NewInvoice(invoice);
        }
        /// <summary>
        /// Adding InvoiceLines of spesific invoice to db
        /// </summary>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public ObservableCollection<InvoiceLine> AddInvoiceLines_NewInvoice(Invoice invoice)
        {
            var invoiceLines = new ObservableCollection<InvoiceLine>();

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                foreach (var line in invoice.InvoiceLines)
                {
                    MySqlCommand cmdIns = new MySqlCommand("INSERT INTO invoicelines (Line_productQty, InvoiceNbr, ProductID) VALUES(@Line_productQty, @InvoiceNbr, @ProductID)", conn);
                    cmdIns.Parameters.AddWithValue("@Line_productQty", line.LineProductQty);
                    cmdIns.Parameters.AddWithValue("InvoiceNbr", invoice.InvoiceNbr);
                    cmdIns.Parameters.AddWithValue("@ProductID", line.ProductID);

                    cmdIns.ExecuteNonQuery();

                }
            }
                return invoiceLines;
        }
        /// <summary>
        /// Deleting a customer and all their invoices and invoiceLines
        /// </summary>
        /// <param name="customer"></param>
        public void DeleteCustomer(Customer customer)
        {

            int invoiceNbr = 0;

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT InvoiceNbr FROM invoices WHERE CustomerID=@CustomerID", conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);

                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    invoiceNbr = dr.GetInt32("InvoiceNbr");
                }
            }

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM invoiceLines WHERE InvoiceNbr=@InvoiceNbr", conn);
                cmd.Parameters.AddWithValue("@InvoiceNbr", invoiceNbr);
                cmd.ExecuteNonQuery();
            }

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM invoices WHERE CustomerID=@CustomerID", conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.ExecuteNonQuery();
            }

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM Customers WHERE CustomerID=@CustomerID", conn);
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Deleting an Invoice and all it's invoicelines
        /// </summary>
        /// <param name="invoice"></param>
        public void DeleteInvoice(Invoice invoice)
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM invoiceLines WHERE InvoiceNbr=@InvoiceNbr", conn);
                cmd.Parameters.AddWithValue("@InvoiceNbr", invoice.InvoiceNbr);
                cmd.ExecuteNonQuery();
            }

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM invoices WHERE InvoiceNbr=@InvoiceNbr", conn);
                cmd.Parameters.AddWithValue("@InvoiceNbr", invoice.InvoiceNbr);
                cmd.ExecuteNonQuery();
            }

        }
        /// <summary>
        /// Add a new Product
        /// </summary>
        /// <param name="product"></param>
        public void AddNewProduct(Product product)
        {
            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO products (Product_name, Product_measure, Product_price) VALUES(@Product_name, @Product_measure, @Product_price)", conn);
                cmd.Parameters.AddWithValue("@Product_name", product.ProductName);
                cmd.Parameters.AddWithValue("@Product_measure", product.ProductMeasure);
                cmd.Parameters.AddWithValue("@Product_price", product.UnitPrice);

                cmd.ExecuteNonQuery();

            }
        }
        /// <summary>
        /// Save updated product
        /// </summary>
        /// <param name="product"></param>
        public void UpdateAndRefreshProducts(Product product)
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                if (product.ProductID != 0)
                {
                    MySqlCommand cmdUpd = new MySqlCommand("UPDATE products SET Product_name=@Product_name, Product_measure=@Product_measure, Product_price=@Product_price WHERE ProductID=@ProductID", conn);

                    cmdUpd.Parameters.AddWithValue("@Product_name", product.ProductName);
                    cmdUpd.Parameters.AddWithValue("@Product_measure", product.ProductMeasure);
                    cmdUpd.Parameters.AddWithValue("@Product_price", product.UnitPrice);
                    cmdUpd.Parameters.AddWithValue("ProductID", product.ProductID);

                    cmdUpd.ExecuteNonQuery();
                }

            }

        }
        /// <summary>
        /// Delete product from all invoiceLines and from Products table
        /// </summary>
        /// <param name="product"></param>
        public void DeleteProduct(Product product)
        {

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM invoiceLines WHERE ProductID=@ProductID", conn);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.ExecuteNonQuery();
            }

            using (MySqlConnection conn = new MySqlConnection(localWithDB))
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM products WHERE ProductID=@ProductID", conn);
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
