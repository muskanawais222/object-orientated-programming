using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task3product.BL;

namespace task3product
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            List<Product> products = new List<Product>();
            List<Customer> customers = new List<Customer>();
            Customer Clients = new Customer();
            while(running)
            {
                int choice;
                choice = menu();
                if(choice == 1)
                {
                    products.Add(addProduct());
                }
               else if(choice == 2)
                {
                    ViewProducts(products);
                }
              else  if(choice == 3)
                {
                    customers.Add(addCustomer());
                }
              else if(choice == 4 )
                {
                    ViewCustomers(customers , products);
                }
                else
                {
                    running = false;
                    Console.WriteLine("Exit");
                }
            }
        }
        static int menu()
        {
            Console.Clear();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View product");
            Console.WriteLine("3. Add customer");
            Console.WriteLine("4. View customer");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            int choice = int.Parse(Console.ReadLine());
            return choice;

        }
        static Product addProduct()
        {
            Console.Clear();
            Console.WriteLine("ENter the name of product: ");
            string name = Console.ReadLine();
            Console.WriteLine("ENter the category of product: ");
            string category = Console.ReadLine();
            Console.WriteLine("ENter the price of product: ");
            int price = int.Parse(Console.ReadLine());
            Product products = new Product(name, category, price);
            return products;


        }
        static void ViewProducts(List<Product> Product)
        {
            foreach (Product Record in Product)
            {
                Console.Clear();
                Console.WriteLine("Product : " + Record.Name);
                Console.WriteLine("Category : " + Record.Category);
                Console.WriteLine("Price : " + Record.Price);
                Console.ReadKey();
            }
        }
        static Customer addCustomer()
        {
            Console.Clear();
            List<Customer> Record = new List<Customer>();
            Console.WriteLine("Enter name of customer");
            string name = Console.ReadLine();
            Console.Write("Enter Costumer's Contact : ");
            int no = int.Parse(Console.ReadLine());
            Console.Write("Enter Costumer's Address : ");
            string address = Console.ReadLine();
            InputProductRecord(Record);
            Customer CustomerRecord = new Customer(name, no, address, Customer);
            return CustomerRecord;
        }
        static void InputProductRecord(List<Customer> customers)
        {
            Console.Write("Enter Number Of Product's Purchased By The User : ");
            int Loop = int.Parse(Console.ReadLine());
            for (int i = 0; i < Loop; i++)
            {
                Console.Write("Enter Product's Name : ");
                string Name = Console.ReadLine();
                Customer Product = new Customer(Name);
                customers.Add(Product);
            }
        }
        static void ViewCustomers(List<Customer> Costumer, List<Product> Product)
        {
            foreach (Customer Record in Costumer)
            {
                float Tax = 0;
                int i = 1;
                Console.Clear();
                Console.WriteLine("Customer : " + Record.CustomerName);
                Console.WriteLine("Contact : " + Record.customerContact);
                Console.WriteLine("Address : " + Record.customerAddress);
                foreach (Customer ProductRecord in Record.products)
                {
                    Console.WriteLine("Product # " + i + " : " + Record.Product.Name);
                    foreach (Product ProductData in ProductRecord)
                        if (ProductRecord.Name == ProductData.Name)
                        {
                            Tax = Tax + Customers.calculateTax(Product);
                            i++;
                        }
                }
                Console.WriteLine("Customer's Total Amount With Tax Is " + Tax + ".");
                Console.ReadKey();
            }
        }


        }
}
