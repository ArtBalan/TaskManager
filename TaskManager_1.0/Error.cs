using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    class Error
    {
        static public void ClearLine()
        {
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            for (int i = 0; i < Console.WindowWidth - 2; i++) Console.Write(" ");
        }

        static public void OutOfRange()
        {
            ClearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Index Out Of Range.");
        }

        static public void WrongParameter()
        {
            ClearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Wrong Parametter Given.");
        }

        static public void UnknowCommand()
        {
            ClearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Unkown Command.");
        }

        static public void NotImplemented()
        {
            ClearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write("#error Command Not Implemented Yet.");
        }

        static public void Custom(String text)
        {
            ClearLine();
            Console.SetCursorPosition(1, Console.WindowHeight - 4);
            Console.Write(text);
        }
    }
}
