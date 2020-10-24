using System;
using System.IO;
using System.Collections.Generic;
using TaskManager;
using Newtonsoft.Json;

namespace TaskManager_1._0
{
    class Program
    {

        //Fonction de validation
        static public bool Validation(int i)
        {
            Console.SetCursorPosition(0, Console.WindowHeight - 2);

            if (i == 0) Console.Write("Exit ? ");
            if (i == 1) Console.Write("delete ? ");
            if (i == 2) Console.Write("Save changes ? ");
            if (i == 3) Console.Write("Reload save file without loading ? (changes will be lost) ");
            String input = Console.ReadLine();
            if (input == "y" || input == "Y") return true;
            else return false;
        }

        //Affiche liste
        static public void PrintLis(List<Lis> lisList)
        {
            int h;
            if (Console.WindowHeight > 15) h = 10;
            else h = 5;
            Console.SetCursorPosition(1, h);

            for (int i = 0; i < lisList.Count; i++)
            {
                Console.SetCursorPosition(1, h + i + 1);
                Console.Write(i);
                Console.Write(" " + lisList[i].name);

                if (lisList[i].daily) Console.Write("  " + "daily");
            }
        }

        static void Main(string[] args)
        {
            bool exit = false;
            string[] input;

            // main List of lis
            List<Lis> lisList = new List<Lis>();

            // loading save file
            lisList = ReadFromJsonFile<List<Lis>>("saves.txt");

            // reset dailyies
            foreach (Lis item in lisList)
            {
                if (item.daily)
                {
                    if (System.DateTime.Today.DayOfYear != item.date.DayOfYear)
                    {
                        foreach (Task task in item.taskList)
                        {
                            task.done = false;
                        }
                    }
                }
            }






            //new grid creation
            Gride gride = new Gride(Console.WindowWidth, Console.WindowHeight);
            gride.PrintGride();

            while (!exit)
            {
                //reset cursor and read input line
                gride.ClearInput();
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                input = Console.ReadLine().Split(' ');
                Error.clearLine();

                switch (input[0])
                {
                    case "show":
                        gride.ClearOutPut();
                        PrintLis(lisList);
                        break;

                    case "clear":
                        gride.PrintGride();
                        break;

                    case "new":
                        if (input.Length == 2)
                        {
                            lisList.Add(new Lis(input[1]));
                        }
                        else if (input.Length == 3)
                        {
                            switch (input[2])
                            {
                                case "0":
                                    lisList.Add(new Lis(input[1], false));
                                    break;
                                case "1":
                                    lisList.Add(new Lis(input[1], true));
                                    break;
                                default:
                                    Error.WrongParameter();
                                    break;
                            }
                        }
                        else Error.WrongParameter();
                        gride.ClearOutPut();
                        PrintLis(lisList);
                        break;

                    case "open":
                        try
                        {
                            int tempint = Int16.Parse(input[1]);
                            if (tempint < lisList.Count)
                            {
                                gride.ClearOutPut();
                                lisList[tempint].Manage(gride);
                            }
                            else Error.OutOfRange();
                        }
                        catch
                        {
                            Error.WrongParameter();
                        }
                        gride.ClearScreen();
                        PrintLis(lisList);
                        break;

                    case "rename":
                        if (input.Length == 3)
                        {
                            try
                            {
                                int id = int.Parse(input[1]);
                                if (id < lisList.Count) lisList[id].name = input[2];
                                else Error.OutOfRange();
                            }
                            catch
                            {
                                Error.WrongParameter();
                            }
                        }
                        else Error.WrongParameter();
                        gride.ClearOutPut();
                        PrintLis(lisList);
                        break;

                    case "delete":
                        if (input.Length == 2)
                        {
                            try
                            {
                                int id = int.Parse(input[1]);
                                if (id < lisList.Count)
                                {
                                    if (Validation(1)) lisList.RemoveAt(id);
                                }
                                else Error.OutOfRange();
                            }
                            catch
                            {
                                Error.WrongParameter();
                            }
                        }
                        else Error.WrongParameter();
                        gride.ClearOutPut();
                        PrintLis(lisList);
                        break;

                    case "edit":
                        if (input.Length == 2)
                        {
                            try
                            {
                                int id = int.Parse(input[1]);
                                if (id < lisList.Count) lisList[id].daily = !lisList[id].daily;
                                else Error.OutOfRange();
                            }
                            catch
                            {
                                Error.WrongParameter();
                            }
                        }
                        else Error.WrongParameter();
                        gride.ClearOutPut();
                        PrintLis(lisList);
                        break;

                    case "exit":
                        gride.ClearInput();
                        exit = Validation(0);
                        WriteToJsonFile("saves.txt", lisList);
                        break;

                    case "sys":
                        if (input.Length == 2)
                        {
                            switch (input[1])
                            {
                                case "getwsize":
                                    Error.Custom("w:" + Console.WindowWidth.ToString() + ", h:" + Console.WindowHeight.ToString());
                                    break;

                                case "reload":
                                    if (Validation(3)) lisList = ReadFromJsonFile<List<Lis>>("saves.txt");
                                    Error.Custom("Save file reloaded.");
                                    break;

                                case "save":
                                    if (Validation(2)) WriteToJsonFile("saves.txt", lisList);
                                    Error.Custom("Changes saved.");
                                    break;

                                case "reset":
                                    break;
                            }
                        }
                        else if (input.Length == 4) break;
                        break;

                    case "help":
                        Help.HelpMe(gride, 0);
                        break;

                    default:
                        gride.ClearInput();
                        Error.UnknowCommand();
                        break;
                }
            }
        }
        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static T ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(fileContents);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
