using System;

namespace TaskManager
{
    /// <summary>
    /// Static class written to change text color in console
    /// </summary>
    public static class ConsoleEx
    {
        public static void Write(string txt, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(txt);
            Console.ResetColor();
        }

        public static void WriteLine(string txt, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(txt);
            Console.ResetColor();
        }
    }
}
