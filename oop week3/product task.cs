using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using product_task.bl;
using System.Threading;

namespace product_task
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Running = true;
            List<product> Data = new List<product>(); // list
            while (Running)
            {
                string Choice = MainMenu();
                if (Choice == "1")
                {
                    Data.Add(TakeInput());
                }
                else if (Choice == "2")
                {
                    Console.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        Data[i].viewProducts();
                    }
                    Console.ReadKey();
                }
                else if (Choice == "3")
                {
                    Console.Clear();
                    product Product = new product();
                    string ExpensiveProduct = Product.CostlyProducts(Data);
                    Console.Write("Product With Highest Unit Price is " + ExpensiveProduct + ".");
                    Console.ReadKey();
                }
                else if (Choice == "4")
                {
                    Console.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        float SalesTax = Data[i].TaxCalculator();
                        Console.WriteLine("Product Name:  " + Data[i].Name_of_pro);
                        Console.WriteLine("Tax Price is:  " + SalesTax);
                        Console.WriteLine();
                    }

                    Console.ReadKey();
                }
                else if (Choice == "5")
                {
                    Console.Clear();
                    for (int i = 0; i < Data.Count; i++)
                    {
                        string Minimum = Data[i].ToBeOrdered();
                        if (Minimum != "")
                        {
                            Console.WriteLine("The products to be ordered are  " + Minimum + ".");
                        }

                    }
                    Console.ReadKey();

                }
                else if (Choice == "6")
                {
                    Running = false;
                }
                else
                {
                    Console.Clear();
                    Console.Write("Invalid Choice");
                    Thread.Sleep(2000);
                }

            }
        }
        // main menu of store
        static string MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Add different Products");
            Console.WriteLine("2. View all Products");
            Console.WriteLine("3. view Products With Highest Price");
            Console.WriteLine("4. View Sales With Taxes On Products");
            Console.WriteLine("5. Products To Be Ordered");
            Console.WriteLine("6. Exit");
            Console.WriteLine("");
            Console.Write("Enter Your Choice : ");
            string Choice = Console.ReadLine();
            return Choice;
        }
        // take inputs from the admin 
        static product TakeInput()
        {
            Console.Clear();
            product input = new product(); // object
            Console.Write("Enter Product's Name : ");
            input.Name_of_pro = Console.ReadLine();
            Console.Write("Enter Product's Category : ");
            input.Category_of_pro = Console.ReadLine();
            Console.Write("Enter Product's Price : ");
            input.Price_of_pro = float.Parse(Console.ReadLine());
            Console.Write("Enter Product's Monthly Available Stock : ");
            input.Stock_of_pro = int.Parse(Console.ReadLine());
            Console.Write("Enter Product's Available Stock : ");
            input.MinimumStock_of_pro = int.Parse(Console.ReadLine());
            return input;
        }
    }
}
