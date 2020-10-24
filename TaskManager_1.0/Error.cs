using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    class Error
    {
        static public void clearLine()
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            for (int i = 0; i < Console.WindowWidth - 2; i++) Console.Write(" ");
        }

        static public void OutOfRange()
        {
            clearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Index Out Of Range.");
        }

        static public void WrongParameter()
        {
            clearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Wrong Parametter Given.");
        }

        static public void UnknowCommand()
        {
            clearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Unkown Command.");
        }

        static public void NotImplemented()
        {
            clearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Command Not Implemented Yet.");
        }

        static public void Custom(String text)
        {
            clearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write(text);
        }
    }
}
