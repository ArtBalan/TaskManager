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

        private String[] smallLogo = {"  _____        _     __  __                             ",
                                      " |_   _|_ _ __| |__ |  \\/  |__ _ _ _  __ _ __ _ ___ _ _ ",
                                      "   | |/ _` (_-< / / | |\\/| / _` | ' \\/ _` / _` / -_) '_|",
                                      "   |_|\\__,_/__/_\\_\\ |_|  |_\\__,_|_||_\\__,_\\__, \\___|_|  ",
                                      "                                          |___/         "};


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
            int l;

            if (height > 15 && width > 88)
            {
                h = 9;
                l = 72;
                tempStrArray = bigLogo;
            }
            else if (width > 72)
            {
                h = 6;
                l = 58;
                tempStrArray = smallLogo;
            }
            else //error here
            {
                h = 6;
                l = 0;
                tempStrArray = smallLogo;
            }

            //logo box
            int w = width - 1;
            //horizontal ligne
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

            //vertical ligne
            if (l != 0)
            {
                Console.SetCursorPosition(l, 0);
                Console.Write("╦");
                for (int i = 1; i < h; i++)
                {
                    Console.SetCursorPosition(l, i);
                    Console.Write("║");
                }
                Console.SetCursorPosition(l, h);
                Console.Write("╩");
                PrintInfoBox(l);
            }
            PrintErrorBox();
        }

        private void PrintInfoBox(int l)
        {
            l += 1;
            string toPrint = "";
            System.DateTime date = System.DateTime.Now;


            if (width >= 94 || (width >= 81 && width < 86))
            {
                toPrint = "Date : " + date.ToString("MMM") + " " + date.Day + " " + date.ToString("yyyy");
            }
            else if ((width >= 73 && width < 81) || (width >= 86 && width < 94))
            {
                toPrint = date.ToString("MMM") + " " + date.Day + " " + date.ToString("yyyy");
            }
            Console.SetCursorPosition(l, 1);
            Console.Write(toPrint);
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

