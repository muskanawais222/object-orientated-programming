using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using login.BL;
using System.Threading;
using System.IO;

namespace login
{
    class Program
    {
        static void Main(string[] args)
        {
            List<user> Users = new List<user> (); // list of users
            string path = "D:\\semester2\\Object Orientated Programing\\week3\\constructors\\pd3\\loginFile.txt";
            int option;
            bool check = readData(path, Users);
            if (check)
                Console.WriteLine("data Loaded successfully");
            else
                Console.WriteLine("Data cannot be loaded");
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    user customer = take_Input_WithOut_Role();
                    if (customer != null)
                    {
                        customer = signIn(customer, Users);
                        if (customer == null)
                            Console.WriteLine("Invalid User");
                        else if (customer.isAdmin())
                            Console.WriteLine("Admin Menu");
                        else
                            Console.WriteLine("User Menu");
                    }

                }
                else if (option == 2)
                {
                    user customer = takeInputWithRole();
                    if (customer != null)
                    {
                        storeDataInFile(path, customer);
                        storeDataInList(Users, customer);

                    }


                }
                Console.ReadLine();

            }
            while (option < 3);
        }

        // menu function
        static int menu()
        {
            int choice;
            Console.WriteLine("Press 1 for SignIn");
            Console.WriteLine("press 2 for Signup");
            Console.WriteLine("Enter your choice :-");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }

        // read data from file
        static bool readData(string path, List<user> users)

        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    user user = new user(name, password, role);
                    storeDataInList(users, user);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        // parse data
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length;
            x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        // store data in list
        static void storeDataInList(List<user> Users, user customer )
        {
            Users.Add(customer);
        }
        // taKe input with role '''''''''''''''''''''' For SignUp

        static user takeInputWithRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                user customers = new user(name, password, role);
                return customers;
            }
            return null;
        }

        // take input with Out role """""""""""""""""""" for sign In
        static user take_Input_WithOut_Role()
        {
            Console.WriteLine("Enter Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                user client = new user(name, password);
                return client;
            }
            return null;


        }


        // sign in to check validate user
        static user signIn(user customer, List<user> Users)
        {
             
          foreach (user storedUser in Users)  // for each loop
            {
           if (customer.name == storedUser.name && customer.password == storedUser.password)
            {
                return storedUser;
            }
            }
          return null;
         }
        // for sign up 
        // store data in file
        static void storeDataInFile(string path, user customer)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(customer.name + "," + customer.password + "," + customer.role);
            file.Flush();
            file.Close();
        }

    }
}

