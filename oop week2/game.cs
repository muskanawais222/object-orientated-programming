using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using gameWeek2.BL;
using EZInput;

namespace gameWeek2
{
    class Program
    {
        static void Main(string[] args)
        {
            // maze path
            string path = "D:\\semester2\\Object Orientated Programing\\week2\\pd2\\gameWithClasses\\gameWeek2\\Maze.txt";            // players / faby object.......
          
            //player object
            faby faby1 = new faby();
            faby1.xPos = 3;
            faby1.yPos = 3;

            // enemy object......
            enemy1 enemy = new enemy1();
            enemy.enemyX_pos =25;
            enemy.enemyY_pos = 25;

            // bullets object.....
            bullet[] firing = new bullet[500];
            int bulletCount = 0;

            //maze coordinates
            char[,] maze = new char[34, 121];
            loadMaze(ref path, ref maze);
            printMaze(maze);

            // characters of player to print player
            char char178 = (char)178; // Use an ASCII character that represents the 'box' symbol
            char char219 = (char)219; // Use an ASCII character that represents the filled rectangle symbol
            char[,] player = {
                { ' ', '_', '_', ' '},
                { '(', char178, char178, ')'},
                { '/', char219, char219, '\\'},
                { ' ', '|', '|', ' '}
            };

            // print player
            printFaby(ref maze, ref player, ref faby1);

            // character of enemy to print enemy
            string enemyDirection = "up";
            char boy = (char)254; // Use an ASCII character that represents the 'box' symbol
            char[,] bluey = {
            {' ', ' ', ' ', '^', ' ', ' '},
                     {'<', '=', '(', '^', ')', ' '},
                     {' ', ' ', '@', '@', '@', ' '},
                     {' ', boy, boy, boy, boy, boy}
            };
            // print enemy
            printEnemy(ref maze, ref bluey, ref enemy);

            // for playing game
            while(true)
            {
                Thread.Sleep(100);
                if (Keyboard.IsKeyPressed(Key.Space))
                {
                    generatebullet(ref firing, ref faby1, ref bulletCount, ref maze);
                }
                if (Keyboard.IsKeyPressed(Key.LeftArrow))
                {
                    moveFabyLeft(ref maze, ref player, ref faby1);
                }
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    moveFabyUp(ref maze, ref player, ref faby1);
                }
                if (Keyboard.IsKeyPressed(Key.RightArrow))
                {
                    moveFabyRight(ref maze, ref player, ref faby1);
                }
            
               if (Keyboard.IsKeyPressed(Key.DownArrow))
               {
                moveFabyDown(ref maze, ref player, ref faby1);
                }
                moveEnemy(ref enemyDirection, ref maze, ref bluey, ref enemy);
                movebullet(ref maze, ref firing, ref bulletCount);
            }
            Console.ReadKey();


        }



        // print Maze
        static void printMaze(char[,] maze)
        {
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }

