using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace product_Challenge
{
    class Program
    {
        class products
        {
            public string Name_of_Product;
            public int product_ID;
            public int price;
            public string category;
            public string brandName;
            public string country;

        }
        static void Main(string[] args)
        {
            products[] p = new products[10]; //  array of products
            char option;
            int count = 0;
            
            do
            {
                option = menu();
                if (option == '1')
                {
                    p[count] = addProduct();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewProducts(p, count);
                }
                else if (option == '3')
                {
                   int result = sum_Of_the_price(p, count);
                    Console.WriteLine("result is " + result);
                    Console.ReadKey();
                }
                else if (option == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }


            }
            while (option != '4');
            {
                Console.WriteLine("Press enter to exit..");
                Console.Read();
            }
        }
        // menu
        static char menu()
        {
            Console.Clear();
            char choice;
            Console.WriteLine("Press1 for ADDING a Products: ");
            Console.WriteLine("Press2 for VIEW  products: ");
            Console.WriteLine("Press3 for Total store worth : ");
            Console.WriteLine("Press4 for to exit ");
            choice = char.Parse(Console.ReadLine());
            return choice;
        }
        // add products
        static products addProduct()
        {
            Console.Clear();
            products p1 = new products();
            Console.WriteLine("Enter the ID of the product ");
            p1.product_ID = int .Parse(Console.ReadLine());
            Console.WriteLine("Enter the Name of product");
            p1.Name_of_Product = Console.ReadLine();
            Console.WriteLine("Enter the price of product: ");
            p1.price = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the category of product ");
            p1.category = Console.ReadLine();
            Console.WriteLine("enter the name ofproduct: ");
            p1.brandName = Console.ReadLine();
            Console.WriteLine("Enter the country ");
            p1.country = Console.ReadLine();
            return p1;
        }
        static void viewProducts(products[] p, int count)
        {
            Console.Clear();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("ID of the product:  {0} Name of product: {1} Price of product: {2} category of product: {3} Brand Name: {4} Country: {5} ", p[i].product_ID, p[i].Name_of_Product, p[i].price, p[i].category, p[i].brandName, p[i].country);
            }
            Console.WriteLine("Press any key to continue:");
            Console.ReadKey();
        }
        static int sum_Of_the_price(products[] p,int count)
        {
            int totalPrice = 0;
            for(int x= 0; x < count;x++)
            {
                totalPrice = totalPrice + p[x].price;
            }
            return totalPrice;
        }

    }
}


