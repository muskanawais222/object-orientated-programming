using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Game4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string MazePath = "D:\\semester2\\Object Orientated Programing\\week4\\wwek4Game\\maze.txt";
            // coordinates of maze
            char[,] maze = new char[30, 105]; // array 
            loadMaze(ref MazePath, ref maze);

            // game running 
            bool running = true;
            while(running)
            {
                submenu();
                Thread.Sleep(1500);
                Console.Clear();
                logo();
               int option = menu();
                if (option == 1)
                {
                    Console.Clear();
                    // instruction....
                }
                else if(option == 2)
                {
                    Console.Clear();
                    logo();
                    help();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    gameStart(ref maze);
                }
                else if (option == 4)
                {
                    running = exit(running);
                }
                else
                {
                    invalid();
                }
                     
            }

            Console.ReadKey();

        }
        static void printMaze(char[,] maze)
        {
            for(int x = 0; x< maze.GetLength(0); x++)
            {
                for(int y = 0; y <maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();

            }
        }
        static void loadMaze(ref string path , ref char[,] maze)
        {
            StreamReader file = new StreamReader(path);
            string record;
            int row = 0;
            while((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < 121; x++)
                {
                    if(record.Length > x)
                    {
                        maze[row, x] = record[x];
                    }
                }
                row++;
            }
            file.Close();

        }

        static void logo()
        {
            //   blue();
            Console.Clear();
            Console.WriteLine(" **********  ***     ******  **      **      ********** ********  *****    ********     ");
            Console.WriteLine(" **         *   *   *      *  **    **       **            **    *     *   **         ");
            Console.WriteLine(" **        *     *  *       *  **  **        **            **    *      *  **   ");
            Console.WriteLine(" **       *       * *      *    ****         **            **    *     *   **         ");
            Console.WriteLine(" ******** ********* ********     **          ********      **    ******    *******     ");
            Console.WriteLine(" **       *       * *       *    **          **            **    *  **     **      ");
            Console.WriteLine(" **       *       * *        *   **          **            **    *   **    **         ");
            Console.WriteLine(" **       *       * *       *    **          **            **    *    **   **     ");
            Console.WriteLine(" **       *       *  *******     **          **         ******** *     **  *********             "); ;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }
        static void topHeader()
        {
            // yellow();
            Console.WriteLine("         ...                                                                       ");
            Console.WriteLine("       ..   ..                                             <>                          ");
            Console.WriteLine("      .........                                          <><><>                       ");
            Console.WriteLine("         ||  ________+++                                   ||              ::             ");
            Console.WriteLine("         || //'''''''+++'''                 ><      ''''''\\||           :;:::        ");
            Console.WriteLine("         ||//                             >>  <<       :::::::::::         ||          ");
            Console.WriteLine("......................                   >>>><<<<      .. FLUPPY..   '''''\\||          ");
            Console.WriteLine("......................               ''''''\\||           :::::::        -------  ");
            Console.WriteLine(" ..     FABY       ..                      \\||                         \\ BLUEY /     ");
            Console.WriteLine("   ................                     ::::::::::::                    .......    ");
            Console.WriteLine("                                         ..CLOEY ..                         ");
            Console.WriteLine("                                          ::::::::                             ");
            Thread.Sleep(5000);

        }
        //starting functions
        static void submenu()
        {

            Console.Clear();
            Thread.Sleep(2000);
            topHeader();
            Console.WriteLine("                  ");
            Console.WriteLine("-------------------");
            Console.WriteLine("press any key to continue:");
            Console.ReadKey();
            Console.Clear();
            logo();
            Console.WriteLine("                  ");
            Console.WriteLine("-------------------");
            Console.WriteLine("Loading 30%");
            Thread.Sleep(1000);
            Console.Clear();
            logo();
            Console.WriteLine("                  ");
            Console.WriteLine("-------------------");
            Console.WriteLine("Loading 90%");
            Thread.Sleep(1000);
            Console.Clear();
            logo();
            Console.WriteLine("                  ");
            Console.WriteLine("-------------------");
            Console.WriteLine("Loading complete");
            Thread.Sleep(1000);

        }

        static void help()
        {
            Console.Clear();
            Console.WriteLine("Here are the following instructions to play the game : ");
            Console.WriteLine();
            Console.WriteLine("1. Use up arrow key to move the character upward. ");
            Console.WriteLine();
            Console.WriteLine("2. Use down arrow key to move the character downward. "); ;
            Console.WriteLine();
            Console.WriteLine("3. Use right arrow key to move the character right. "); ;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("4. Use left arrow key to move the character left. "); ;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("5. Use space bar to fire your enemies. ");
            Console.WriteLine("If you touch any of the enemies the game will be over. ");
            Console.WriteLine();
        }

        static int menu()
        {
            int option;
            Console.WriteLine();
            Console.WriteLine("Press 1 for instructions..");
            Console.WriteLine("Press 2 for Help..");
            Console.WriteLine("Press 3 for Starting Game..");
            Console.WriteLine("Press 4 for Exit");
            Console.Write("Enter your choice : ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        // exit
        static bool exit(bool run)
        {
            Console.WriteLine("You exit the prOgram");
            Console.WriteLine("Thanks for using");
            run = false;
            return run;

        }
        // invalid 
        static void invalid()
        {
            Console.WriteLine("Your choice is invalid");
            Console.WriteLine("Plese enter valid option");

        }
        public static void gameStart(ref char [,] maze)
        {
            printMaze(maze);

        }
    }
}
