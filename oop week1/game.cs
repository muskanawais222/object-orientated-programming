using System;
using System.Threading;
using System.IO;
using EZInput;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    class Program
    {

        static void Main(string[] args)
        {
            //<<<<<<<<<<<<<<<<ARRAYS>>>>>>>>>>>>>>>>>>>>>>>>>>>

            int fabyX = 4;   // faby cOOrdinates
            int fabyY = 4;    // faby cOOrdinates

            // player character}
            char face = (char)153, leg = (char)234, belly = (Char)219, belly2 = (char)175, nose = (char)16;
            char[,] faby1 = new char[4, 5]{{' ', face, nose, ' ', ' '},
                    {'(', belly, belly, ')', belly2},
                     {'(', belly, belly, ')',' '},
                    { ' ', leg, ' ', ' ', ' '}};

            //// Eneny coordinates //////
            int cloeyX = 10;                            //  (move horizontal)
            int cloeyY = 29;                        // enemy coordinates
            string cloeyDirection = "right";        // direction
                                                    // enemy characters
            char box = (char)254;
            char[,] cloey1 = new char[4, 6]  {
            {' ', ' ', ' ', '^', ' ', ' '},
                     {'<', '=', '(', '^', ')', ' '},
                     {' ', ' ', '@', '@', '@', ' '},
                     {' ', box, box, box, box, box}
              };
            // fluppy random motion 
            int fluppyX = 50;
            int fluppyY = 25;
            int fluppyRandom;
            int fluppySpeed;
            int fluppyRandomSpeed;
            char body = (char)254;
            char[,] fluppy1 = new char[4, 6]  {
            {' ', ' ', ' ', '^', ' ', ' '},
                     {'<', '=', '(', '^', ')', ' '},
                     {' ', ' ', '@', '@', '@', ' '},
                     {' ', body, body, body, body, body}
              };
            // enemey  
            int enemyX = 70;
            int enemyY = 10;
            int enemyHealth = 50;
            string enemyDirection = "up";
            char boy = (char)254;
            char[,] enemy1 = new char[4, 6]  {
            {' ', ' ', ' ', '^', ' ', ' '},
                     {'<', '=', '(', '^', ')', ' '},
                     {' ', ' ', '@', '@', '@', ' '},
                     {' ', boy, boy, boy, boy, boy}
              };



            // faby bullet}
            int[] bulletX = new int[1000];
            int[] bulletY = new int[1000];
            bool[] isBulletActive = new bool[1000];
            int bulletCount = 0;
            int timer = 0;
            int score = 0;
            int cloeyhealth = 50;
            int fluppyHealth = 50;
            int fabyHealth = 50;
            int enemyHealth = 50;

            // maze
            char[,] maze = new char[35, 120];
            ///////////////////////////////////////////////////////////////////
            logo();
            ship();

            readData(maze);
            printMaze(maze);

            while (true)
            {
                int option;

                Console.Clear();
                Console.WriteLine("Enter any option : ");
                Console.WriteLine("1. PLAY   ");
                Console.WriteLine("2. Help / Instructions  ");
                Console.WriteLine("3. Exit   ");
                Console.WriteLine("Enter your option .");
                option = int.Parse(Console.ReadLine());
                bool gamerunning = true;
                if (option == 1)
                {
                    gamerunning = true;
                    printMaze( maze);
                    printFaby(ref maze , faby1, ref fabyX , ref fabyY);
                    printEnemy(ref maze ,enemy1 , ref enemyX ,ref enemyY);
                    printCloey(ref maze, cloey1, ref cloeyX, ref cloeyY);
                    printfluppy(ref maze , fluppy1 , ref fluppyX , ref fluppyY);
                    while (gamerunning)
                    {

                        if (Keyboard.IsKeyPressed(Key.LeftArrow))
                        {
                            moveFabyLeft(maze,faby1, ref fabyX, ref fabyY);
                        }
                        if (Keyboard.IsKeyPressed(Key.RightArrow))
                        {
                            moveFabyRight(maze, faby1, ref fabyX, ref fabyY);
                        }
                        if (Keyboard.IsKeyPressed(Key.UpArrow))
                        {
                            moveFabyUp(maze,faby1, ref fabyX, ref fabyY);
                        }
                        if (Keyboard.IsKeyPressed(Key.DownArrow))
                        {
                            moveFabyDown(maze,faby1, ref fabyX, ref fabyY);
                        }
                        if (Keyboard.IsKeyPressed(Key.Space))
                        {
                            generateBullet(maze,faby1, ref fabyX, ref fabyY , );
                        }

                        if (enemyHealth > 0)
                        {
                            moveEnemy();
                        }
                        if (cloeyhealth > 0)
                        {
                            moveCloey();
                        }
                        if (fluppyHealth > 0)
                        {
                            movefluppy();
                        }
                      moveBullet(ref maze, ref bulletX, ref bulletY, ref bulletCount, ref isBulletActive, ref enemyX, ref enemyY);

                        bulletCollisionWithFluppy();
                        Thread.Sleep(25);
                        generatePalate();
                        bulletCollisionWithEnemy();
                        bulletCollisionWithCloey();
                        gameOver();
                        printScore();
                        deleteEnemies();
                        killEnemyPallat--;

                    }
                }
                else if (option == 2)
                {
                    help();
                }
                else if (option == 3)
                {
                    Console.WriteLine("Thanks for playing");

                    break;
                }
            }
        }



        static void printMaze(char[,] maze)
        {
            //  blue();

            for (int x = 0; x < 35; x++)
            {
                for (int y = 0; y < 120; y++)
                {
                    if (y == 0 || y == 119 || x == 1 || x == 34)
                    {
                        Console.Write(maze[x, y] = '#');
                    }
                    else if (y > 10 && y < 15 && x > 5 && x < 9)
                    {
                        Console.Write(maze[x, y] = '@');
                    }
                    else if (y > 50 && y < 55 && x > 5 && x < 9)
                    {
                        Console.Write(maze[x, y] = '@');
                    }
                    else if (y > 80 && y < 85 && x > 5 && x < 9)
                    {
                        Console.Write(maze[x, y] = '@');
                    }
                    else if (y > 66 && y < 71 && x > 24 && x < 28)
                    {
                        Console.Write(maze[x, y] = '@');
                    }
                    else if (y > 23 && y < 29 && x > 24 && x < 28)
                    {
                        Console.Write(maze[x, y] = '@');
                    }
                    else if (y > 34 && y < 38 && x > 16 && x < 20)
                    {
                        Console.Write(maze[x, y] = '@');
                    }
                    else if (y > 83 && y < 90 && x > 16 && x < 20)
                    {
                        Console.Write(maze[x, y] = '@');
                    }

                    else if (y > 102 && y < 105 && x > 10 && x < 27)
                    {
                        Console.Write(maze[x, y] = '@');
                    }

                    else
                    {
                        Console.Write(maze[x, y] = ' ');
                    }

                    Console.Write(maze[x, y]);
                }
                Console.WriteLine();
            }
        }
        static void readData(char[,] maze)
        {
            StreamReader fp = new StreamReader("D:/semester2/Object Orientated Programing/week1/game/maze.txt");
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int x = 0; x < 120; x++)
                {
                    maze[row, x] = record[x];
                }
                row++;
            }

            fp.Close();
        }
      static void printFaby(ref char[,] maze , char[,] faby1, ref int fabyX , ref int fabyY)
        {
            

            for (int x = 0; x< faby1.GetLength(0) ; x++)
            {
                for (int y = 0; y < faby1.GetLength(1); y++)
                {
                    Console.SetCursorPosition(fabyY + y, fabyX + x);
                    Console.Write(faby1[x, y]);
                    maze[fabyX + x, fabyY + y] = faby1[x, y];
                }
            }
        }
        static void Erasefaby(ref char[,] maze, char[,] faby1, ref int fabyX, ref int fabyY)
        {
            for (int x = 0; x < faby1.GetLength(0); x++)
            {
                for (int y = 0; y < faby1.GetLength(1); y++)
                {
                    Console.SetCursorPosition(fabyY + y, fabyX + x);
                    Console.Write(" ");
                    maze[fabyX + x, fabyY + y] = ' ';
                }
            }
        }


        // faby left
        static void moveFabyLeft(char[,] maze, char[,] faby1 , ref int fabyX, ref int fabyY)
        {
           
            if (maze[fabyX, fabyY - 1] == ' ' && maze[fabyX - 1, fabyY - 1] == ' ')
            {

                Erasefaby(ref maze, faby1, ref fabyX, ref fabyY);

                fabyY = fabyY - 1;
                printFaby(ref maze, faby1, ref fabyX, ref fabyY);
            }
        }
        // faby right
        static void moveFabyRight(char[,] maze, char[,] faby1 , ref int fabyX, ref int fabyY)
        {
            if (maze[fabyX, fabyY + 5] == ' ' && maze[fabyX + 1, fabyY + 5] == ' ')
            {

                Erasefaby(ref maze, faby1 , ref fabyX, ref fabyY);

                fabyY = fabyY + 1;
                printFaby(ref maze, faby1, ref fabyX, ref fabyY);
            }

        }
       // faby up
       static void moveFabyUp(char[,] maze, char[,] faby1, ref int fabyX, ref int fabyY)
        {
            if (maze[fabyY, fabyX - 1] == ' ' && maze[fabyY - 1, fabyX - 1] == ' ')
            {

                Erasefaby(ref maze, faby1, ref fabyX, ref fabyY);

                fabyX = fabyX - 1;
                printFaby(ref maze, faby1, ref fabyX, ref fabyY);
            }

        }
       // faby down
        static void moveFabyDown(char[,] maze, char[,] faby1, ref int fabyX, ref int fabyY)
        {
            if (maze[fabyX+6, fabyY] == ' ' && maze[fabyX + 6, fabyY + 1] == ' ')
            {

                Erasefaby(ref maze, faby1, ref fabyX, ref fabyY);

                fabyX = fabyX +1;
                printFaby(ref maze, faby1, ref fabyX, ref fabyY);
            }
        }
       static  void erasefaby(ref char[,] maze, char[,] faby1, ref int fabyX, ref int fabyY)
        {
            for (int x = 0; x < faby1.GetLength(0); x++)
            {
                Console.SetCursorPosition(fabyX, fabyY + x);
                for (int y = 0; y < faby1.GetLength(0) ; y++)
                {
                    Console.SetCursorPosition(fabyY + y, fabyX + x);
                    Console.Write(" ");
                    maze[fabyX + x, fabyY + y] = ' ';
                }
            }
        }
        // bulletGeneration
        //{
       static void generateBullet(ref char[,] maze, char[,] faby1, ref int fabyX, ref int fabyY, ref int bulletCount, ref int[] bulletX, ref int[] bulletY, ref bool[] isBulletActive)
        {

                bulletX[bulletCount] = fabyX - 1;
                bulletY[bulletCount] = fabyY + 2;
                char next = maze[bulletX[bulletCount], bulletY[bulletCount]];
                if (next == ' ')
                {
                    printBullet(ref maze, bulletX[bulletCount], bulletY[bulletCount]);
                    bulletCount++;
                    isBulletActive[bulletCount] = true;
                }
        }
        static void moveBullet(ref char[,] maze,  ref int[] bulletX, ref int[] bulletY, ref int bulletCount, ref bool [] isBulletActive,ref int fluppyX , ref int fluppyY, ref int cloeyX , ref int cloeyY, ref int enemyX, ref int enemyY)

        {
            for (int x = 0; x < bulletCount; x++)
            {

                char next = maze[bulletX[x] - 1, bulletY[x]];
                if (next == ' ')
                {
                    eraseBullet(ref maze, bulletX[x], bulletY[x]);
                    bulletX[x]--;
                    printBullet(ref maze, bulletX[x], bulletY[x]);
                }
                else if (next != ' ' || (bulletY[x] == enemyX && (bulletX[x] == enemyY + 3)) || (bulletY[x] == enemyX + 1 && (bulletX[x] == enemyY + 3)) || (bulletY[x] == enemyX + 2 && (bulletX[x] == enemyY + 3)) || (bulletY[x] == enemyX + 3 && (bulletX[x] == enemyY + 3)) || (bulletY[x] == enemyX + 4 && (bulletX[x] == enemyY + 3)) || (bulletY[x] == enemyX + 5 && bulletX[x] == enemyY + 3))
                {
                    eraseBullet(ref maze, bulletX[x], bulletY[x]);
                    isBulletActive[bulletCount] = false;
                    makeBulletInactive(ref x, ref bulletX, ref bulletY, ref bulletCount);
                }

            }
        }
       static void printBullet(ref char[,] maze ,int x, int y)
        {

            Console.SetCursorPosition(x, y);
            Console.WriteLine(".");
            maze[x, y] = '.';
        }

      static  void eraseBullet(ref char[,] maze , int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(" ");
            maze[x, y] = ' ';
        }
      static  void makeBulletInactive(ref int index , ref int[] bulletX , ref int[] bulletY, ref int bulletCount)
        {
            isBulletActive[index] = false;
        }
        //
        // collision detection
       static void bulletCollisionWithEnemy()
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if (bulletX[x] == enemyX - 1 && (bulletY[x] == enemyY || bulletY[x] == enemyY + 2 || bulletY[x] == enemyY + 3))
                    {
                        if (killEnemyPallat <= 0)
                        {
                            addScore();
                            enemyHealth--;
                        }
                        else if (killEnemyPallat > 0)
                        {
                            score = score + 5;
                            enemyHealth = enemyHealth - 5;
                        }
                    }
                    if (enemyX - 1 == bulletX[x] && enemyY + 1 == bulletY[x])
                    {
                        if (killEnemyPallat <= 0)
                        {
                            addScore();
                            enemyHealth--;
                        }
                        else if (killEnemyPallat > 0)
                        {
                            score = score + 5;
                            enemyHealth = enemyHealth - 5;
                        }
                    }
                }
            }
        }
        // reward And score
       static void addScore()
        {
            score++;
        }
       static void printScore()
        {
            blue();
            Console.SetCursorPosition(5, 0);
            Console.WriteLine("Score is : " + score);
            Console.SetCursorPosition(20, 0);
            Console.WriteLine("cloey Health : " + cloeyhealth);
            Console.SetCursorPosition(45, 0);
            Console.WriteLine("FluppyHealth is : " + fluppyHealth);
            Console.SetCursorPosition(70, 0);
            Console.WriteLine("faby health is : " + fabyHealth);
            Console.SetCursorPosition(95, 0);
            Console.WriteLine("enemy health is : " + enemyHealth);
        }
        // enemy
       static void printEnemy()
        {
            green();
            for (int x = 0; x < 4; x++)
            {
                Console.SetCursorPosition(enemyX, enemyY + x);
                for (int y = 0; y < 6; y++)
                {
                    Console.WriteLine(enemy1[x][y];
                }
            }
        }
       static void moveEnemy()
        {

            if (enemySpeeds % 2 == 0)
            {
                if (enemyDirection == "up")
                {
                    char next1 = getCharAtxy(enemyX, enemyY - 1);
                    char next2 = getCharAtxy(enemyX + 1, enemyY - 1);
                    char next3 = getCharAtxy(enemyX + 2, enemyY - 1);
                    char next4 = getCharAtxy(enemyX + 3, enemyY - 1);
                    char next5 = getCharAtxy(enemyX + 4, enemyY - 1);
                    char next6 = getCharAtxy(enemyX + 5, enemyY - 1);
                    {
                        if ((next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ' && next6 == ' ') || (next1 == heart || next2 == heart || next3 == heart || next4 == heart || next5 == heart || next6 == heart))
                        {
                            eraseEnemy();
                            enemyY--;
                            printEnemy();
                        }
                        if (next1 != ' ' || next2 != ' ' || next3 != ' ' || next4 != ' ' || next5 != ' ' || next6 != ' ')
                        {
                            enemyDirection = "down";
                        }
                    }
                }
                if (enemyDirection == "down")
                {

                    char next1 = getCharAtxy(enemyX, enemyY + 4);
                    char next2 = getCharAtxy(enemyX + 1, enemyY + 4);
                    char next3 = getCharAtxy(enemyX + 2, enemyY + 4);
                    char next4 = getCharAtxy(enemyX + 3, enemyY + 4);
                    char next5 = getCharAtxy(enemyX + 4, enemyY + 4);
                    char next6 = getCharAtxy(enemyX + 5, enemyY + 4);

                    {
                        if ((next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ' && next6 == ' ') || (next1 == heart || next2 == heart || next3 == heart || next4 == heart || next5 == heart || next6 == heart))
                        {
                            eraseEnemy();
                            enemyY++;
                            printEnemy();
                        }
                        if (next1 != ' ' || next2 != ' ' || next3 != ' ' || next4 != ' ' || next5 != ' ' || next6 != ' ')
                        {
                            enemyDirection = "up";
                        }
                    }
                }
           }
            enemySpeeds++;
        }
       static void eraseEnemy(ref char[,] maze, ref char[,] enemy1, ref int enemyX, ref int enemyY)
        {

            for (int x = 0; x < enemy1.GetLength(0); x++)
            {

                for (int y = 0; y < enemy1.GetLength(1); y++)
                {
                    Console.SetCursorPosition(enemyY + y, enemyX + x);
                    Console.Write(" ");
                    maze[enemyX + x, enemyY + y] = ' ';               }
            }
        }

        // enemyCloey
      static  void printCloey()
        {
            grey();
            for (int x = 0; x < 4; x++)
            {
                Console.SetCursorPosition(cloeyX, cloeyY + x);
                for (int y = 0; y < 5; y++)
                {
                    Console.WriteLine(cloey1[x][y];
                }
            }
        }
      static  void moveCloey()
        {
            if (enemySpeeds % 2 == 0)
            {
                if (cloeyDirection == "right")
                {
                    char next1 = getCharAtxy(cloeyX + 6, cloeyY);
                    char next2 = getCharAtxy(cloeyX + 6, cloeyY + 1);
                    char next3 = getCharAtxy(cloeyX + 6, cloeyY + 2);
                    char next4 = getCharAtxy(cloeyX + 6, cloeyY + 3);
                    {
                        if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' || (next1 == heart || next2 == heart || next3 == heart || next4 == heart))
                        {
                            eraseCloey();
                            cloeyX++;
                            printCloey();
                        }
                        if (next1 != ' ' || next2 != ' ' || next3 != ' ' || next4 != ' ')
                        {
                            cloeyDirection = "left";
                        }
                    }
                }
                if (cloeyDirection == "left")
                {
                    char next1 = getCharAtxy(cloeyX - 1, cloeyY);
                    char next2 = getCharAtxy(cloeyX - 1, cloeyY + 1);
                    char next3 = getCharAtxy(cloeyX - 1, cloeyY + 2);
                    char next4 = getCharAtxy(cloeyX - 1, cloeyY + 3);
                    if (next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ')
                    {
                        eraseCloey();
                        cloeyX--;
                        printCloey();
                    }
                    if (next1 != ' ' || next2 != ' ' || next3 != ' ' || next4 != ' ')
                    {
                        cloeyDirection = "right";
                    }
                }
            }
        }

      static  void eraseCloey(ref char[,] maze, ref char[,] cloey1, ref int cloeyX, ref int cloeyY)
        {

            for (int x = 0; x < cloey1.GetLength(0); x++)
            {

                for (int y = 0; y < cloey1.GetLength(1); y++)
                {
                    Console.SetCursorPosition(cloeyY + y, cloeyX + x);
                    Console.Write(" ");
                    maze[cloeyX + x, cloeyY + y] = ' ';
                }
            }
        }
        // collision with enemy2

        void bulletCollisionWithCloey()
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if (bulletX[x] == cloeyX - 1 && (bulletY[x] == cloeyY || bulletY[x] == cloeyY + 2 || bulletY[x] == cloeyY + 3))
                    {
                        if (killEnemyPallat <= 0)
                        {
                            addScore();
                            cloeyhealth--;
                        }
                        else if (killEnemyPallat > 0)
                        {
                            score = score + 5;
                            cloeyhealth = enemyHealth - 5;
                        }
                    }
                    if (cloeyX - 1 == bulletX[x] && cloeyY + 1 == bulletY[x])
                    {
                        if (killEnemyPallat <= 0)
                        {
                            addScore();
                            cloeyhealth--;
                        }
                        else if (killEnemyPallat > 0)
                        {
                            score = score + 5;
                            cloeyhealth = enemyHealth - 5;
                        }
                    }
                }
            }
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

        static void ship()
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

       static void exit(ref gamerunning)
        {
            Console.Clear();
            gamerunning = false;
            Console.WriteLine("exit the game "); ;
            Console.WriteLine("OH SHIT! "); ;
            Console.WriteLine("Game Over "); ;

        }

        static void gameOver()
        {
            if (fabyHealth <= 0)
            {
                gamerunning = false;
                Console.WriteLine("OH SHIT! "); ;
                Console.WriteLine("GAME OVER, You Lose!!! "); ;
                Console.WriteLine("Press any key to continue";
                getch();
            }
            else if (fluppyHealth <= 0 && enemyHealth <= 0 && cloeyhealth <= 0)
            {
                gamerunning = false;
                Console.WriteLine("YOU WIN "); ;
                Console.WriteLine("GAME Complete "); ;
                Console.WriteLine("Press any key to continue";
                getch();
            }
        }
        //
        // fluppy functionalities
        //
        static void printfluppy()
        {
            lightYellow();
            for (int x = 0; x < 4; x++)
            {
                Console.SetCursorPosition(fluppyX, fluppyY + x);
                for (int y = 0; y < 5; y++)
                {
                    Console.WriteLine(fluppy1[x][y];
                }
            }
        }
       static void movefluppy()
        {

            if (enemySpeeds % 3 == 0)
            {
                if (fluppyRandom % 8 == 0)
                {
                    fluppyRandomSpeed = rand() % 4;
                }

                if (fluppyRandomSpeed == 0) // Right
                {
                    char next1 = getCharAtxy(fluppyX + 6, fluppyY);
                    char next2 = getCharAtxy(fluppyX + 6, fluppyY + 1);
                    char next3 = getCharAtxy(fluppyX + 6, fluppyY + 2);
                    char next4 = getCharAtxy(fluppyX + 6, fluppyY + 3);
                    if ((next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ') || (next1 == heart || next2 == heart || next3 == heart || next4 == heart))
                    {
                        erasefluppy();
                        fluppyX++;
                        printfluppy();
                    }
                }

                if (fluppyRandomSpeed == 1) // Left
                {
                    char next1 = getCharAtxy(fluppyX - 1, fluppyY);
                    char next2 = getCharAtxy(fluppyX - 1, fluppyY + 1);
                    char next3 = getCharAtxy(fluppyX - 1, fluppyY + 2);
                    char next4 = getCharAtxy(fluppyX - 1, fluppyY + 3);

                    if ((next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ') || (next1 == heart || next2 == heart || next3 == heart || next4 == heart))
                    {
                        erasefluppy();
                        fluppyX--;
                        printfluppy();
                    }
                }
                if (fluppyRandomSpeed == 2) // Up
                {
                    char next1 = getCharAtxy(fluppyX, fluppyY - 1);
                    char next2 = getCharAtxy(fluppyX + 1, fluppyY - 1);
                    char next3 = getCharAtxy(fluppyX + 2, fluppyY - 1);
                    char next4 = getCharAtxy(fluppyX + 3, fluppyY - 1);
                    char next5 = getCharAtxy(fluppyX + 4, fluppyY - 1);
                    char next6 = getCharAtxy(fluppyX + 5, fluppyY - 1);

                    if ((next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ' && next6 == ' ') || (next1 == heart || next2 == heart || next3 == heart || next4 == heart || next5 == heart || next6 == heart))
                    {
                        erasefluppy();
                        fluppyY--;
                        printfluppy();
                    }
                }

                if (fluppyRandomSpeed == 3) // DOWN
                {
                    char next1 = getCharAtxy(fluppyX, fluppyY + 4);
                    char next2 = getCharAtxy(fluppyX + 1, fluppyY + 4);
                    char next3 = getCharAtxy(fluppyX + 2, fluppyY + 4);
                    char next4 = getCharAtxy(fluppyX + 3, fluppyY + 4);
                    char next5 = getCharAtxy(fluppyX + 4, fluppyY + 4);
                    char next6 = getCharAtxy(fluppyX + 5, fluppyY + 4);
                    {
                        if ((next1 == ' ' && next2 == ' ' && next3 == ' ' && next4 == ' ' && next5 == ' ' && next6 == ' ') || (next1 == heart || next2 == heart || next3 == heart || next4 == heart || next5 == heart || next6 == heart))
                        {
                            erasefluppy();
                            fluppyY++;
                            printfluppy();
                        }
                    }
                }

                fluppyRandom++;
            }
        }

      static void erasefluppy(ref char[,] maze, ref char[,] fluppy1, ref int fluppyX, ref int fluppyY)
        {

            for (int x = 0; x < fluppy1.GetLength(0); x++)
            {

                for (int y = 0; y < fluppy1.GetLength(1); y++)
                {
                    Console.SetCursorPosition(fluppyY + y, fluppyX + x);
                    Console.Write(" ");
                    maze[fluppyX + x, fluppyY + y] = ' ';
                }
            }
        }
        void bulletCollisionWithFluppy()
        {
            for (int x = 0; x < bulletCount; x++)
            {
                if (isBulletActive[x] == true)
                {
                    if (bulletX[x] == fluppyX - 1 && (bulletY[x] == fluppyY || bulletY[x] == fluppyY + 2 || bulletY[x] == fluppyY + 3))
                    {
                        if (killEnemyPallat <= 0)
                        {
                            addScore();
                            fluppyHealth--;
                        }
                        else if (killEnemyPallat > 0)
                        {
                            score = score + 5;
                            fluppyHealth = enemyHealth - 5;
                        }
                    }
                    if (fluppyX - 1 == bulletX[x] && fluppyY + 1 == bulletY[x])
                    {
                        if (killEnemyPallat <= 0)
                        {
                            addScore();
                            fluppyHealth--;
                        }
                        else if (killEnemyPallat > 0)
                        {
                            score = score + 5;
                            fluppyHealth = enemyHealth - 5;
                        }
                    }
                }
            }
        }

       

        void generatePalate()
        {
            red();
            if (palletSpeed % 500 == 0)
            {
                int x = rand() % 118;
                int y = rand() % 34;
                char next = getCharAtxy(x, y);

                Console.SetCursorPosition(x, y);
                Console.WriteLine(heart;
            }
            if (palletSpeed % 200 == 0)
            {
                int x = rand() % 118;
                int y = rand() % 34;
                char next = getCharAtxy(x, y);

                Console.SetCursorPosition(x, y);
                Console.WriteLine(trap);
            }
            palletSpeed++;
        }

       static void deleteEnemies()
        {
            if (fluppyHealth <= 0)
            {
                fluppyHealth = 0;
                erasefluppy();
            }
            if (enemyHealth <= 0)
            {
                enemyHealth = 0;
                eraseEnemy();
            }
            if (cloeyhealth <= 0)
            {
                cloeyhealth = 0;
                eraseCloey();
            }
        }


    }
}

