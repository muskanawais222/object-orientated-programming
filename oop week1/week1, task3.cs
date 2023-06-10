using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project3
{
    class Program
    {
        static void Main(string[] args)
        {
            // task01();
            //task02();
            // task03();
          mainFunction();

        }
        // task 1
        static void task01()
        {
            int num1, num2;
            Console.Write("Enter first number: ");
            num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter second  number: ");
            num2 = int.Parse(Console.ReadLine());
            int result = add(num1, num2);
            Console.WriteLine("Sum is {0} ", result);
            Console.Read();

        }
        
        static int add(int n1, int n2)
        {
            return n1 + n2;
        }
        //task2
        static void task02()
        {
            string path = "D:/semester2/Object Orientated Programing/projectFile.txt.txt";
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
            Console.ReadKey();

        }
        //task3
        static void task03()
        {
            string path = "D:/semester2/Object Orientated Programing/projectFile.txt.txt";
            StreamWriter fileVariable = new StreamWriter(path, true);
            fileVariable.WriteLine("Hello!");
            fileVariable.WriteLine("Hello!");

            fileVariable.Flush();
            fileVariable.Close();
            Console.Read();

        }
        //signin menu """"""""""""""""""""""""""""""
        static void mainFunction()
        {
            string path = "D:\\semester2\\Object Orientated Programing\\week1\\project3\\newfile.txt";
            string[] names = new string[6];
            string[] password = new string[6];
            int option;
            do
            {
                readData(path, names, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter password : ");
                    string p = Console.ReadLine();
                    signIn(n, p, names, password);
                }
                else if (option == 2)
                {

                    Console.WriteLine("Enter New Name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password : ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);

                }
            }

            while (option < 3);
            Console.Read();


        }
        // the mENU """"""""""""""""""""""""""""""""
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter option");
            option = int.Parse(Console.ReadLine());
            return option;

        }
        // read data from file """""""""""""""""""""""""""""" getfield
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
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


        static void readData(string path, string[] names, string[] password)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    password[x] = parseData(record, 2);
                    x++;
                    if (x <= 6)
                    {
                        break;
                    }
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }


        }
        // sign in function """""""""""""""""""""""""""""""""""""
        static void signIn(string n, string p, string[] names, string[] password)
        {
            bool flag = false;
            for (int x = 0; x < 6; x++)
            {
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }

            }
            if (flag == false)
            {
                Console.WriteLine("Invalid user");
            }
            Console.ReadKey();
        }
        // signup function """"""""""""""""""""""""""""""""""""""""write data
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        //#########################################################################################################
        public static void Task19()
        {
            bool Running = true;
            bool IsValid = true;
            string[] Users = new string[5];
            string[] Codes = new string[5];
            int Counter = 0;
            while (Running)
            {
                string Choice;
                Choice = MainMenu();
                if (Choice == "1")
                {
                    LogIn();
                }
                else if (Choice == "2")
                {
                    SignUp();
                }
                else if (Choice == "3")
                {
                    Exit();
                }
                else
                {
                    Console.Write("Invalid Choice");
                }
                Console.ReadKey();
            }
            string MainMenu()
            {
                Console.Clear();
                string Choice;
                Console.WriteLine("             Welcome to Black Hole");
                Console.WriteLine("                  1. LogIn");
                Console.WriteLine("                  2. SignUp");
                Console.WriteLine("                  3. Exit");
                Console.Write("                  Enter your choice : ");
                Choice = Console.ReadLine();
                return Choice;
            }
            void LogIn()
            {
                Console.Clear();
                string Username;
                string Password;
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("               Enter Username : ");
                Username = Console.ReadLine();
                UsernameValidator(Username);
                if (IsValid == false)
                {
                    Console.Write("               Enter Password : ");
                    Password = Console.ReadLine();
                    PasswordValidator(Password);
                    if (IsValid == true)
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("               Congratulations!!! You have logged in.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("               Invalid Password.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.Write("                   Invalid User ID.");
                }
            }
            void SignUp()
            {
                Console.Clear();
                string Username;
                Console.WriteLine("Example : wa***.com");
                Console.WriteLine();
                Console.Write("               Enter Username : ");
                Username = Console.ReadLine();
                UsernameValidator(Username);
                if (IsValid == true)
                {
                    Users[Counter] = Username;
                    Console.Write("               Enter Password : ");
                    Codes[Counter] = Console.ReadLine();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("               User Already Exists.");
                }
            }
            void UsernameValidator(string Username)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Users[i] == Username)
                    {
                        IsValid = false;
                        break;
                    }
                    else
                    {
                        IsValid = true;
                    }
                }
            }
            void PasswordValidator(string Password)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (Codes[i] == Password)
                    {
                        IsValid = true;
                        break;
                    }
                    else
                    {
                        IsValid = false;
                    }
                }
            }
            void Exit()
            {
                Running = false;
            }
        }

    }
}
