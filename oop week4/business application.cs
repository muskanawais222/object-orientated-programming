using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_application.BL;
using System.Threading;
using System.IO;

namespace Business_application
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Userfile.txt";
            List<Users> userList = new List<Users>();
            bool check = readData(path, userList);
            Users user = new Users();
            if (check)
                Console.WriteLine("data Loaded successfully");
            else
                Console.WriteLine("Data cannot be loaded");
            Console.Read();
            bool running = true;
            while (running)
            {
                Console.Clear();
                int choice = loginMenu();
                if (choice == 1)
                {
                    user = take_Input_without_role(); // deafault constructor
                    if (user != null)
                    {
                        user = signIn(user, userList);
                        if (user == null)
                        {
                            Console.WriteLine("Invalip input");
                            clearScreen();
                        }
                        else if (user.isAdmin())
                        {
                            Console.WriteLine("Admin interface");
                        }
                        else
                            Console.WriteLine("User interface");
                    }

                }
                else if(choice == 2)
                {
                    Users u1 = takeInputWithRole();
                    if(u1 == null)
                    {
                      Console.WriteLine("invalid inputed:");
                        clearScreen();
                    }
                    else if( u1 != null)
                    {
                        Console.WriteLine("Your input is checking");
                        Thread.Sleep(2000);
                        Console.Clear();
                        bool check1 = isCheck(u1, userList);
                        if(check1 == false)
                        {
                            storeDataInList(u1, userList);
                            storeDataInFile(path, u1);
                            Console.WriteLine("Add user successfully:");
                            clearScreen();
                        }
                        else
                        {
                            Console.WriteLine("user already exist:");
                            clearScreen();
                        }
                    }
                }
                else if (choice == 3)
                {
                    running = false;
                }

                else if(choice==-1)
                {
                    Console.WriteLine( "invalid input .try again: " );
                }
                else
                {
                    invalid();
                }
                Console.ReadKey();

            }

        }


        /// ////////////////////////////////////////////

            public static int loginMenu()
            {
                int option;
                Console.WriteLine("1. Press 1 for Sign In");
                Console.WriteLine("2. Press 2 for Sign Up");
                Console.WriteLine("3. Press 3 for Exit");
                if(int.TryParse(Console.ReadLine(),out option))
                {
                return option;
            }
                else
            {
                option = -1;
                return option;
            }
               
            }
            static bool readData(string path, List<Users> users)

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
                        Users user = new Users(name, password, role);
                        storeDataInList(user , users);
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
            static void storeDataInList( Users customer, List<Users> Users)
            {
                Users.Add(customer);
            }
            /// ///////////////////////////////////////////
            // take input without role ................ for sign in
            static Users take_Input_without_role()
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter password ");
                string password = Console.ReadLine();
                if (name != null && password != null)
                {
                    Users client = new Users(name, password);
                    return client;

                }
                return null;

            }
            /// ////////////////////////////////////////////////
            // taKe input with role '''''''''''''''''''''' For SignUp

            static Users takeInputWithRole()
            {
                Console.WriteLine("Enter Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();
                Console.WriteLine("Enter Role: ");
                string role = Console.ReadLine();
                if (name != null && password != null && role != null)
                {
                    Users customers = new Users(name, password, role);
                    return customers;
                }
                return null;
            }

            ///...................////
            ///sign in to check validate user..........
            static Users signIn(Users customer, List<Users> Users)
            {

                foreach (Users storedUser in Users)  // for each loop
                {
                    if (customer.Name == storedUser.Name && customer.Password == storedUser.Password)
                    {
                        return storedUser;
                    }
                }
                return null;
            }

            // check for signUp...........
            static bool isCheck(Users users, List<Users> user)
            {
                foreach (Users storeduser in user)
                {
                    if (users.Name == storeduser.Name && users.Password == storeduser.Password && users.Role == storeduser.Role)
                    {
                        return true;
                    }
                    else
                    {
                        return false; ;
                    }
                }
                return false;
            }
            // for sign up 
            // store data in file
            static void storeDataInFile(string path, Users customer)
            {
                StreamWriter file = new StreamWriter(path, true);
                file.WriteLine(customer.Name + "," + customer.Password + "," + customer.Role);
                file.Flush();
                file.Close();
            }
            // .....................
            // clear screen
           static void clearScreen()
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("press any key to continue:");
                Console.WriteLine("-------------------------");
                Console.ReadKey();
                Console.Clear();
            }
        static void invalid()
        {
            Console.WriteLine("Your choice is invalid");
            Console.WriteLine("Plese enter valid option");

        }
    }
    }
