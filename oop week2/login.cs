using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace login
{
    class Program
    {
        class customers
        {
            public string names;
            public string passwords;
            public string role;
        static void Main(string[] args)
        {
            List<customers> s = new List<customers>(); // lists
            customers temp = new customers();         // object
            temp.names = "muskan";
            temp.passwords = "123123";
            temp.role = "admin";
            s.Add(temp);

            string path = "D:\\semester2\\Object Orientated Programing\\week2\\login";

            int option;
            readData(path, s);

            do
            {


                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    int check;

                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();

                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();

                    Console.WriteLine("Enter Role: ");
                    string r = Console.ReadLine();

                    check = signIn(n, p, r, s);
                    if (check == 1)
                    {
                        Console.WriteLine("Admin InterFace");
                    }
                    else if (check == 2)
                    {
                        Console.WriteLine("Client InterFace");
                    }
                    else if (check == 3)
                    {
                        Console.WriteLine(" invalid! User is Not Present");
                    }
                    Console.ReadKey();

                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    Console.WriteLine("Enter role only customers can add: ");
                    string r = Console.ReadLine();
                    signUp(s, path, n, p, r);
                }
            }
            while (option < 3);
        }

        public static void main1()
        {
            string path = "D:\\semester2\\Object Orientated Programing\\week2\\login";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("Not Exists");
            }
        }

        public static int menu()
        {
            int option;
            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());

            return option;
        }

        public static string parseData(string record, int field)
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

        static void readData(string path, List<customers> s)
        {

            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    customers temp = new customers();

                    temp.names = parseData(record, 1);
                    temp.passwords = parseData(record, 2);
                    temp.role = parseData(record, 3);
                    s.Add(temp);
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not Exist");
            }
        }

        static int signIn(string n, string p, string r, List<customers> s)
        {

            if (n == s[0].names && p == s[0].passwords && r == s[0].role)
            {

                return 1;
            }
            for (int x = 1; x < s.Count(); x++)
            {

                if (n == s[x].names && p == s[x].passwords && r == s[x].role)
                {


                    return 2;
                }
            }


            Console.ReadKey();
            return 3;
        }

        public static void signUp(List<customers> s, string path, string n, string p, string r)
        {
            bool userFound = false;
            if (r == "customer")
            {
                for (int i = 1; i < s.Count; i++)
                {
                    if (s[i].names == n && s[i].passwords == p)
                    {
                        Console.WriteLine("user already exists. try different name and password");
                        userFound = true;
                    }
                }
                if (userFound == false)
                {
                    customers cust = new customers();
                    cust.names = n;
                    cust.passwords = p;
                    cust.role = r;
                    s.Add(cust);
                    StreamWriter myFile = new StreamWriter(path, true);
                    myFile.WriteLine(n + "," + p + "," + r);
                    myFile.Flush();
                    myFile.Close();
                    Console.WriteLine("Added");
                }
            }
            else
            {
                Console.WriteLine("There can be only one admin . please signup first.");
            }

            Console.ReadKey();
        }


        }

    }
}
