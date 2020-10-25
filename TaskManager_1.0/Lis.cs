using System;
using System.Collections.Generic;
using System.Text;
using TaskManager;

namespace TaskManager_1._0
{
    class Lis
    {
        public string name;
        public List<Task> taskList;
        public Boolean daily;
        public DateTime date;


        //Constructor
        public Lis() { }


        public Lis(string name)
        {
            this.name = name;
            this.daily = false;
            taskList = new List<Task>();
        }
        public Lis(string name, Boolean daily)
        {
            this.name = name;
            this.daily = daily;

            if (daily) this.date = System.DateTime.Now;
            taskList = new List<Task>();
        }

        public void AddTask(Task task)
        {
            taskList.Add(task);
        }

        public void PrintTasks()
        {
            int h;
            if (Console.WindowHeight > 15 && Console.WindowWidth > 111) h = 10;
            else h = 7;

            Console.SetCursorPosition(1, h);
            Console.WriteLine(this.name);
            int i = 0;

            foreach (Task task in taskList)
            {
                Console.SetCursorPosition(1, h + 2 + i);
                Console.Write(i);
                Console.Write(" " + task.name);

                if (task.done)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("  " + "V");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("  " + "X");
                    Console.ResetColor();
                }
                i++;
            }
        }

        public void Manage(Gride gride)
        {
            bool exit = false;
            String[] input;

            PrintTasks();

            while (!exit)
            {
                gride.ClearInput();
                Console.SetCursorPosition(0, Console.WindowHeight - 2);
                input = Console.ReadLine().Split(' ');
                Error.clearLine();

                switch (input[0])
                {
                    case "exit":
                        gride.ClearInput();
                        exit = Program.Validation(0);
                        break;

                    case "clear":
                        gride.PrintGride();
                        break;

                    case "show":
                        gride.ClearScreen();
                        PrintTasks();
                        break;

                    case "new":
                        if (input.Length == 2) taskList.Add(new Task(input[1]));
                        else if (input.Length == 3)
                        {
                            switch (input[2])
                            {
                                case "0":
                                    taskList.Add(new Task(input[1]));
                                    break;
                                case "1":
                                    taskList.Add(new Task(input[1], true));
                                    break;
                                default:
                                    Error.WrongParameter();
                                    break;
                            }
                        }
                        else Error.WrongParameter();
                        gride.ClearOutPut();
                        PrintTasks();
                        break;

                    case "edit":
                        if (input.Length == 2)
                        {
                            try
                            {
                                int id = int.Parse(input[1]);
                                if (id < taskList.Count) taskList[id].done = !taskList[id].done;
                                else Error.OutOfRange();
                            }
                            catch
                            {
                                Error.WrongParameter();
                            }
                        }
                        else if (input.Length == 3)
                        {
                            try
                            {
                                int id = int.Parse(input[1]);
                                int done = int.Parse(input[2]);
                                if (id < taskList.Count)
                                {
                                    if (done == 0) taskList[id].done = false;
                                    else if (done == 1) taskList[id].done = true;
                                    else Error.WrongParameter();
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
                        PrintTasks();
                        break;

                    case "swap":
                        if (input.Length == 3)
                        {
                            try
                            {
                                int id1 = int.Parse(input[1]);
                                int id2 = int.Parse(input[2]);

                                if (id1 < taskList.Count && id2 < taskList.Count)
                                {
                                    Task temp = taskList[id1];
                                    taskList[id1] = taskList[id2];
                                    taskList[id2] = temp;
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
                        PrintTasks();
                        break;

                    case "delete":
                        if (input.Length == 2)
                        {
                            try
                            {
                                int id = int.Parse(input[1]);
                                if (id < taskList.Count)
                                {
                                    if (Program.Validation(1))
                                    {
                                        taskList.Remove(taskList[id]);
                                    }
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
                        PrintTasks();
                        break;

                    case "rename":
                        Error.NotImplemented();
                        break;

                    case "help":
                        Help.HelpMe(gride, 1);
                        break;

                    default:
                        Error.UnknowCommand();
                        break;
                }
            }
        }
    }
}
