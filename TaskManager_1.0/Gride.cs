using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    class Gride
    {
        private int width;
        private int height;

        private String[] bigLogo = { "    _______        _      __  __                                   " ,
                                     "   |__   __|      | |    |  \\/  |                                  ",
                                     "      | | __ _ ___| | __ | \\  / | __ _ _ __   __ _  __ _  ___ _ __ ",
                                     "      | |/ _` / __| |/ / | |\\/| |/ _` | '_ \\ / _` |/ _` |/ _ \\ '__|",
                                     "      | | (_| \\__ \\   <  | |  | | (_| | | | | (_| | (_| |  __/ |   ",
                                     "      |_|\\__,_|___/_|\\_\\ |_|  |_|\\__,_|_| |_|\\__,_|\\__, |\\___|_|   ",
                                     "                                                    __/ |          ",
                                     "                                                   |___/          "};

        private String[] smallLogo = {"    _____        _     __  __                             ",
                                      "   |_   _|_ _ __| |__ |  \\/  |__ _ _ _  __ _ __ _ ___ _ _ ",
                                      "     | |/ _` (_-< / / | |\\/| / _` | ' \\/ _` / _` / -_) '_|",
                                      "     |_|\\__,_/__/_\\_\\ |_|  |_\\__,_|_||_\\__,_\\__, \\___|_|  ",
                                      "                                            |___/         "};


        public Gride(int w, int h)
        {
        }

        public void PrintGride()
        {
            width = Console.WindowWidth;
            height = Console.WindowHeight;
            //main box
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j <= height - 3; j++)
                {


                    if (i == 0 && j == 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("╔");
                    }
                    else if (i == width - 1 && j == 0)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("╗");
                    }
                    else if (i == 0 && j == height - 3)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("╚");
                    }
                    else if (i == width - 1 && j == height - 3)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("╝");
                    }
                    else if (i == 0 || i == width - 1)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("║");
                    }
                    else if (j == 0 || j == height - 3)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("═");
                    }
                    else
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write(" ");
                    }
                }
            }
            PrintLogo();
            ClearInput();
        }

        private void PrintLogo()
        {
            String[] tempStrArray;
            int h;

            if (height > 15 && width > 72)
            {
                h = 9;
                tempStrArray = bigLogo;
            }
            else
            {
                h = 6;
                tempStrArray = smallLogo;
            }

            //logo box
            int w = width - 1;
            for (int i = 0; i < width; i++)
            {
                if (i == 0)
                {
                    Console.SetCursorPosition(i, h);
                    Console.Write("╠");
                }
                else if (i == width - 1)
                {
                    Console.SetCursorPosition(i, h);
                    Console.Write("╣");
                }
                else
                {
                    Console.SetCursorPosition(i, h);
                    Console.Write("═");
                }
            }

            //logo print
            for (int i = 0; i < tempStrArray.Length; i++)
            {
                Console.SetCursorPosition(1, i + 1);
                Console.Write(tempStrArray[i]);
            }

            PrintErrorBox();
        }

        private void PrintErrorBox()
        {
            Console.SetCursorPosition(0, height - 5);
            Console.Write("╠");
            for (int i = 0; i < width - 2; i++) Console.Write("═");
            Console.Write("╣");
        }

        public void ClearScreen()
        {
            ClearInput();
            ClearOutPut();
            Error.clearLine();
        }

        public void ClearOutPut()
        {
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 10; j < height - 5; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

        public void ClearInput()
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            for (int i = 0; i < width; i++)
            {
                Console.Write(" ");
            }
        }
    }
}

