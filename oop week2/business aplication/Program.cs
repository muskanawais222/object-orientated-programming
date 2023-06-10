using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using business_application_week2.BL;
using System.IO;
using business_application_week2;

namespace business_application_week2
{
    class Program
    {

        static void Main(string[] args)
        {
            rooms room1 = new rooms(); // object
            List<customers> s = new List<customers>(); // lists
            customers temp = new customers();         // object
            List<rooms> room = new List<rooms>(); //list
            // room file path
          string pathRoom = "D:\\semester2\\Object Orientated Programing\\week2\\pd2\\Business Application\\roomFile.txt";

            temp.names = "muskan";
            temp.passwords = "123123";
            temp.role = "admin";
            s.Add(temp);

            string path = "D:\\semester2\\Object Orientated Programing\\week2\\pd2\\Business Application\\customerFile.txt";

            int option;

            do
            {
                readData(path, s);
                loadData(pathRoom, room);
                Console.Clear();
                option = loginMenu();
                Console.Clear();
                if (option == 1)
                {
                    Console.Clear();
                    topHeader();
                    subMenuBeforeMainMenu("login Menu");
                    string check;

                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();

                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();

                    string r;

                    check = signIn(n, p, s);
                    if (check == "admin" || check == "Admin")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Signed in suceesfully");
                        Console.WriteLine("Admin InterFace");
                        Console.Clear();
                        adminInterface(room , pathRoom);
                    }
                    else if (check == "customer" || check == "customer" || check == "client" || check == "Client")
                    {
                        Console.WriteLine();
                        Console.WriteLine("signed in successfully");

                        Console.WriteLine("Client InterFace");
                        Console.Clear();
                        userInterface();
                    }
                    else
                    {
                        Console.WriteLine(" invalid! User is Not Present");
                        Console.WriteLine();
                        Console.WriteLine("please ! signUp first...");
                    }
                    Console.ReadKey();

                }
                else if (option == 2)
                {
                    Console.Clear();
                    topHeader();
                    subMenuBeforeMainMenu("Sign Up");
                    Console.WriteLine("Enter Name: ");
                    string name_of_user = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string password_of_user = Console.ReadLine();
                    Console.WriteLine("Enter New Role(only add customer): ");
                    string role = Console.ReadLine();

                    signUp(s, path, name_of_user , password_of_user , role);
                }
                else if (option == 3)
                {
                    viewCredentials(s);
                }
            }
            while (option < 4);
        }

