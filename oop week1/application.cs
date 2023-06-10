using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace application
{
    class Program
    {
        const int userArraySize = 100;
        string[] userNames = new string[100];
        string[] passwords = new string[100];
        string[] roles = new string[100];
        static string[] room_Ac = new string[50];
        static string[] roomTYpe = new string[50];
        static string[] room_Size = new string[50];
        static int feedBackCount = 0;
        static int[] room_rent = new int[50];
        static int[] roomNumbers = new int[50];
        static int count = 0;
        static int Countroom = 0;
        static int roomCount = 0;
        static string[] feedBack = new string[50];
        const int user_ArraySize = 100;
        static void Main(string[] args)
        {
            mainFunction();
             adminMenu();
            //  adminInterface();
            mainFunction();
        }
        public static void mainFunction()
        {
            int userCount = 0;
            string[] names = new string[50];
            string[] password = new string[50];
            string[] roles = new string[50];
            topHeader();
            subMenuBeforeMainMenu("Login Menu");
            string path = "D:\\semester2\\Object Orientated Programing\\week1\\pd1\\application..txt";

            int loginOption;
            do
            {
                readData(path, names, password);
                Console.Clear();
                loginOption = loginMenu();
                Console.Clear();
                if (loginOption == 1)
                {
                    Console.Clear();
                    topHeader();
                    subMenuBeforeMainMenu("Login Menu");
                    Console.WriteLine("Enter name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter password : ");
                    string p = Console.ReadLine();
                    string role;
                    role = signIn(n, p, names, password, roles, userCount);
                    if (role == "admin")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Signed In Successfully.");
                        Console.Clear();
                        adminInterface();
                    }
                    else if (role == "user")
                    {

                        Console.WriteLine();
                        Console.WriteLine("Signed In Successfully.");
                        Console.Clear();
                        userInterface();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Credentials Not Found, Kindly Sign Up First.");
                        Console.Clear();
                    }
                }
                else if (loginOption == 2)
                {
                    Console.Clear();
                    topHeader();
                    subMenuBeforeMainMenu("Sign Up");
                    Console.WriteLine("Enter New Name : ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password : ");
                    string p = Console.ReadLine();
                    string role = signUp(n, p, names, password, roles, userCount);
                    {
                        addCredentials(n, p, "user", names, password, roles, ref userCount);
                        storeCredentials(path, names, password, "user", userCount);
                        Console.WriteLine();

                        Console.WriteLine("Congratulations, Signed Up Successfully.");
                    }
                    Console.Clear();


                }
                else if (loginOption == 3)
                {

                    viewCredentials(ref names, ref password, ref roles, ref userCount);
                    Console.Read();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Thaks for using this application");
                    Console.WriteLine();
                    Console.ReadKey();
                }

            }

            while (loginOption < 5);
            Console.Read();


        }
        // the loginMenu """"""""""""""""""""""""""""""""
        static int loginMenu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. TO View all credentials");
            Console.WriteLine("4. To Exit");
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


        public static void readData(string path, string[] names, string[] password)
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
                    if (x >= 6)
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
        static string signIn(string n, string p, string[] names, string[] password, string[] roles, int userCount)
        {
            for (int x = 0; x < userCount; x++)
            {
                if (n == names[x] && p == password[x])
                {
                    Console.WriteLine("Valid User");
                    return roles[x];
                }

            }
            return "Invalid user";
        }

        // signup function """"""""""""""""""""""""""""""""""""""""write data
        static string signUp(string n, string p, string[] names, string[] passwords, string[] role, int userCount)
        {
            string user_role;
            for (int i = 0; i < userCount; i++)
            {
                if (names[i] == n && passwords[i] == p)
                {
                    user_role = role[i];
                    return user_role;
                }
            }
            return "Sorry, Credentials Already Exists Try Different Username.";

        }
        // add credentials
        public static void addCredentials(string n, string p, string role, string[] names, string[] password, string[] roles, ref int userCount)
        {
            if (role == "user")
            {
                if (userCount < 50)
                {
                    names[userCount] = n;
                    password[userCount] = p;
                    roles[userCount] = role;
                    userCount = userCount + 1;
                }
                else
                {
                    clearScreen();
                    Console.WriteLine("User Limit Exceeded.");
                }
            }
            else
            {
                clearScreen();
                Console.WriteLine("Invalid User type");
            }
        }

        // store credentials
        public static void storeCredentials(string path, string[] names, string[] password, string roles, int userCount)
        {
            StreamWriter file = new StreamWriter(path, true);
            for (int x = 0; x < userCount; x++)
            {
                file.WriteLine(names[x] + "," + password[x] + "," + roles[x]);
            }
            file.Flush();
            file.Close();
        }
        //view credentials##########################################
        public static void viewCredentials(ref string[] names, ref string[] password, ref string[] roles, ref int userCount)
        {
            Console.WriteLine("User Names          passwords          roles");

            for (int i = 0; i < userCount; i++)
            {
                Console.WriteLine(names[i] + "                    " + password[i] + "       " + roles[i]);
            }
        }
        //////////////////////////////Top header////////////
        public static void topHeader()
        {
            Console.WriteLine("******");
            Console.WriteLine("*     WELCOME TO     ***");
            Console.WriteLine("*  HOTEL MANAGEMENT SYSTEM   *");
            Console.WriteLine("******");
        }
        // submenu before main menu
        public static void subMenuBeforeMainMenu(string submenu)
        {
            string message = submenu + "Menu";
            Console.WriteLine(message);
            Console.WriteLine("------------------------");
        }
        // sub menu
        public static void subMenu(string submenu)
        {
            string message = "Main menu  > " + submenu;
            Console.WriteLine(message);
            Console.WriteLine("------------------------");
        }
        // admin menu
        static int adminMenu()
        {
            int choice;
            Console.WriteLine("1 . Room management .");
            Console.WriteLine("2 . Reservation .");
            Console.WriteLine("3 . Customer management .");
            Console.WriteLine("4 . Room rates .");
            //Console.WriteLine("5 . Employee management .");
            Console.WriteLine("6 . inventory management .");
            Console.WriteLine("7 . Reporting .");
            Console.WriteLine("8 . Security .");
            Console.WriteLine("9 . Room information .");
            Console.WriteLine("10. return back");
            Console.WriteLine("Enter your Choice : ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        ///////////////////////////////////////////////////////////////////
        ///admin interface////////////
        public static void adminInterface()
        {
            int adminOption = -1;
            while (adminOption != 10)
            {
                topHeader();
                subMenu("Admin menu");
                adminOption = adminMenu();
                if (adminOption == 1)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("room management");
                    roomManagement();
                }
                else if (adminOption == 2)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Reservation of room");
                    //reservation();
                }
                else if (adminOption == 3)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Customer management");
                     customermanagement();
                }
                else if (adminOption == 4)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("room rates");
                     roomRates();
                }
                else if (adminOption == 5)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("employee management");
                     employeeManagement();
                }
                else if (adminOption == 6)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("inventory management");
                      stockManagement();
                }
                else if (adminOption == 7)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Reporting");
                      reporting();
                }
                else if (adminOption == 8)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("security");
                     security();
                }
                else if (adminOption == 9)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Room Information");
                     roomInformation();
                }
                else if (adminOption == 10)
                {
                    Console.Clear();
                    loginMenu();
                }

                Console.Clear();
            }
        }
        // room management in admin interface
        public static void roomManagement()
        {
            int totalRooms, reservedRooms, searchRoom, checkin, checkout;
            Console.WriteLine("Add total no of rooms :");
            totalRooms = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter no of rooms that are reserved :");
            reservedRooms = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter no of room that want to search:");
            searchRoom = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the rooms that are checked in :");
            checkin = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the rooms that are check out :");
            checkout = int.Parse(Console.ReadLine());
        }
        // Reservation of rooms
        public static void reservation()
        {
            int roomNo;
            Console.WriteLine("Enter the rooms that are reserved :");
            roomNo = int.Parse(Console.ReadLine());
            bool isAvailable = checkRoom(roomNo);
            if (isAvailable)
            {
                addRooms(roomNo);
                storeRoom(roomNo);

                Console.WriteLine("Room is available.");
                Console.Clear();

            }
            if (!isAvailable)
            {
                Console.WriteLine("Sorry, Room already reserved try another room .");
                Console.Clear();

            }
        }
        // checkavailabilty of rooms
        public static void storeRoom(int roomNo)
        {
            string path = "D:\\semester2\\Object Orientated Programing\\week1\\pd1\\roomfile.txt";
            StreamWriter roomfile = new StreamWriter(path, false);
            roomfile.WriteLine();
            for (int x = 0; x < roomCount; x++)
                roomfile.WriteLine(roomNo);
            roomfile.Flush();
            roomfile.Close();

        }
        public static void addRooms(int roomNo)
        {
            roomNumbers[roomCount] = roomNo;
            roomCount++;
        }
        // check room
        static bool checkRoom(int roomNo)
        {
            bool isPresent = false;
            for (int i = 0; i < roomCount; i++)
            {
                if (roomNumbers[i] == roomNo)
                {
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == true)
            {

                Console.WriteLine("User already present .");
                Console.ReadKey();
                return false;
            }
            else if (roomCount < userArraySize)
            {
                return true;
            }

            return false;

        }
        ///////////////////////////////////////
        // customer management
        public static void customermanagement()
        {
            string custName;
            int custRoom, custPhone;
            Console.WriteLine("Enter customer name>");
            custName = Console.ReadLine();
            Console.WriteLine("Enter customer room>");
            custRoom = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter customer Phone Number");
            custPhone = int.Parse(Console.ReadLine());
        }
        // room rates
        public static void roomRates()
        {
            int standardRate, luxuaryRate, deluxRate, swietRoom;
            Console.WriteLine("Enter the rates of Stanadard room>");
            standardRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the rates of luxuary room> ");
            luxuaryRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter teh rates of Delux room>");
            deluxRate = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the rate of swiet room>");
            swietRoom = int.Parse(Console.ReadLine());
        }
        // store rates
        public static void storerates(int SwietRoom, int standardRate, int luxuaryRate, int deluxRate)
        {
            string path = "D:\\semester2\\Object Orientated Programing\\week1\\pd1\\roomfile.txt";
            StreamWriter roomfile = new StreamWriter(path, false);
            roomfile.WriteLine();
            roomfile.WriteLine(SwietRoom);
            roomfile.WriteLine(standardRate);
            roomfile.WriteLine(luxuaryRate);
            roomfile.WriteLine(deluxRate);

            roomfile.Flush();
            roomfile.Close();


        }
        // view rooms
        public static void viewRooms(ref int roomCount, int[] roomNumbers)
        {
            Console.WriteLine();
            Console.WriteLine(" rooms");
            for (int x = 0; x < roomCount; x++)
            {
                Console.WriteLine(roomNumbers[x]);
            }
        }
        // employee management;
        public static void employeeManagement()
        {
            Console.WriteLine("1 . Employeee(Ahmad) has to clean the room ");
            Console.WriteLine();
            Console.WriteLine("2 . Employee(Ali) has to dusting the rooms");
            Console.WriteLine();

            Console.WriteLine("3 . Employee(Bilal) has to clean rooms from 30 to 49");
            Console.WriteLine();

            Console.WriteLine("4 . Employee(Raza) has to clean and manage AC ");
            Console.WriteLine();

            Console.WriteLine("5 . Employee(Faisal) has to clean balconies");
            Console.WriteLine();

            Console.WriteLine("6 . Employee(Umar) has to manage electricty issues");
            Console.WriteLine();

            Console.WriteLine("7 . Employee(Hassan) has to check furniture");
            Console.WriteLine();

        }
        // stock management
        public static void stockManagement()
        {
            int bed, newBed, sofa, lamps, newlamps;
            string stock;
            Console.WriteLine("Enter no of beds that are available ");
            bed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter no of new beds that are just coming ");
            newBed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter no of sofa sets ");
            sofa = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter lamps that are available ");
            lamps = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter no of new lamps that are ordered ");
            newlamps = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter available stock (bed, lamps, sofa , matreses) ");
            stock = (Console.ReadLine());
        }
        // reporting
        public static void reporting()
        {
            string report;
            Console.WriteLine("Enter a day report >");
            report = (Console.ReadLine()); ;
            for (int i = 0; i < feedBackCount; i++)
            {
                Console.WriteLine(feedBack[i]);
            }

        }
        // security
        public static void security()
        {
            int rooms, roomNo;
            Console.WriteLine("Enter the no of rooms that need security :");
            rooms = int.Parse(Console.ReadLine()); ;
            Console.WriteLine("Enter the room no who have privacy issue and need security :");
            roomNo = int.Parse(Console.ReadLine()); ;
            Console.WriteLine("security reaches to that room ");
        }
        // room info
        public static void roomInformation()
        {
            Console.WriteLine(":> There are 50 rooms .");
            Console.WriteLine(":> The luxuary rooms are 10.");
            Console.WriteLine(":> sweit rooms are about 15.");
            Console.WriteLine(":> There are 15 delux rooms.");
            Console.WriteLine(":> There are 10 standard rooms.");
        }
        // user interface
        public static void userInterface()
        {
            int userOption = 0;
            while (userOption != 10)
            {
                topHeader();
                subMenu("User interface");
                userOption = userMenu();
                if (userOption == 1)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of booking room");
                    roomBooking();
                }
                else if (userOption == 2)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of payment");
                    payment();
                }
                else if (userOption == 3)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of customer profile");
                    custProfile();
                }
                else if (userOption == 4)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of room management");
                    roomDisplay();
                }
                else if (userOption == 5)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("feed back");
                    feedback();
                }
                else if (userOption == 6)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Communication");
                    communication();
                }
                else if (userOption == 7)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("mobile access");
                    mobileAccess();
                }
                else if (userOption == 8)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("personalized experiance");
                    experiance();
                }
                else if (userOption == 9)
                {
                    Console.Clear();
                    loginMenu();
                }
                Console.Clear();
            }
        }
        // user menu
        static int userMenu()
        {
            int choice;
            Console.WriteLine("1. Room booking. ");
            Console.WriteLine("2. Payment. ");
            Console.WriteLine("3. Customer profile . ");
            Console.WriteLine("4. Room management .");
            Console.WriteLine("5. Feedback .");
            Console.WriteLine("6. Communication .");
            Console.WriteLine("7. Mobile access .");
            Console.WriteLine("8. Personalized experiance .");
            Console.WriteLine("9. return back");
            Console.WriteLine("Enter your Choice : ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }


        public static void roomBooking() // room booking
        {
            string roomAc, roomType, roomStype, roomRent;
            Console.WriteLine("\nType AC/Non-AC (A/N) : ");
            roomAc = (Console.ReadLine());
            Console.WriteLine("\nType Comfort (S/N) : ");
            roomType = (Console.ReadLine());
            Console.WriteLine("\nType Size (B/S) : ");
            roomStype = Console.ReadLine();
            Console.WriteLine("\nDaily Rent : ");
            roomRent = (Console.ReadLine()); ;
            roomTYpe[Countroom] = roomType;
            room_rent[Countroom] = int.Parse(roomRent);
            room_Size[Countroom] = roomStype;
            room_Ac[Countroom] = roomAc;
            Countroom++;

            Console.WriteLine("\n Room Added Successfully!");
        }

        public static void payment() // payment
        {
            int option;
            Console.WriteLine("1.Delux room rate = 4500");
            Console.WriteLine("2.Luxury room rate = 5000");
            Console.WriteLine("3.Swiet room rate = 5500");
            Console.WriteLine("4.Standard room rate = 4000");
            Console.WriteLine(":> Enter your choice :");
            option = int.Parse(Console.ReadLine()); ;
        }
        public static void custProfile() // customer profile
        {
            string name;
            Console.WriteLine("Enter your name:");
            name = (Console.ReadLine()); ;
            Console.WriteLine("Your password is ");
            Console.WriteLine("you have booked room ");
        }

        public static void roomDisplay()
        {
            int roomNo;
            int totalRooms;
            Console.WriteLine("Add total no of rooms :");
            totalRooms = int.Parse(Console.ReadLine()); ;
            Console.WriteLine("Enter the rooms that are reserved :");
            roomNo = int.Parse(Console.ReadLine()); ;
            bool isAvailable = checkRoom(roomNo);
            if (isAvailable)
            {
                addRooms(roomNo);
                storeRoom(roomNo);

                Console.WriteLine();

                Console.WriteLine("Room is available.");
                Console.Clear();

            }
            if (!isAvailable)
            {
                Console.WriteLine();

                Console.WriteLine("Sorry, Room already reserved try another room .");
                Console.Clear();
            }
        }
        public static void feedback()
        {
            string one, two;
            Console.WriteLine(":> Do you like our rooms ");
            one = (Console.ReadLine()); ;
            Console.WriteLine(":> Do you like our service ");
            two = Console.ReadLine(); ;
            Console.WriteLine(":> Add your review: ");
            //  feedBack[feedBackCount];
            //feedBackCount++;
            Console.WriteLine("Thank you for your feed up");
        }
        public static void communication()
        {
            Console.WriteLine("To communicate call at this number : ");
            Console.WriteLine("+923433453443");
        }
        public static void mobileAccess()
        {
            Console.WriteLine("If you need mobile access :");
            Console.WriteLine("Turn on your wifi and connect with the code (oiuyt) !");
            Console.WriteLine("Call us at (9876354) for any help ");
            Console.WriteLine("Call us at (456654) for room service");
        }
        public static void experiance()
        {
            string experiance;
            Console.WriteLine("Add your experiance and feed back ");
            experiance = (Console.ReadLine());
        }
        // clear screen
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