        // load maze from file
        static void loadMaze(ref string path, ref char[,] maze)
        {
            StreamReader file = new StreamReader(path);
            string record;
            int row = 0;

            while ((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < 121; x++)
                {
                    if (record.Length > x)
                    {
                        maze[row, x] = record[x];
                    }
                }
                row++;
            }

            file.Close();
        }
        // print player / faby
        public static void printFaby(ref char[,] maze, ref char[,] player, ref faby faby1)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.SetCursorPosition(faby1.yPos + col, faby1.xPos + row);
                    Console.Write(player[row, col]);
                    maze[row + faby1.xPos, col + faby1.yPos] = player[row, col];
                }
            }

        }
        // print enemy
        public static void printEnemy(ref char[,] maze, ref char[,] bluey, ref  enemy1 enemy)
        {
            for (int row = 0; row < bluey.GetLength(0); row++)
            {
                for (int col = 0; col < bluey.GetLength(1); col++)
                {
                    Console.SetCursorPosition(enemy.enemyY_pos + col, enemy.enemyX_pos + row);
                    Console.Write(bluey[row, col]);
                    maze[row + enemy.enemyX_pos, col + enemy.enemyY_pos] = bluey[row, col];
                }
            }
        }
        // erase player / faby
        public static void erase_Player(ref char[,] maze, ref char[,] player, ref faby faby1)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.SetCursorPosition(faby1.yPos + col, faby1.xPos + row);
                    Console.Write(" ");
                    maze[row + faby1.xPos, col + faby1.yPos] = ' ';
                }
            }
        }
        //erase enemy
        public static void erase_enemy(ref char[,] maze, ref char[,] bluey, ref enemy1 enemy)
        {
            for (int row = 0; row < bluey.GetLength(0); row++)
            {
                for (int col = 0; col < bluey.GetLength(1); col++)
                {
                    Console.SetCursorPosition(enemy.enemyY_pos + col, enemy.enemyX_pos + row);
                    Console.Write(" ");
                    maze[row + enemy.enemyX_pos, col + enemy.enemyY_pos] = ' ';
                }
            }
        }
        static void moveEnemy(ref string enemyDirection, ref char[,] maze, ref char[,] bluey, ref enemy1 enemy)
        {
            if (enemyDirection == "UP")
            {
                char next1 = maze[enemy.enemyX_pos - 2, enemy.enemyY_pos];
                char next2 = maze[enemy.enemyX_pos - 2, enemy.enemyY_pos + 1];
                char next3 = maze[enemy.enemyX_pos - 2, enemy.enemyY_pos + 2];
                char next4 = maze[enemy.enemyX_pos - 2, enemy.enemyY_pos + 3];
                if (next1 == ' ' || next1 == '*' && next2 == ' ' || next2 == '*' && next3 == ' ' || next3 == '*' && next4 == ' ' || next4 == '*')
                {
                    erase_enemy(ref maze, ref bluey, ref enemy);

                    enemy.enemyX_pos--;

                    printEnemy(ref maze, ref bluey, ref enemy);
                }
                else
                {
                    enemyDirection = "Down";
                }
            }
            else if (enemyDirection == "Down")
            {

                char next1 = maze[enemy.enemyX_pos + 5, enemy.enemyY_pos];
                char next2 = maze[enemy.enemyX_pos + 5, enemy.enemyY_pos + 1];
                char next3 = maze[enemy.enemyX_pos + 5, enemy.enemyY_pos + 2];
                if (next1 == ' ' || next1 == '*' || next1 == '>' && next2 == ' ' || next2 == '>' || next2 == '*' && next3 == ' ' || next3 == '*' || next3 == '>')
                {
                    erase_enemy(ref maze, ref bluey, ref enemy);

                    enemy.enemyX_pos++;

                    printEnemy(ref maze, ref bluey, ref enemy);
                }
                else
                {
                    enemyDirection = "UP";
                }
            }
        }
        // generate  bullets of player
        static void generatebullet(ref bullet[] firing, ref faby faby1, ref int bulletCount, ref char[,] maze)
        {
            char next = maze[faby1.xPos + 4, faby1.yPos + 1];
            if (next == ' ')
            {
                bullet gun = new bullet(); // gun is the name of varibale // bulet is class
                firing[bulletCount] = gun;
                firing[bulletCount].bulletX = faby1.xPos + 1;
                firing[bulletCount].bulletY = faby1.yPos + 4;
                firing[bulletCount].isBulletActive = true;
                Console.SetCursorPosition(faby1.yPos + 4, faby1.xPos + 1);
                Console.WriteLine(".");
                bulletCount++;
            }
        }
        public static void movebullet(ref char[,] maze, ref bullet[] firing, ref int bulletCount)
        {
            for (int index = 0; index < bulletCount; index++)
            {
                if (firing[index].isBulletActive == true)
                {
                    char next = maze[firing[index].bulletX, firing[index].bulletY + 1];
                    if (next != ' ' && next != '.')
                    {
                        eraseBullet(ref maze, firing[index].bulletX, firing[index].bulletY);
                        makebulletInActive(ref firing, index);
                    }
                    else
                    {
                        eraseBullet(ref maze, firing[index].bulletX, firing[index].bulletY);
                        firing[index].bulletY = firing[index].bulletY + 1;
                        printBullet(ref maze, firing[index].bulletX, firing[index].bulletY);
                    }
                }
            }
        }
        static void makebulletInActive(ref bullet[] firing, int z)
        {
            firing[z].isBulletActive = false;
        }
        static void eraseBullet(ref char[,] maze, int x, int y) // player  bullets ends
        {
            Console.SetCursorPosition(y, x);

            Console.WriteLine(" ");
            maze[x, y] = ' ';
        }
        static void printBullet(ref char[,] maze, int x, int y) // player  bullets ends
        {
            Console.SetCursorPosition(y, x);

            Console.WriteLine(".");
            maze[x, y] = '.';
        }

        //move faby right
        public static void moveFabyRight(ref char[,] maze, ref char[,] player, ref faby faby1)
        {
            char next = maze[faby1.xPos, faby1.yPos + 4];
            char next2 = maze[faby1.xPos + 1, faby1.yPos + 4];
            char next3 = maze[faby1.xPos + 2, faby1.yPos + 4];
            char next4 = maze[faby1.xPos + 3, faby1.yPos + 4];
            if (next == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ')
            {
                erase_Player(ref maze, ref player, ref faby1);
                faby1.yPos++;
                printFaby(ref maze, ref player, ref faby1);
            }
        }
        // move Faby left
        public static void moveFabyLeft(ref char[,] maze, ref char[,] player, ref faby faby1) // player movements start
        {
            char next = maze[faby1.xPos, faby1.yPos - 1];
            char next2 = maze[faby1.xPos + 1, faby1.yPos - 1];
            char next3 = maze[faby1.xPos + 2, faby1.yPos - 1];
            char next4 = maze[faby1.xPos + 3, faby1.yPos - 1];
            if (next == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ')
            {
                erase_Player(ref maze, ref player, ref faby1);
                faby1.yPos--;
                printFaby(ref maze, ref player, ref faby1);
            }
        }
        //move faby up
        public static void moveFabyUp(ref char[,] maze, ref char[,] player, ref faby faby1) // player movements start
        {
            char next = maze[faby1.xPos - 1, faby1.yPos];
            char next2 = maze[faby1.xPos - 1, faby1.yPos + 1];
            char next3 = maze[faby1.xPos - 1, faby1.yPos + 2];
            char next4 = maze[faby1.xPos - 1, faby1.yPos + 3];
            if (next == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ')
            {
                erase_Player(ref maze, ref player, ref faby1);
                faby1.xPos--;
                printFaby(ref maze, ref player, ref faby1);
            }
        }
        //move faby down
        public static void moveFabyDown(ref char[,] maze, ref char[,] player, ref faby faby1)
        {
            char next = maze[faby1.xPos + 5, faby1.yPos];
            char next2 = maze[faby1.xPos + 5, faby1.yPos + 1];
            char next3 = maze[faby1.xPos + 5, faby1.yPos + 2];
            char next4 = maze[faby1.xPos + 5, faby1.yPos + 3];
            if (next == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ')
            {
                erase_Player(ref maze, ref player, ref faby1);
                faby1.xPos++;
                printFaby(ref maze, ref player, ref faby1);
            }
        }

    }
}
