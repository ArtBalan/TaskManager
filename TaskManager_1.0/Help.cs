using System;
using System.Collections.Generic;
using System.Text;
using TaskManager;

namespace TaskManager_1._0
{
    class Help
    {
        private static String[] listStringMain ={"$show : Show the all the different list.",
                                          "$clear : Clear the screen. Might need to do the $show command after.",
                                          "$new name: Create a new list. Second optional parameter : 1 for daily, 0 else;",
                                          "$open id : Open a list.",
                                          "$edit id : Change the daily status of a list. Second optional parameter : 1 for daily else 0.",
                                          "$delete id : Delete a list. Confirmation will be needed.",
                                          "$rename id newName : Change the name of a list.",
                                          "$exit : exit the programe with saving. (not yet implemented)" };

        private static String[] listStringTask ={"$show : Show the all the different tasks.",
                                                 "$clear : Clear the screen. Might need to do the $show command after.",
                                                 "$new name: Create a new task. Second optional parameter : 1 to set the task done direcly, else 0.",
                                                 "$edit id : Change the status of a task. Second optional parameter : 1 for done, else 0.",
                                                 "$delete id : Delete a task. Confirmation will be needed.",
                                                 "$rename id newName : Change the name of a task.",
                                                 "$swap id id : swap the order of two taks.",
                                                 "$exit : exit the list." };






        public static void HelpMe(Gride gride, int i)
        {
            int h;
            String[] temp;

            gride.ClearScreen();
            if (Console.WindowHeight > 15) h = 10;
            else h = 5;
            
            if (i == 0) temp = listStringMain;
            else temp = listStringTask;

            int index = 0;
            foreach (string str in temp)
            {
                Console.SetCursorPosition(1, h+index);
                Console.Write(str);
                index++;
            }
        }
    }
}