        public static void main1()
        {
            string path = "D:\\semester2\\Object Orientated Programing\\week2\\pd2\\Business Application\\customerFile.txt";
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

        public static int loginMenu()
        {
            int option;
            Console.WriteLine("1. Sign in");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("3. View Users");
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
        // read data for customer
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
        // read or load data for rooms
        static void loadData(string pathRoom, List<rooms> room)
        {

            if (File.Exists(pathRoom))
            {
                StreamReader myFile = new StreamReader(pathRoom);
                string record;
                while ((record = myFile.ReadLine()) != null)
                {
                    rooms temp = new rooms();

                    temp.roomNo =int.Parse( getData(record, 1));
                    temp.roomId =int.Parse( getData(record, 2));
                    room.Add(temp);
                }
                myFile.Close();
            }
            else
            {
                Console.WriteLine("File not Exist");
            }
        }
        public static string getData(string record, int field)
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


        static string signIn(string n, string p,  List<customers> s)
        {

            string role_user;
            for (int x = 0; x < s.Count; x++)
            {
                if (s[x].names == n && s[x].passwords == p)
                {
                    role_user = s[x].role;
                    return role_user;
                }
            }
            return "user not found ";
        }

        public static void signUp(List<customers> s, string path, string name_of_user, string password_of_user, string role = "customers")
        {
            bool isFound = check(name_of_user,password_of_user,s);
            if (role == "customer" || role == "customer")
            {
                if(isFound == false)
                {
                    s.Add(takeInput(name_of_user, password_of_user, role));
                    save_user_data(path, name_of_user, password_of_user, role);
                    Console.WriteLine("Add user successfully:");
                    console_Function();
                }
              else
                {
                    Console.WriteLine("user already exist:");
                    Console.WriteLine("TRy! different name and password");
                    console_Function();
                }
            }
            else 
            {
                Console.WriteLine("There can be only one admin . please signup first.");
            }

            Console.ReadKey();
        }
        //view credentials##########################################
        public static void viewCredentials(List<customers> s)
        {
            Console.WriteLine("User Names          roles");

            for (int i = 0; i < s.Count() ; i++)
            {
                Console.WriteLine(s[i].names + "\t\t" + s[i].role);
            }
            console_Function();
        }
        // admin menu
        static int adminMenu()
        {
            int choice;
            Console.WriteLine("1 . Add user.");
            Console.WriteLine("2 . Reservation .");
            Console.WriteLine("3 . Customer management .");
            Console.WriteLine("4 . Room rates .");
            Console.WriteLine("5 . Employee management .");
            Console.WriteLine("6 . inventory management .");
            Console.WriteLine("7 . Reporting .");
            Console.WriteLine("8 . Security .");
            Console.WriteLine("9 . Room information .");
            Console.WriteLine("10. return back");
            Console.WriteLine("Enter your Choice : ");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void adminInterface(List<rooms> room , string pathRoom)
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
                    subMenu("Room management");
                    roomManagement();


                }
                else if (adminOption == 2)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Reservation of room");
                    // Reservation of rooms
                        int roomNo, roomId;
                    Console.WriteLine("Enter following intputs for check wheather room  already exist or not:");
                    Console.WriteLine("Enter the rooms that are reserved :");
                        roomNo = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the roomsID : ");
                        roomId = int.Parse(Console.ReadLine());

                        bool isAvailable = checkRoom(pathRoom , roomNo , room);
                        if (isAvailable)
                        {
                           room.Add(addRooms(roomNo, roomId));
                            storeRoom(pathRoom ,roomNo , roomId , room);

                            Console.WriteLine("Room is available. Room addaed sucessfully");
                            Console.Clear();

                        }
                        if (!isAvailable)
                        {
                            Console.WriteLine("Sorry, Room already reserved try another room .");
                            Console.Clear();

                        }
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
                    reporting(room);
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
        // top header//////
        public static void topHeader()
        {
            Console.WriteLine("*******************************");
            Console.WriteLine("******    WELCOME TO     ******");
            Console.WriteLine("**  HOTEL MANAGEMENT SYSTEM  **");
            Console.WriteLine("*******************************");
        }
        ///  sub menu before main menu
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
                  //  roomBooking();
                }
                else if (userOption == 2)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of payment");
                  //  payment();
                }
                else if (userOption == 3)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of customer profile");
                  //  custProfile();
                }
                else if (userOption == 4)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("View Details of room management");
                   // roomDisplay();
                }
                else if (userOption == 5)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("feed back");
                   // feedback();
                }
                else if (userOption == 6)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("Communication");
                   // communication();
                }
                else if (userOption == 7)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("mobile access");
                  //  mobileAccess();
                }
                else if (userOption == 8)
                {
                    Console.Clear();
                    topHeader();
                    subMenu("personalized experiance");
                  //  experiance();
                }
                else if (userOption == 9)
                {
                    Console.Clear();
                    loginMenu();
                }
                Console.Clear();
            }
        }
        // take input
        public static customers takeInput(string names, string passwords, string roll)
        {
            customers s1 = new customers();
            s1.names = names;
            s1.passwords = passwords;
            s1.role = roll;
            return s1;

        }
        // user data save in file
       public static void save_user_data(string path,string name,string password,string role)
        {
            StreamWriter file = new StreamWriter(path, true);

            file.WriteLine(name + "," + password + "," + role);

            file.Flush();
            file.Close();
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
   
        // checkavailabilty of rooms
        public static void storeRoom( string pathRoom , int roomNo ,int roomId, List<rooms> room)
        {
            StreamWriter roomfile = new StreamWriter(pathRoom, true);
            roomfile.WriteLine();
            roomfile.WriteLine(roomNo + "," + roomId );
            roomfile.Flush();
            roomfile.Close();

        }
        public static rooms addRooms( int roomNo , int roomId)
        {
            rooms r1 = new rooms();
            r1.roomNo = roomNo;
            r1.roomId = roomId;
            return r1;
        }
        // check room
        static bool checkRoom( string pathRoom ,int roomNo , List<rooms> room)
        {
            bool isPresent = false;
            for (int i = 0; i < room.Count(); i++)
            {
                if (room[i].roomNo == roomNo)
                {
                    isPresent = true;
                    break;
                }
            }
            if (isPresent == true)
            {

                Console.WriteLine("Room already present .");
                Console.ReadKey();
                return false;
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
        //CRUD FUNCTIONS FOR USER
        //> CHECK FUNCTION WHEATHER USER IS EXIST  ALREADY OR NOT 
        public static bool check(string name_of_user, string password_of_user, List<customers> s)
        {

            for (int x = 0; x < s.Count; x++)
            {
                if (s[x].names == name_of_user && s[x].passwords == password_of_user)
                {
                    return true;
                }
            }
            return false;
        }
        // reporting
        public static void reporting(List<rooms> room)
        {
            string report;
            Console.WriteLine("Enter a day report >");
            report = (Console.ReadLine()); ;
            for (int i = 0; i < room.Count(); i++)
            {
                Console.WriteLine(room[i].feedback);
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
        // function for stop console
        public static void console_Function()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("press any key to continue:");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
