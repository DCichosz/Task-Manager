using System;

namespace TaskManager
{
    /// <summary>
    /// Static class written to change text color in console
    /// </summary>
    public static class ConsoleEx
    {
        public static string Color;
        public static string Txt;

        public static void Write(string txt, ConsoleColor color)
        {
            Txt = txt;
            Console.ForegroundColor = color;
            Console.Write(Txt);
            Console.ResetColor();
        }

        public static void WriteLine(string txt, ConsoleColor color)
        {
            Txt = txt;
            Console.ForegroundColor = color;
            Console.WriteLine(Txt);
            Console.ResetColor();
        }
    }
}
